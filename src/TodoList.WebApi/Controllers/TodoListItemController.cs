using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Todo.Application.Common.Dtos;
using Todo.Application.Services;

namespace Todo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class TodoListItemController : ControllerBase
    {
        private readonly ITodoItemService _todoItemService;

        public TodoListItemController(ITodoItemService todoItemService)
        {
            _todoItemService = todoItemService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItemDetailDto>>> GetAllItems()
        {
            var result = await _todoItemService.GetAllItemAsync();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItemDetailDto>> GetTodoListItem(int id)
        {
            var result = await _todoItemService.GetItemByIdAsync(id);
            return Ok(result);
        }
        [HttpGet("todolist/{todoListId}")]
        public async Task<ActionResult> GetTodoListItemByTodoList(int todoListId)
        {
            var result = await _todoItemService.GetAllItemByTodoListAsync(todoListId);
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult> CreateItem([FromBody] TodoItemDto itemDto)
        {
            var result = await _todoItemService.CreateTodoItemAsync(itemDto);
            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateItem(int id, [FromBody] TodoItemDetailDto itemDto)
        {
            if (id != itemDto.Id)
            {
                return BadRequest();
            }

            var result = await _todoItemService.UpdateTodoItemAsync(itemDto);
            return Ok(result);
        }

        [HttpPost("remove")]
        public async Task<ActionResult> DeleteItems([FromBody] IEnumerable<int> ids)
        {
            var result = await _todoItemService.DeleteTodoItemByItemsId(ids);
            return Ok(result);
        }

        [HttpPost("completed")]
        public async Task<ActionResult> ItemsToComplete([FromBody] IEnumerable<int> ids)
        {

            var result = await _todoItemService.ChangeItemsToComplete(ids);
            return Ok(result);
        }

        /*[HttpPut("completed/{id}")]
        public async Task<ActionResult> ItemToComplete(int id, [FromBody] bool isCompleted)
        {
            var result = await _todoItemService.ChangeItemToComplete(id, isCompleted);
            return Ok(result);
        }*/
    }
}
