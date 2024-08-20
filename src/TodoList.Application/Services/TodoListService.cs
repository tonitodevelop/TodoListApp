using AutoMapper;
using Todo.Application.Common.Dtos;
using Todo.Application.Common.Interfaces;
using Todo.Domain.Entities;

namespace Todo.Application.Services
{
    public class TodoListService : ITodoListService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TodoListService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<TodoListDetailDto> CreateTodoListAsync(TodoListDto todoListDto)
        {
            var todoList = _mapper.Map<TodoList>(todoListDto);
            await _unitOfWork.TodoListRepository.CreateAsync(todoList);
            await _unitOfWork.SaveChangesAsync();

            var resultDto = _mapper.Map<TodoListDetailDto>(todoList);
            return resultDto;
        }

        public async Task<bool> DeleteTodoListByListId(IEnumerable<int> ids)
        {
            var result = await _unitOfWork.TodoListRepository.DeleteTodoListByListId(ids);
            await _unitOfWork.SaveChangesAsync();
            return result;
        }

        public async Task<IEnumerable<TodoListDetailDto>> GetAllListAsync()
        {
            var list = await _unitOfWork.TodoListRepository.FindAllAsync();
            var result = _mapper.Map<IEnumerable<TodoListDetailDto>>(list);
            return result;
        }

        public async Task<TodoListDetailDto> GetListByIdAsync(int id)
        {
            //var list = await _unitOfWork.TodoListRepository.FindByConditionalAsync(l => l.Id.Equals(id));
            var list = await _unitOfWork.TodoListRepository.FindTodoListByTodoListWithItems(id);
            var result = _mapper.Map<TodoListDetailDto>(list);
            return result;
        }

        public async Task<IEnumerable<TodoListDetailDto>> GetTodoListByUser(int userId)
        {
            var list = await _unitOfWork.TodoListRepository.FindAllTodoListByUser(userId);
            var result = _mapper.Map<IEnumerable<TodoListDetailDto>>(list);
            return result;
        }

        public async Task<TodoListDetailDto> UpdateTodoListAsync(TodoListDetailDto todoListDetailDto)
        {
            var todoList = _mapper.Map<TodoList>(todoListDetailDto);
            await _unitOfWork.TodoListRepository.UpdateAsync(todoList);
            await _unitOfWork.SaveChangesAsync();
            var todoListUpdated = _mapper.Map<TodoListDetailDto>(todoList);
            return todoListUpdated;
        }
    }
}
