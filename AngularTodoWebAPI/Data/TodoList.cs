namespace AngularTodoWebAPI.Data;

public partial class TodoList
{
    public decimal SqlId { get; set; }

    public Guid TodoId { get; set; }

    public bool Status { get; set; }

    public bool Editing { get; set; }

    public string Context { get; set; } = null!;
}
