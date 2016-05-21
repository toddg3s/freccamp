namespace freccamp
{
  using System;
  using System.Collections.Generic;
  using System.Data.Entity;
  using System.Linq;

  public class campdata : DbContext
  {
    // Your context has been configured to use a 'campdata' connection string from your application's 
    // configuration file (App.config or Web.config). By default, this connection string targets the 
    // 'freccamp.campdata' database on your LocalDb instance. 
    // 
    // If you wish to target a different database and/or database provider, modify the 'campdata' 
    // connection string in the application configuration file.
    public campdata()
      : base("name=campdata")
    {
    }

    // Add a DbSet for each entity type that you want to include in your model. For more information 
    // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

    public virtual DbSet<Camp> Camps { get; set; }
    public virtual DbSet<Camper> Campers { get; set; }
    public virtual DbSet<Registration> Registrations { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Camp>().
        HasMany(c => c.Registrations).
        WithMany(r => r.Camps).
        Map(
          m =>
          {
            m.MapLeftKey("Id");
            m.MapRightKey("Id");
            m.ToTable("CampRegistration");
          });
    }
  }

  public class Camp
  {
    public string Id { get; set; }
    public string Name { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool Advanced { get; set; }
    public ICollection<Registration> Registrations { get; set; }
  }

  public class Camper
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Parentname { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public int RiderLevel { get; set; }
    public string Notes { get; set; }
    public ICollection<Registration> Registrations { get; set; }
  }

  public class Registration
  {
    public int Id { get; set; }
    public string ContactName { get; set; }
    public string ContactEmail { get; set; }
    public string ContactPhone { get; set; }
    public List<Camper> Campers { get; set; }
    public List<Camp> Camps { get; set; }
  }
}