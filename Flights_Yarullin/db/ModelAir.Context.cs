﻿//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Flights_Yarullin.db
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class FlightsEntities : DbContext
    {
        public FlightsEntities()
            : base("name=FlightsEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Airline> Airline { get; set; }
        public DbSet<Airplane> Airplane { get; set; }
        public DbSet<Airticket> Airticket { get; set; }
        public DbSet<Booking> Booking { get; set; }
        public DbSet<Flight> Flight { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<sysdiagrams> sysdiagrams { get; set; }
        public DbSet<Type_Airplane> Type_Airplane { get; set; }
        public DbSet<TypeAirticket> TypeAirticket { get; set; }
        public DbSet<User> User { get; set; }
    }
}
