using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Todo.Application.Common.Dtos;
using Todo.Application.Services;

namespace Todo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class TodoListController : ControllerBase
    {
        private readonly ITodoListService _todoListService;

        public TodoListController(ITodoListService todoListService)
        {
            _todoListService = todoListService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoListDetailDto>>> GetAllList()
        {
            var result = await _todoListService.GetAllListAsync();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoListDetailDto>> GetTodoList(int id)
        {
            var result = await _todoListService.GetListByIdAsync(id);
            return Ok(result);
        }
        [HttpGet("listbyuser/{userId}")]
        public async Task<ActionResult> GetTodoListByUser(int userId)
        {
            var result = await _todoListService.GetTodoListByUser(userId);
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult> CreateTodoList([FromBody] TodoListDto todoListDto)
        {
            var result = await _todoListService.CreateTodoListAsync(todoListDto);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateTodoList(int id, [FromBody] TodoListDetailDto todoListDetailDto)
        {
            if (id != todoListDetailDto.Id)
            {
                return BadRequest();
            }
            var result = await _todoListService.UpdateTodoListAsync(todoListDetailDto);
            return Ok(result);
        }
        [HttpPost("remove")]
        public async Task<ActionResult> DeleteTodoList(IEnumerable<int> ids)
        {
            var result = await _todoListService.DeleteTodoListByListId(ids);
            return Ok(result);
        }
    }
}
