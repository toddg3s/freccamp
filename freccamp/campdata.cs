namespace freccamp
{
  using System;
  using System.Collections.Generic;
  using System.Data.Entity;
  using System.Linq;
  using System.Text;

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
            m.MapRightKey("RegistrationId");
            m.ToTable("CampRegistration");
          });

      modelBuilder.Entity<Camper>().
        HasMany(c => c.Registrations).
        WithMany(r => r.Campers).
        Map(
          m =>
          {
              m.MapLeftKey("Id");
              m.MapRightKey("RegistrationId");
              m.ToTable("CamperRegistration");
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
    public int RegistrationId { get; set; }
    public string ContactName { get; set; }
    public string ContactEmail { get; set; }
    public string ContactPhone { get; set; }
    public List<Camper> Campers { get; set; }
    public List<Camp> Camps { get; set; }

    public string GetSummary()
    {
      var sb = new StringBuilder();
      if(Camps!=null && Camps.Count > 0)
      {
        sb.Append(String.Join(",", Camps.Select(c => c.Name)));
      }
      else
      {
        sb.Append("(none)");
      }
      sb.Append(" for ");
      if(Campers!=null && Campers.Count > 0)
      {
        sb.Append(String.Join(",", Campers.Select(c => c.Name)));
      }
      else
      {
        sb.Append("(no one)");
      }
      return sb.ToString();
    }

    public void Update(Registration updreg)
    {
      if (this.RegistrationId != 0 && this.RegistrationId != updreg.RegistrationId)
      {
        throw new Exception("Attempt to update registration " + this.RegistrationId + " with data for " + updreg.RegistrationId);
      }
      this.RegistrationId = updreg.RegistrationId;
      this.ContactName = updreg.ContactName;
      this.ContactEmail = updreg.ContactEmail;
      this.ContactPhone = updreg.ContactPhone;
      if (this.Campers == null) this.Campers = new List<Camper>();
      if (this.Camps == null) this.Camps = new List<Camp>();
      if (updreg.Camps == null) updreg.Camps = new List<Camp>();
      if (updreg.Campers == null) updreg.Campers = new List<Camper>();
      for (var i = 0; i < this.Camps.Count; i++)
      {
        if (updreg.Camps.All(c => c.Id != this.Camps[i].Id))
          this.Camps.RemoveAt(i--);
      }
      for (var i = 0; i < updreg.Camps.Count; i++)
      {
        if (this.Camps.All(c => c.Id != updreg.Camps[i].Id))
          this.Camps.Add(updreg.Camps[i]);
      }

      for (var i = 0; i < this.Campers.Count; i++)
      {
        if (updreg.Campers.All(c => c.Id != this.Campers[i].Id))
          this.Campers.RemoveAt(i);
      }

      for (var i = 0; i < updreg.Campers.Count; i++)
      {
        var camper = this.Campers.Where(c => c.Id == updreg.Campers[i].Id).FirstOrDefault();
        if (camper == null)
        {
          this.Campers.Add(updreg.Campers[i]);
        }
        else
        {
          camper.Name = updreg.Campers[i].Name;
          camper.Parentname = updreg.Campers[i].Parentname;
          camper.Email = updreg.Campers[i].Email;
          camper.Phone = updreg.Campers[i].Phone;
          camper.RiderLevel = updreg.Campers[i].RiderLevel;
          camper.Notes = updreg.Campers[i].Notes;
        }
      }
    }
  }
}