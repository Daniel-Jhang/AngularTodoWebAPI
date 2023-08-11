namespace AngularTodoWebAPI.Models;

public partial class TodoContext : DbContext
{
    public TodoContext()
    {
    }

    public TodoContext(DbContextOptions<TodoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TodoList> TodoLists { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TodoList>(entity =>
        {
            entity.HasKey(e => e.TodoId).HasName("PK__TodoList__958625523CA24D68");

            entity.ToTable("TodoList");

            entity.Property(e => e.TodoId).ValueGeneratedNever();
            entity.Property(e => e.Context)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.SqlId)
                .ValueGeneratedOnAdd()
                .HasColumnName("sqlId");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}