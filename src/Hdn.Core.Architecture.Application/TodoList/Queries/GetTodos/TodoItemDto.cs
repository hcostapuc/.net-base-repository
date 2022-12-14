using AutoMapper;
using Hdn.Core.Architecture.Application.Common.Mappings;
using Hdn.Core.Architecture.Domain.Entities;

namespace Hdn.Core.Architecture.Application.TodoList.Queries.GetTodos;

public class TodoItemDto : IMapFrom<TodoItemEntity>
{
    public Guid Id { get; set; }

    public Guid ListId { get; set; }

    public string? Title { get; set; }

    public bool Done { get; set; }

    public int Priority { get; set; }

    public string? Note { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<TodoItemEntity, TodoItemDto>()
            .ForMember(d => d.Priority, opt => opt.MapFrom(s => (int)s.Priority));
    }
}
