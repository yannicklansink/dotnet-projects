using CASE.YL.WebApp.Models;
using CASE.YL.WebApp.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CASE.YL.WebApp.ApiController
{

    [Route("api/v1/cursisten")]
    [ApiController]
    public class CursistController : ControllerBase
    {
        
        private readonly ICursistRepository _cursistRepository;

        public CursistController(ICursistRepository cursistRepository)
        {
            _cursistRepository = cursistRepository;
        }

        // GET: api/v1/cursisten
        [HttpGet]
        public ActionResult<IEnumerable<Cursist>> GetAll()
        {
            return Ok(_cursistRepository.GetAll());
        }

        // GET: api/v1/cursisten/{id}
        [HttpGet("{id}")]
        public ActionResult<Cursist> GetById(int id)
        {
            Cursist cursist = _cursistRepository.GetCursistWithCursussen(id);

            if (cursist == null)
            {
                return NotFound();
            }

            return Ok(cursist);
        }

        // POST: api/v1/cursisten
        [HttpPost]
        public ActionResult<Cursist> CreateParticulier(Particulier particulier)
        {
            if (particulier == null)
            {
                return BadRequest("particulier is empty");
            }

            Cursist createdParticulier = _cursistRepository.Add(particulier);
            return StatusCode(201, createdParticulier);
        }

        // PUT: api/v1/cursisten/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateParticulier(int id, Particulier particulier)
        {
            if (id != particulier.Id)
            {
                return BadRequest("id and particulier are not the same");
            }

            bool result = _cursistRepository.UpdateCursist(id, particulier);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/v1/cursisten/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            bool isDeleted = _cursistRepository.DeleteCursist(id);

            if (!isDeleted)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}
