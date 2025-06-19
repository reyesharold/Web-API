using ApiFirstProj.AppDbContext;
using ApiFirstProj.Common;
using ApiFirstProj.DTO;
using ApiFirstProj.Entities;
using ApiFirstProj.Mediatorr;
using ApiFirstProj.Services;
using Asp.Versioning;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ApiFirstProj.Controllers.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public StudentController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<StudentResponse>> CreateStudent(StudentAddRequest student)
        {

            var command = _mapper.Map<CreateStudentCommand>(student);

            var response = await _mediator.Send(command);

            return CreatedAtAction("GetStudent", new { id = response.Id}, response);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentResponse>> GetStudent(Guid id)
        {

            var query = new GetStudentViaIdQuery
            {
                Id = id
            };

            var result = await _mediator.Send(query);

            return Ok(result);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentResponse>>> GetStudents()
        {
            var result = await _mediator.Send(new GetStudentsQuery());

            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(Guid id)
        {
            DeleteStudentCommand command = new DeleteStudentCommand { Id = id };

            var response = await _mediator.Send(command);

            if (!response) { return UnprocessableEntity(); }

            return NoContent();
        }
        [HttpPatch("{id}")]
        public async Task<ActionResult<StudentResponse>> UpdateStudentDetails(Guid id,StudentUpdateRequest request)
        {
            StudentUpdateCommand command = new StudentUpdateCommand
            {
                Id = id,
                Name = request.Name,
                Year = request.Year
            };

            var response = await _mediator.Send(command);
            if (response == null) { return NotFound(); }

            return Ok(response);
        }
    }
}
