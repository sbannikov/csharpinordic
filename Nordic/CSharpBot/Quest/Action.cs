﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Serialization;
using NLog;

namespace CSharpBot.Quest
{
    public class Action
    {
        /// <summary>
        /// Протоколирование
        /// </summary>
        private static readonly Logger log = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Название действия
        /// </summary>
        public string Name;
        /// <summary>
        /// Описание действия
        /// </summary>
        [XmlElement(ElementName = "Text")]
        public string Description;
        /// <summary>
        /// Номер комнаты, в которую перемещается игрок
        /// </summary>
        [XmlElement(ElementName = "Next")]
        public int? Room;
        /// <summary>
        /// Команда при выборе действия
        /// </summary>
        public string Command;
        /// <summary>
        /// Условие для отображения команды
        /// </summary>
        public string Condition;

        /// <summary>
        /// Проверка выполнения условия для заданного игрока
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool IsCondition(User user)
        {
            // Если условие не задано,  значит оно всегда истинно
            if (string.IsNullOrEmpty(Condition)) return true;
            // Очистка пробелов
            string c = Condition.Replace(" ", "");
            // группы: (1)     (2) (3)
            // строка: undress ==  0
            var match = Regex.Match(c, "^([a-z]+)(==|!=|>|<|>=|<=)([0-9]+)$", RegexOptions.IgnoreCase);
            // Если не соответствует грамматике, то условие не выполнено
            if (!match.Success)
            {
                log.Warn($"Некорректное условие: {Condition}");
                return false;
            }
            string name = match.Groups[1].Value;
            string operation = match.Groups[2].Value;
            string constant = match.Groups[3].Value;

            // Получение значения переменной игрока по имени
            int value = 0;
            if (user.Variables.TryGetValue(name, out int i))
            {
                value = i;
            }

            int constValue = int.Parse(constant);

            switch (operation)
            {
                case "==":
                    return value == constValue;
                case "!=":
                    return value != constValue;
                case ">=":
                    return value >= constValue;
                case ">":
                    return value > constValue;
                case "<=":
                    return value <= constValue;
                case "<":
                    return value < constValue;
                default:
                    log.Warn($"Некорректная операция: {Condition}");
                    return false;
            }
        }
    }
}
