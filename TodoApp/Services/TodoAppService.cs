using TodoApp.Entities;
using TodoApp.Services.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace TodoApp.Services
{
    public class TodoAppService :ApplicationService
    {
        private readonly IRepository<TodoItem, Guid> repository;

        public TodoAppService(IRepository<TodoItem, Guid> repository)
        {
            this.repository = repository;
        }

        public async Task<List<TodoItemDto>> GetListAsync()
        {
            var item = await repository.GetListAsync();
            return item.Select(x => new TodoItemDto
            {
                Id = x.Id,
                Text = x.Text,
            }).ToList();
        }


        public async Task<TodoItemDto> CreateAsync(string text)
        {
            var item = await repository.InsertAsync(new TodoItem { Text = text });
            return new TodoItemDto { Id = item.Id, Text = item.Text };
        }

        public async Task DeleteAsync(Guid guid)
        {
            await repository.DeleteAsync(guid);
        }

    }
}
