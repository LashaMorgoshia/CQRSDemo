using CQRSDemo.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CQRSDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        public readonly IMediator Mediator;
        public TodoController(IMediator mediator)
        {
            Mediator = mediator;
            // mediator.Send(new GetTodoById.Query(12));
        }

        [HttpGet("/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = Mediator.Send(new GetTodoById.Query(id));
            return response != null ? Ok(response) : NotFound();
        }
    }
}
