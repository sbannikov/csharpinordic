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

namespace Calculator
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Загруженные данные
        /// </summary>
        private Data data;

        public MainForm()
        {
            InitializeComponent();
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

        private void LoadJson(string name)
        {
            string json = System.IO.File.ReadAllText(name);
            data = JsonConvert.DeserializeObject<Data>(json);
            LoadData(data);
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

            switch ((FileType)open.FilterIndex)
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
    }
}
