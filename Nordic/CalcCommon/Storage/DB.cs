﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculator.Common;
using Microsoft.EntityFrameworkCore;
using NLog;

namespace Calculator.Common.Storage
{
    /// <summary>
    /// База данных Code First
    /// </summary>
    public class DB : DbContext, IEqualityComparer<Material>
    {
        /// <summary>
        /// Протоколирование событий
        /// </summary>
        private Logger log = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Материалы
        /// </summary>
        public DbSet<Material> Materials { get; set; }

        /// <summary>
        /// Цвета
        /// </summary>
        public DbSet<Color> Colors { get; set; }

        /// <summary>
        /// Строки заказов
        /// </summary>
        public DbSet<OrderLine> OrderLines { get; set; }

        /// <summary>
        /// Конструктор - создание и миграция БД
        /// </summary>
        public DB()
        {
            Database.Migrate();
        }

        /// <summary>
        /// Настройка базы данных
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Конфигурация приложения
            var config = JsonFile.Load<Configuration>();
            // Проверка на корректность настроек
            if (string.IsNullOrEmpty(config.CodeFirstDatabase))
            {
                log.Warn("Строка соединения не задана в конфигурации");
            }
            optionsBuilder.UseMySQL(config.CodeFirstDatabase);
        }

        /// <summary>
        /// Сравнение материалов по имени
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool Equals(Material x, Material y)
        {
            return x != null ? x.Name.Equals(y?.Name) : false;
        }

        /// <summary>
        /// Хэш объекта
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public int GetHashCode([DisallowNull] Material obj)
        {
            return obj.Name.GetHashCode();
        }

        /// <summary>
        /// Поиск цвета по имени
        /// <para>Если цвет не найден, в базе будет создан новый цвет</para>
        /// <para>При запросе пустого цвета будет null</para>
        /// </summary>
        /// <param name="name">Название цвета</param>
        /// <returns>Цвет как объект</returns>
        public Color GetColor(string name)
        {
            if (string.IsNullOrEmpty(null))
            {
                return null;
            }
            var color = Colors.FirstOrDefault(x => x.Name == name);
            if (color == null)
            {
                color = new Color()
                {
                    Name = name
                };
                Colors.Add(color);
                SaveChanges();
            }
            return color;
        }

        public int InsertMaterials(Material[] materials)
        {
            // Загрузка данных
            foreach (Material m in materials)
            {
                var material = Materials.FirstOrDefault(x => x.Name == m.Name);
                if (material != null)
                { // поменять существующий
                    material.Price = m.Price;
                }
                else
                { // добавить новый
                    Materials.Add(m);
                }
            }

            /*
            // Список устаревших материалов
            var toDelete = Materials.Except(materials, this).ToList();

            foreach (var m in toDelete)
            {
                m.Active = false;
            }
            */

            // Сохранение изменений в БД
            SaveChanges();

            return materials.Count();
        }
    }
}
