using TodoApp.Services;
using TodoApp.Services.Dtos;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace TodoApp.Pages;

public class IndexModel : AbpPageModel
{

    public List<TodoItemDto> Items { get; set; }

    private readonly TodoAppService todoAppService;

    public IndexModel(TodoAppService todoAppService)
    {
        this.todoAppService = todoAppService;
    }

    public async Task OnGetAsync()
    {
        Items = await todoAppService.GetListAsync();
    }
}