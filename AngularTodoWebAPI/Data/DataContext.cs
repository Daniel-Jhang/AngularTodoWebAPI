namespace AngularTodoWebAPI.Data;

public partial class DataContext : DbContext
{
    public DataContext()
    {
    }

    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TodoList> Todolists { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseOracle("User Id=GUEST;Password=guest;Data Source=DESKTOP-V6HGHHL:1521/XEPDB1;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasDefaultSchema("GUEST")
            .UseCollation("USING_NLS_COMP");

        modelBuilder.Entity<TodoList>(entity =>
        {
            entity.HasKey(e => e.TodoId);

            entity.ToTable("TODOLIST");

            entity.Property(e => e.TodoId)
                .ValueGeneratedNever()
                .HasColumnName("TODOID");
            entity.Property(e => e.Context)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("CONTEXT");
            entity.Property(e => e.Editing)
                .HasPrecision(1)
                .HasColumnName("EDITING");
            entity.Property(e => e.SqlId)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("SQLID");
            entity.Property(e => e.Status)
                .HasPrecision(1)
                .HasColumnName("STATUS");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}