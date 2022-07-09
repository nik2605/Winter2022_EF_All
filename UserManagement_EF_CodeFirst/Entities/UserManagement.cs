using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Sockets;

namespace UserManagement_EF_CodeFirst.Entities
{
    public class UserManagement : DbContext
    {
        // Your context has been configured to use a 'UserManagement' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'UserManagement_EF_CodeFirst.Entities.UserManagement' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'UserManagement' 
        // connection string in the application configuration file.
        public UserManagement()
            : base("name=OrderManagement")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

         public virtual DbSet<Order> Order { get; set; }
         public virtual DbSet<Province> Province { get; set; }
         public virtual DbSet<Address> Address { get; set; }
    }

    public class Order
    {
        public int Id { get; set; }
        public string Number { get; set; }

        public int Qty { get; set; }

        public decimal Price { get; set; }

        public string Name { get; set; }

        public Address ShippingAddress { get; set; }
    }

    public class Address
    {
        public int Id { get; set; }
        public string Street1 { get; set; }

        public int City { get; set; }

        public Province Province { get; set; }

        public string Postal { get; set; }

        public string Country { get; set; }

        public ICollection<Order> Orders { get; set; }
    }

    public class Province
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Address> Address { get; set; }
    }


}