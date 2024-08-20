using AutoMapper;
using Todo.Application.Common.Dtos;
using Todo.Application.Common.Interfaces;
using Todo.Domain.Entities;

namespace Todo.Application.Services
{
    public class TodoItemService : ITodoItemService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TodoItemService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        /*public async Task<TodoItemDetailDto> ChangeItemToComplete(int itemId, bool isCompleted)
        {
            var item = await _unitOfWork.TodoItemRepository.ChangeItemToComplete(itemId, isCompleted);
            await _unitOfWork.SaveChangesAsync();
            var result = _mapper.Map<TodoItemDetailDto>(item);
            return result;

        }*/

        public async Task<IEnumerable<TodoItemDetailDto>> ChangeItemsToComplete(IEnumerable<int> ids)
        {
            var items = new List<TodoItemDetailDto>();
            foreach (var id in ids)
            {
                var item = await _unitOfWork.TodoItemRepository.ChangeItemToComplete(id);
                var itemDto = _mapper.Map<TodoItemDetailDto>(item);
                items.Add(itemDto);
            }

            await _unitOfWork.SaveChangesAsync();
            return items;

        }

        public async Task<TodoItemDetailDto> CreateTodoItemAsync(TodoItemDto todoItemDto)
        {
            var item = _mapper.Map<TodoItem>(todoItemDto);
            await _unitOfWork.TodoItemRepository.CreateAsync(item);
            await _unitOfWork.SaveChangesAsync();
            var result = _mapper.Map<TodoItemDetailDto>(item);
            return result;
        }

        public async Task<bool> DeleteTodoItemByItemsId(IEnumerable<int> itemsIds)
        {
            var result = await _unitOfWork.TodoItemRepository.DeleteTodoItemByItemsId(itemsIds);
            await _unitOfWork.SaveChangesAsync();
            return result;
        }

        public async Task<IEnumerable<TodoItemDetailDto>> GetAllItemAsync()
        {
            var items = await _unitOfWork.TodoItemRepository.FindAllAsync();
            var result = _mapper.Map<IEnumerable<TodoItemDetailDto>>(items);
            return result;
        }

        public async Task<IEnumerable<TodoItemDetailDto>> GetAllItemByTodoListAsync(int todoListId)
        {
            var items = await _unitOfWork.TodoItemRepository.FindAllTodoItemByTodoList(todoListId);
            var result = _mapper.Map<IEnumerable<TodoItemDetailDto>>(items);
            return result;
        }

        public async Task<TodoItemDetailDto> GetItemByIdAsync(int id)
        {
            var item = await _unitOfWork.TodoItemRepository.FindByConditionalAsync(i => i.Id.Equals(id));
            var result = _mapper.Map<TodoItemDetailDto>(item);
            return result;
        }

        public async Task<TodoItemDetailDto> UpdateTodoItemAsync(TodoItemDetailDto todoItemDetailDto)
        {
            var item = _mapper.Map<TodoItem>(todoItemDetailDto);
            await _unitOfWork.TodoItemRepository.UpdateAsync(item);
            await _unitOfWork.SaveChangesAsync();
            var result = _mapper.Map<TodoItemDetailDto>(item);
            return result;
        }
    }
}
