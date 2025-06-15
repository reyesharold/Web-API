using ApiFirstProj.DTO;
using ApiFirstProj.Entities;
using ApiFirstProj.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiFirstProj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        private readonly IProfessorServices _professorServices;

        public ProfessorController(IProfessorServices professorServices)
        {
            _professorServices = professorServices;
        }

        /// <summary>
        /// Creates a Professor and input it in the database.
        /// </summary>
        /// <param name="professor">Professor DTO add request. This includes the name of professor.</param>
        /// <returns>Professor DTO response. This includes ID, Name and subjects assigned to the professor.</returns>
        [HttpPost]
        public async Task<ActionResult<ProfessorResponse>> CreateProfessor(ProfessorAddRequest professor)
        {
            var response = await _professorServices.AddProfessorAsync(professor);

            return CreatedAtAction("GetProfessor", new { id = response.Id }, response);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ProfessorResponse>> GetProfessor(Guid id)
        {
            var response = await _professorServices.GetProfessorViaIdAsync(id);
            if (response == null) { return NotFound(); }

            return Ok(response);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProfessorResponse>>> GetProfessors()
        {
            var response = await _professorServices.GetAllProfessors();

            if (response == null) { NotFound(); }

            return Ok(response);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfessors(Guid id)
        {
            var response = await _professorServices.DeleteProfessorViaIdAsync(id);

            if (!response) { return UnprocessableEntity(); }

            return NoContent();
        }
        [HttpPatch("{id}")]
        public async Task<ActionResult<ProfessorResponse>> UpdateStudentDetails(Guid id, ProfessorUpdateRequest request)
        {
            var response = await _professorServices.UpdateProfessorViaIdAsync(id, request);
            if (response == null) { return NotFound(); }

            return Ok(response);
        }
    }
}
