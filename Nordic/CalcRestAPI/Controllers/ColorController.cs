using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Calculator.RestAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ColorController : ControllerBase
    {
        /// <summary>
        /// Список цветов
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Common.Storage.Color> GetColors()
        {
            using (var db = new Common.Storage.DB())
            {
                // SELECT * FROM Colors ORDER BY Name
                return db.Colors.OrderBy(x => x.Name).ToList();
            }
        }

        /// <summary>
        /// Добавление цвета
        /// </summary>
        /// <param name="name">Добавляемый цвет</param>
        [HttpPost]
        public IActionResult AddColor(string name)
        {
            using (var db = new Common.Storage.DB())
            {
                // Проверка на наличие параметра
                if (string.IsNullOrEmpty(name))
                {
                    return BadRequest("Цвет не заполнен (параметр name)");
                }
                var existingColor = db.Colors.FirstOrDefault(x => x.Name == name);
                if (existingColor != null)
                {
                    return BadRequest($"Цвет {name} уже существует");
                }
                var color = new Common.Storage.Color()
                {
                    Name = name
                };
                db.Colors.Add(color);
                db.SaveChanges();
                return Ok($"Цвет {name} успешно добавлен");
            }
        }
    }
}
