using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskPionner.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaskPionner.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("corspolicy")]

    public class CategoryController : ControllerBase
    {
        ServicesDBContext _db;
        public CategoryController(ServicesDBContext context)
        {
            _db = context;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_db.Categories.Include(x => x.ser).OrderBy(x => x.Name).ToList());

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
                return Ok(_db.Categories.Include(x => x.ser).FirstOrDefault(x=>x.Id==id));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [HttpPost("PostSaveData")]
         public IActionResult PostSaveData([FromBody]  Category type)
        {
            try
            {
                if (type != null)
                {
                    type.ser = null;
                    if (ModelState.IsValid)
                    {
                        
                        _db.Categories.Add(type);
                        _db.SaveChanges();
                        return Ok();

                    }
                }
                return BadRequest(type);
               
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
         [HttpPut("PutEdite/{id}")]
        public IActionResult PutEdite(int id, [FromBody] Category cat)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var oldcat = _db.Categories.FirstOrDefault(x => x.Id == id);
                    if (oldcat != null)
                    {
                        oldcat.Name = cat.Name;
                         oldcat.service_id = cat.service_id;
                         oldcat.amount = cat.amount;
                        _db.Categories.Update(oldcat);
                        _db.SaveChanges();
                        return Ok(oldcat);
                    }
                    return BadRequest(cat);
                }
                return BadRequest(cat);


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
                var oldcat = _db.Categories.FirstOrDefault(x => x.Id == id);
                if (oldcat != null)
                {

                    _db.Categories.Remove(oldcat);
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

