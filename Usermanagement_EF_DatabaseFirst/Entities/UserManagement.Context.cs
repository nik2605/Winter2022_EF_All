﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Usermanagement_EF_DatabaseFirst.Entities
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class UserManagementEntities : DbContext
    {
        public UserManagementEntities()
            : base("name=UserManagementEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Province> Provinces { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<PersonSummary> PersonSummaries { get; set; }
    
        public virtual ObjectResult<GetPersons_Result> GetPersons(Nullable<int> personID, ObjectParameter firstName, ObjectParameter lastName, ObjectParameter age, ObjectParameter emailID, ObjectParameter gender, ObjectParameter addressID)
        {
            var personIDParameter = personID.HasValue ?
                new ObjectParameter("PersonID", personID) :
                new ObjectParameter("PersonID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetPersons_Result>("GetPersons", personIDParameter, firstName, lastName, age, emailID, gender, addressID);
        }
    
        public virtual int GetUser(Nullable<int> userId, ObjectParameter firstName, ObjectParameter lastName)
        {
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("GetUser", userIdParameter, firstName, lastName);
        }
    }
}