﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LeaveManagementSystem.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class LeaveManagementDBEntities : DbContext
    {
        public LeaveManagementDBEntities()
            : base("name=LeaveManagementDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Employees_Other_Leave_Counts> Employees_Other_Leave_Counts { get; set; }
        public virtual DbSet<Employees_Take_Leaves> Employees_Take_Leaves { get; set; }
        public virtual DbSet<Leave> Leaves { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Posting_Place> Posting_Place { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Type_Of_Institute> Type_Of_Institute { get; set; }
        public virtual DbSet<Block_HQ> Block_HQ { get; set; }
    }
}