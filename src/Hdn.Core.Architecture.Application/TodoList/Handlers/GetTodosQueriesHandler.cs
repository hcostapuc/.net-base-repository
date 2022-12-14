using AutoMapper;
using Hdn.Core.Architecture.Application.TodoList.Queries.GetTodos;
using Hdn.Core.Architecture.Domain.Enums;
using Hdn.Core.Architecture.Domain.Interfaces.Repository;
using MediatR;

namespace Hdn.Core.Architecture.Application.TodoList.Handlers;
public class GetTodosQueryHandler : IRequestHandler<GetTodosQuery, TodosVm>
{
    private readonly ITodoListRepository todoListRepository;
    private readonly IMapper mapper;

    public GetTodosQueryHandler(ITodoListRepository todoListRepository, IMapper mapper)
    {
        this.todoListRepository = todoListRepository ?? throw new ArgumentNullException(nameof(todoListRepository));
        this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<TodosVm> Handle(GetTodosQuery request, CancellationToken cancellationToken)
    {
        return new TodosVm
        {
            PriorityLevels = Enum.GetValues(typeof(PriorityLevel))
                .Cast<PriorityLevel>()
                .Select(p => new PriorityLevelDto { Value = (int)p, Name = p.ToString() })
                .ToList(),

            Lists = mapper.Map<IList<TodoListDto>>(await todoListRepository.SelectAllAsync(cancellationToken: cancellationToken))
        };
    }
}
