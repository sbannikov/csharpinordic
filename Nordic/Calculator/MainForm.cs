using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using Newtonsoft.Json;
using NLog;

namespace Calculator
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Протоколирование событий
        /// </summary>
        private Logger log = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Загруженные данные
        /// </summary>
        private Data data;

        /// <summary>
        /// База данных
        /// </summary>
        private Database db;

        /// <summary>
        /// Наблюдатель событий файловой системы
        /// </summary>
        private System.IO.FileSystemWatcher watcher;

        /// <summary>
        /// Очередь изменившихся файлов
        /// </summary>
        private Queue<string> queue = new Queue<string>();

        /// <summary>
        /// Таймер перезагрузки файлов
        /// </summary>
        private Timer timer;

        public MainForm()
        {
            InitializeComponent();

            watcher = new System.IO.FileSystemWatcher()
            {
                Path = @"C:\FILE"
            };
            watcher.Created += WatchFile;
            watcher.Changed += WatchFile;
            watcher.Renamed += WatchFile;

            timer = new Timer()
            {
                Interval = 1000
            };
            timer.Tick += Timer_Tick;

            db = new Database();
        }

        /// <summary>
        /// Срабатывание таймера
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void Timer_Tick(object? sender, EventArgs e)
        {
            // Опустошение очереди и построение списка измененных файлов
            List<string> names = new List<string>();
            while (queue.TryDequeue(out string name))
            {
                names.Add(name);
            }
            // Построение уникального списка файлов
            names = names.Distinct().ToList();

            // Загрузка файлов
            foreach (string name in names)
            {
                string ext = System.IO.Path.GetExtension(name).ToLower();

                switch (ext)
                {
                    case ".csv":
                        break;
                    case ".json":
                        if (MessageBox.Show($"Перезагрузить файл {name}?", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            LoadJson(name);
                        }
                        break;
                    case ".xml":
                        break;
                    default:
                        log.Trace($"Файл {name} не обрабатывается");
                        break;
                }
            }
        }

        /// <summary>
        /// Обработка события изменения файла
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void WatchFile(object sender, System.IO.FileSystemEventArgs e)
        {
            log.Trace($"{e.Name} {e.ChangeType}");
            queue.Enqueue(e.FullPath);
        }

        /// <summary>
        /// Выход из приложения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Загрузить файл в формате CSV
        /// </summary>
        /// <param name="name"></param>
        private void LoadCsv(string name)
        {
            string[] lines = System.IO.File.ReadAllLines(name);

            // Список цветов
            var colors = new Dictionary<string, Color>();

            // Пропускаем первую строку (там заголовок)
            for (int i = 1; i < lines.Length; i++)
            {
                // Разбор строки по разделителю
                string[] fields = lines[i].Split(';');
                string colorName = fields[1];
                // Проверка на дубликат
                if (!colors.ContainsKey(colorName))
                {
                    var color = new Color()
                    {
                        Name = colorName
                    };
                    colors.Add(colorName, color);
                }
            }

            // Список материалов
            var materials = new List<Material>();

            // Пропускаем первую строку (там заголовок)
            for (int i = 1; i < lines.Length; i++)
            {
                // Разбор строки по разделителю
                string[] fields = lines[i].Split(';');
                // Инициализатор объекта
                var material = new Material()
                {
                    Name = fields[0],
                    MaterialColor = colors[fields[1]],
                    ColorName = fields[1],
                    Price = !string.IsNullOrEmpty(fields[2]) ? double.Parse(fields[2]) : double.NaN
                };
                /*
                 * Альтернативный вариант инициализации Price
                if (!string.IsNullOrEmpty(fields[2]))
                {
                    material.Price = double.Parse(fields[2]);
                }
                else
                {
                    material.Price = null; // это и так по умолчанию
                }
                */
                materials.Add(material);
            }

            // Выпадающий список цветов
            comboColor.Items.AddRange(colors.Values.ToArray());

            // Сохранение загруженных данных
            data = new Data()
            {
                Materials = materials.ToArray()
            };

            // Выпадающий список материалов
            comboMaterial.Items.AddRange(data.Materials);
        }

        /// <summary>
        /// Построение списка цветов
        /// </summary>
        /// <param name="data"></param>
        private void LoadData(Data data)
        {
            if (data != null)
            {
                // Список цветов
                var colors = new Dictionary<string, Color>();

                foreach (var material in data.Materials)
                {
                    string colorName = material.ColorName ?? String.Empty;
                    Color color;
                    // Проверка на дубликат
                    if (!colors.ContainsKey(colorName))
                    {
                        // Добавление нового цвета в словарь
                        color = new Color()
                        {
                            Name = colorName
                        };
                        colors.Add(colorName, color);
                    }
                    else
                    {
                        color = colors[colorName];
                    }
                    material.MaterialColor = color;
                }

                // Выпадающий список цветов
                comboColor.Items.AddRange(colors.Values.ToArray());

                // Выпадающий список материалов
                comboMaterial.Items.AddRange(data.Materials);
            }
        }

        /// <summary>
        /// Загрузка XML-файла десериализацией
        /// </summary>
        /// <param name="name"></param>
        private void LoadXml(string name)
        {
            var serializer = new XmlSerializer(typeof(Data));
            var reader = System.Xml.XmlReader.Create(name);
            data = (Data)serializer.Deserialize(reader);
            LoadData(data);
        }

        /// <summary>
        /// Загрузка данных из JSON
        /// </summary>
        /// <param name="name"></param>
        private void LoadJson(string name)
        {
            string json = System.IO.File.ReadAllText(name);
            data = JsonConvert.DeserializeObject<Data>(json);
            LoadData(data);
            // Загрузить список материалов в базу данных
            db.InsertMaterials(data.Materials);
        }

        /// <summary>
        /// Загрузка файла данных
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // Запрос имени загружаемого файла 
                if (open.ShowDialog() != DialogResult.OK) return;

                // Предварительная очистка списков
                comboColor.Items.Clear();
                comboMaterial.Items.Clear();

                switch ((FileType)open.FilterIndex)
                {
                    case FileType.CSV:
                        LoadCsv(open.FileName);
                        break;
                    case FileType.XML:
                        LoadXml(open.FileName);
                        break;
                    case FileType.JSON:
                        LoadJson(open.FileName);
                        break;
                    default:
                        throw new NotImplementedException();
                }

                // Включение пункта меню "Сохранить"
                SaveToolStripMenuItem.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Выбор материала в списке
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboMaterial_SelectedIndexChanged(object sender, EventArgs e)
        {
            var material = (Material)comboMaterial.SelectedItem;
            if (material != null)
            {
                textPrice.Text = material.Price.ToString();
            }
        }

        /// <summary>
        /// Выбор цвета
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            var color = (Color)comboColor.SelectedItem;
            if (color != null)
            {
                var list = data.Materials.Where(x => x.MaterialColor.Name == color.Name);
                // Предварительная очистка списка материалов
                comboMaterial.Items.Clear();
                // Заполнение списка материалов
                comboMaterial.Items.AddRange(list.ToArray());
            }
        }

        /// <summary>
        /// Сохранение файла
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Запрос имени сохраняемого файла
            if (save.ShowDialog() != DialogResult.OK) return;

            switch ((FileType)save.FilterIndex)
            {
                case FileType.CSV:
                    data.SaveToCsv(save.FileName);
                    break;
                case FileType.XML:
                    data.SaveToXml(save.FileName);
                    break;
                case FileType.JSON:
                    data.SaveToJson(save.FileName);
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Загрузка формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            watcher.EnableRaisingEvents = true;
            timer.Start();
            db.Connect();
            log.Info("Программа запущена");
        }
    }
}
