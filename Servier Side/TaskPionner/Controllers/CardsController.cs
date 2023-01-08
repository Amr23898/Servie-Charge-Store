using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Text.Json;
using System.Text.Json.Serialization;
using TaskPionner.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaskPionner.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("corspolicy")]
    public class CardsController : ControllerBase
    {
        ServicesDBContext _db;
        public CardsController(ServicesDBContext context)
        {
            _db = context;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_db. cards.Include(x=>x.cat).OrderBy(x => x.price).ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetByID/{id}")]
        public IActionResult GetByID(int id)
        {
            try
            {
                var ordercard = _db.cards.FirstOrDefault(x => x.Id == id);
                if (ordercard != null)
                {
                    var cardcategory = _db.Categories.FirstOrDefault(x => x.Id == ordercard.catid);
                    
                    if(cardcategory.amount!= 0)
                    {
                        cardcategory.amount -= 1;
                        _db.Categories.Update(cardcategory);
                        _db.SaveChanges();
                        return Ok(_db.cards.Include(x => x.cat).FirstOrDefault(x => x.catid == cardcategory.Id));
                       

                    }
                    return Content("This card is Finshed");

                }
                return  Content("This card is closed");


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [HttpPost("PostSaveData")]
        public IActionResult PostSaveData([FromBody] card cards)
        {
            try
            {
                if (cards != null)
                {
                    cards.cat = null;

                    if (ModelState.IsValid)
                    {
                      

                        var catagory =_db.Categories.FirstOrDefault(x => x.Id == cards.catid);
                        catagory.amount += 1;                      
                        _db.Categories.Update(catagory);
                        _db.cards.Add(cards);
                        _db.SaveChanges();
                        return Ok();
                    }
                }
                return BadRequest(cards);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("PutEdite/{id}")]
        public IActionResult PutEdite(int id, [FromBody] card newcard)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var oldcat = _db.cards.FirstOrDefault(x => x.Id == id);
                    if (oldcat != null)
                    {
                        oldcat.price = newcard.price;
                        oldcat.code = newcard.code;
                        oldcat.serial = newcard.serial;
                        oldcat.operationnumber = newcard.operationnumber;
                        _db.cards.Update(oldcat);
                        _db.SaveChanges();
                        return Ok(oldcat);
                    }
                    return BadRequest();
                }
                return BadRequest(newcard);


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var oldcat = _db.cards.FirstOrDefault(x => x.Id == id);
                if (oldcat != null)
                {

                    _db.cards.Remove(oldcat);
                    _db.SaveChanges();
                    return Ok();
                }
                return BadRequest();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
