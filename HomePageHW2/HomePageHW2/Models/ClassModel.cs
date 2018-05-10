using System.Data.Entity;

namespace HomePageHW2.Models
{
  public partial class ClassModel : DbContext
  {
    public ClassModel()
        : base("name=ClassModel")
    {
    }

    public virtual DbSet<Class> Classes { get; set; }
    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Class>()
          .Property(e => e.ClassName)
          .IsUnicode(false);

      modelBuilder.Entity<Class>()
          .Property(e => e.ClassDescription)
          .IsUnicode(false);

      modelBuilder.Entity<Class>()
          .Property(e => e.ClassPrice)
          .HasPrecision(10, 4);

      modelBuilder.Entity<Class>()
          .HasMany(e => e.Users)
          .WithMany(e => e.Classes)
          .Map(m => m.ToTable("UserClass").MapLeftKey("ClassId").MapRightKey("UserId"));

      modelBuilder.Entity<User>()
          .Property(e => e.UserPassword)
          .IsUnicode(false);
    }
  }
}
