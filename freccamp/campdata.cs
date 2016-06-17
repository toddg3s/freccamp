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

      modelBuilder.Entity<Registration>().
        HasMany(r => r.Campers).
        WithMany(c => c.Registrations).
        Map(
          m =>
          {
            m.MapLeftKey("RegistrationId");
            m.MapRightKey("Id");
            m.ToTable("CamperRegistration");
          });

      modelBuilder.Entity<Registration>().
        HasMany(r => r.Camps).
        WithMany(c => c.Registrations).
        Map(
          m =>
          {
            m.MapLeftKey("RegistrationId");
            m.MapRightKey("Id");
            m.ToTable("CampRegistration");
          });
        }

    public Registration GetFullReg(int id)
    {
      var reg = this.Registrations.Find(id);
      return reg;
    }
  }

  public class Camp
  {
    public string Id { get; set; }
    public string Name { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool Advanced { get; set; }
    public virtual ICollection<Registration> Registrations { get; set; }
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
    public virtual ICollection<Registration> Registrations { get; set; }
  }

  public class Registration
  {
    public int RegistrationId { get; set; }
    public string ContactName { get; set; }
    public string ContactEmail { get; set; }
    public string ContactPhone { get; set; }
    public int AmountPaid { get; set; }
    public virtual ICollection<Camper> Campers { get; set; }
    public virtual ICollection<Camp> Camps { get; set; }

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

    public void Update(Registration updreg, campdata ctx)
    {
      if (this.RegistrationId != updreg.RegistrationId)
      {
        throw new Exception("Attempt to update registration " + this.RegistrationId + " with data for " + updreg.RegistrationId);
      }
      this.ContactName = updreg.ContactName;
      this.ContactEmail = updreg.ContactEmail;
      this.ContactPhone = updreg.ContactPhone;
      for (var i = 0; i < this.Camps.Count; i++)
      {
        var camp = this.Camps.ElementAt(i);
        if (updreg.Camps.All(c => c.Id != camp.Id))
        {
          this.Camps.Remove(camp);
          i--;
        }
      }
      for (var i = 0; i < updreg.Camps.Count; i++)
      {
        var camp = updreg.Camps.ElementAt(i);
        if (this.Camps.All(c => c.Id != camp.Id))
          this.Camps.Add(ctx.Camps.Find(camp.Id));
      }

      for (var i = 0; i < this.Campers.Count; i++)
      {
        var camper = this.Campers.ElementAt(i);
        if (updreg.Campers.All(c => c.Id != camper.Id))
        {
          this.Campers.Remove(camper);
          i--;
        }
      }

      for (var i = 0; i < updreg.Campers.Count; i++)
      {
        var camper2 = updreg.Campers.ElementAt(i);
        if (camper2.Id == 0)
        {
          var c = ctx.Campers.Create();
          c.Name = camper2.Name;
          c.Parentname = (string.IsNullOrWhiteSpace(camper2.Parentname)) ? updreg.ContactName : camper2.Parentname;
          c.Phone = camper2.Phone;
          c.Email = camper2.Email;
          c.RiderLevel = camper2.RiderLevel;
          c.Notes = camper2.Notes;
          ctx.Campers.Add(c);
          this.Campers.Add(c);
        }
        else
        {
          var camper = this.Campers.FirstOrDefault(c => c.Id == camper2.Id);
          if (camper == null)
          {
            camper = ctx.Campers.Find(camper2.Id);
            this.Campers.Add(camper);
          }
          camper.Name = camper2.Name;
          camper.Parentname = (string.IsNullOrWhiteSpace(camper2.Parentname)) ? updreg.ContactName : camper2.Parentname;
          camper.Email = camper2.Email;
          camper.Phone = camper2.Phone;
          camper.RiderLevel = camper2.RiderLevel;
          camper.Notes = camper2.Notes;
        }
      }
    }

    public static Registration CreateNew(Registration newreg, campdata ctx)
    {
      var reg = ctx.Registrations.Create();
      reg.ContactName = newreg.ContactName;
      reg.ContactEmail = newreg.ContactEmail;
      reg.ContactPhone = newreg.ContactPhone;
      reg.Camps = new List<Camp>();
      foreach(var camp in newreg.Camps)
      {
        reg.Camps.Add(ctx.Camps.Find(camp.Id));
      }
      reg.Campers = new List<Camper>();
      foreach (var camper in newreg.Campers)
      {
        Camper c;
        if (camper.Id > 100)
        {
          c = ctx.Campers.Find(camper.Id);
        }
        else
        {
          c = ctx.Campers.Create();
          ctx.Campers.Add(c);
        }
        c.Name = camper.Name;
        c.Email = camper.Email;
        c.Parentname = (string.IsNullOrWhiteSpace(camper.Parentname)) ? newreg.ContactName : camper.Parentname;
        c.Phone = camper.Phone;
        c.RiderLevel = camper.RiderLevel;
        c.Notes = camper.Notes;
        reg.Campers.Add(c);
      }
      return reg;
    }
  }
}