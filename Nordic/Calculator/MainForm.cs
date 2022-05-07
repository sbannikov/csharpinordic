using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Список материалов
        /// </summary>
        private List<Material> materials;

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
            materials = new List<Material>();

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
                    Price = !string.IsNullOrEmpty(fields[2]) ? double.Parse(fields[2]) : null
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

            // Выпадающий список материалов
            comboMaterial.Items.AddRange(materials.ToArray());
        }

        /// <summary>
        /// Загрузка XML-файла десериализацией
        /// </summary>
        /// <param name="name"></param>
        private void LoadXml(string name)
        { 
        }

        /// <summary>
        /// Загрузка файла данных
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Запрос имени загружаемого файла 
            if (open.ShowDialog() != DialogResult.OK) return;

            switch (open.FilterIndex)
            {
                case 1:
                    LoadCsv(open.FileName);
                    break;
                case 2:
                    LoadXml(open.FileName);
                    break;
                default:
                    throw new NotImplementedException();
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
                var list = materials.Where(x => x.MaterialColor.Name == color.Name);
                // Предварительная очистка списка материалов
                comboMaterial.Items.Clear();
                // Заполнение списка материалов
                comboMaterial.Items.AddRange(list.ToArray());
            }
        }
    }
}
