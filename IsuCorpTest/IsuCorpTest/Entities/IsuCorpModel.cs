namespace IsuCorpTest.Entities
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class IsuCorpModel : DbContext
    {
        // Your context has been configured to use a 'IsuCorpModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'IsuCorpTest.Entities.IsuCorpModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'IsuCorpModel' 
        // connection string in the application configuration file.
        public IsuCorpModel()
            : base("name=IsuCorpModel")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.
        
        public virtual DbSet<Reservation> Reservations { get; set; }
        public virtual DbSet<ContactType> ContactTypes { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ContactType>().MapToStoredProcedures();
            modelBuilder.Entity<Reservation>().MapToStoredProcedures();
        }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}