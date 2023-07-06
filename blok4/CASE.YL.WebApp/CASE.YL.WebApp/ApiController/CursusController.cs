using CASE.YL.WebApp.Models;
using CASE.YL.WebApp.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CASE.YL.WebApp.ApiController
{
    [Route("api/v1/cursussen")]
    [ApiController]
    public class CursusController : Controller
    {
        private readonly ICursusRepository _cursusRepository;

        public CursusController(ICursusRepository cursusRepository)
        {
            _cursusRepository = cursusRepository;
        }

        // GET: api/v1/cursussen
        [HttpGet]
        public ActionResult<IQueryable<Cursus>> GetAll() 
        {
            return Ok(_cursusRepository.GetAll());
        }

        // PUT: api/v1/cursussen/{id}
        [HttpGet("{id}")]
        public ActionResult<Cursus> GetById(int id)
        {
            Cursus cursus = _cursusRepository.GetCursusById(id); 

            if (cursus == null)
            {
                return NotFound();
            }

            return Ok(cursus);
        }

        // POST: api/v1/cursussen
        [HttpPost]
        public ActionResult<Cursus> CreateCursus(Cursus cursus)
        {
            if (cursus == null)
            {
                return BadRequest("cursus is empty");
            }

            Cursus createdCursus = _cursusRepository.Add(cursus);
            return StatusCode(201, createdCursus);
        }

        // PUT: api/v1/cursussen/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateCursus(int id, Cursus cursus)
        {
            if (id != cursus.Id)
            {
                return BadRequest("id and cursus are not the same");
            }

            bool result = _cursusRepository.Update(id, cursus);

            if (!result)
            {
                return NotFound();
            }

            return Ok(cursus);
        }

        // DELETE: api/v1/cursussen/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteCursus(int id)
        {
            bool isDeleted = _cursusRepository.DeleteCursus(id);

            if (!isDeleted)
            {
                return NotFound();
            }

            return NoContent();
        }


}
}
