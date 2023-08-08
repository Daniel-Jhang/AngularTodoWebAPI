using System;
using System.Collections.Generic;

namespace AngularTodoWebAPI.Models;

public partial class TodoList
{
    public int SqlId { get; set; }

    public Guid TodoId { get; set; }

    public bool Status { get; set; }

    public string Context { get; set; } = null!;

    public bool Editing { get; set; }
}
