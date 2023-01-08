using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using TaskPionner.Model;
using TaskPionner.Repositry;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaskPionner.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("corspolicy")]
    public class servicesController : ControllerBase
    {
        private readonly IRepositoryService _service;

        public servicesController(IRepositoryService repositoryService)
        {
            this._service = repositoryService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_service.GetallServices());

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
                return Ok(_service.getsSrviceById(id));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("PostSaveData")]
        public IActionResult PostSaveData([FromBody] Services newservice)
        {
            try
            {
                if(newservice != null)
                {
                    if (ModelState.IsValid)
                    {
                        _service.insertServices(newservice);
                        return Ok();
                    }
                }
                return BadRequest(newservice);
              
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("PutEdite/{id}")]
        public IActionResult PutEdite(int id, [FromBody] Services newservice)
        {
            try
            {
                if (ModelState.IsValid)
                {
                   _service.Updateservices(id, newservice);
                    return BadRequest(newservice);
                }
                return BadRequest(newservice);

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
                var service = _service.getsSrviceById(id);
                if (service != null)
                {

                    _service.Deleteservices(id);
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
