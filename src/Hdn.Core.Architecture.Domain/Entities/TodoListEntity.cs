namespace Hdn.Core.Architecture.Domain.Entities;

public class TodoListEntity : AuditableEntity
{
    public string? Title { get; set; }

    public Colour Colour { get; set; } = Colour.White;

    public IList<TodoItemEntity> Items { get; private set; } = new List<TodoItemEntity>();
}
