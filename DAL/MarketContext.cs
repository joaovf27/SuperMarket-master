using DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace DAL
{
    public class MarketContext : DbContext
    {
        public MarketContext()
        {

        }
        public MarketContext(DbContextOptions options) : base(options)
        {

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    //optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MarketWEB;Integrated Security=True;Connect Timeout=30");


        //}
        public DbSet<BrandDTO> Brands { get; set; }
        public DbSet<CategoryDTO> Categories { get; set; }
        public DbSet<ClientDTO> Clients { get; set; }
        public DbSet<EmployeeDTO> Employees { get; set; }
        public DbSet<ProductDTO> Products { get; set; }
        public DbSet<ProviderDTO> Providers { get; set; }
        public DbSet<SaleDTO> Sales { get; set; }
        public DbSet<UserDTO> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            LoadStringConfig(modelBuilder);




            base.OnModelCreating(modelBuilder);

        }
        private void LoadStringConfig(ModelBuilder modelBuilder)
        {
            //Assembly assemblyDTO = Assembly.GetAssembly(typeof(BrandDTO));

            //List<Type> types = assemblyDTO.GetTypes().Where(c => c.Namespace == "DTO").ToList();

            //foreach (Type item in types)
            //{
            //    foreach (PropertyInfo propriedade in item.GetProperties().Where(c=> c.PropertyType == typeof(string)))
            //    {
            //        modelBuilder.Entity(item.Name).Property(propriedade.Name).IsRequired().IsUnicode(false);
            //    }
            //}

        }
    }
}
