using Calculator.Common.Storage;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Calculator.RestAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MaterialController : ControllerBase
    {
        [HttpPost]
        public IActionResult Load(Material[] materials)
        {
            using (var db = new DB())
            {              
                // Загрузка данных
                foreach (Material m in materials)
                {
                    var material = db.Materials.FirstOrDefault(x => x.Name == m.Name);
                    if (material != null)
                    { // поменять существующий
                        material.Price = m.Price;
                        material.MaterialColor = db.GetColor(m.ColorName);
                    }
                    else
                    { // добавить новый
                        m.MaterialColor = db.GetColor(m.ColorName);
                        db.Materials.Add(m);
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
                db.SaveChanges();

                return Ok();
            }
        }
    }
}
