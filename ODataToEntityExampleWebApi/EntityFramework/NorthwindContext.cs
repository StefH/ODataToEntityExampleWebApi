using Microsoft.EntityFrameworkCore;

namespace ODataToEntityExampleWebApi.EntityFramework
{
    /// <summary>
    /// Copied from https://raw.githubusercontent.com/akorchev/blazor.radzen.com/master/Data/NorthwindContext.cs
    /// </summary>
    public class NorthwindContext : DbContext
    {
        public NorthwindContext(DbContextOptions<NorthwindContext> options)
            : base(options)
        {
        }

        void OnModelBuilding(ModelBuilder builder)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<CustomerCustomerDemo>().HasKey(table => new
            {
                table.CustomerID,
                table.CustomerTypeID
            });

            builder.Entity<EmployeeTerritory>().HasKey(table => new
            {
                table.EmployeeID,
                table.TerritoryID
            });

            builder.Entity<OrderDetail>().HasKey(table => new
            {
                table.OrderID,
                table.ProductID
            });

            builder.Entity<CustomerCustomerDemo>()
                  .HasOne(i => i.Customer)
                  .WithMany(i => i.CustomerCustomerDemos)
                  .HasForeignKey(i => i.CustomerID)
                  .HasPrincipalKey(i => i.CustomerID);

            builder.Entity<CustomerCustomerDemo>()
                  .HasOne(i => i.CustomerDemographic)
                  .WithMany(i => i.CustomerCustomerDemos)
                  .HasForeignKey(i => i.CustomerTypeID)
                  .HasPrincipalKey(i => i.CustomerTypeID);

            builder.Entity<EmployeeTerritory>()
                  .HasOne(i => i.Employee)
                  .WithMany(i => i.EmployeeTerritories)
                  .HasForeignKey(i => i.EmployeeID)
                  .HasPrincipalKey(i => i.EmployeeID);

            builder.Entity<EmployeeTerritory>()
                  .HasOne(i => i.Territory)
                  .WithMany(i => i.EmployeeTerritories)
                  .HasForeignKey(i => i.TerritoryID)
                  .HasPrincipalKey(i => i.TerritoryID);

            builder.Entity<Order>()
                  .HasOne(i => i.Customer)
                  .WithMany(i => i.Orders)
                  .HasForeignKey(i => i.CustomerID)
                  .HasPrincipalKey(i => i.CustomerID);

            builder.Entity<Order>()
                  .HasOne(i => i.Employee)
                  .WithMany(i => i.Orders)
                  .HasForeignKey(i => i.EmployeeID)
                  .HasPrincipalKey(i => i.EmployeeID);

            builder.Entity<OrderDetail>()
                  .HasOne(i => i.Order)
                  .WithMany(i => i.OrderDetails)
                  .HasForeignKey(i => i.OrderID)
                  .HasPrincipalKey(i => i.OrderID);

            builder.Entity<OrderDetail>()
                  .HasOne(i => i.Product)
                  .WithMany(i => i.OrderDetails)
                  .HasForeignKey(i => i.ProductID)
                  .HasPrincipalKey(i => i.ProductID);

            builder.Entity<Product>()
                  .HasOne(i => i.Supplier)
                  .WithMany(i => i.Products)
                  .HasForeignKey(i => i.SupplierID)
                  .HasPrincipalKey(i => i.SupplierID);

            builder.Entity<Product>()
                  .HasOne(i => i.Category)
                  .WithMany(i => i.Products)
                  .HasForeignKey(i => i.CategoryID)
                  .HasPrincipalKey(i => i.CategoryID);

            builder.Entity<Territory>()
                  .HasOne(i => i.Region)
                  .WithMany(i => i.Territories)
                  .HasForeignKey(i => i.RegionID)
                  .HasPrincipalKey(i => i.RegionID);

            builder.Entity<Order>()
                  .Property(p => p.Freight)
                  .HasDefaultValueSql("(0)");

            builder.Entity<OrderDetail>()
                  .Property(p => p.UnitPrice)
                  .HasDefaultValueSql("(0)");

            builder.Entity<OrderDetail>()
                  .Property(p => p.Quantity)
                  .HasDefaultValueSql("(1)");

            builder.Entity<OrderDetail>()
                  .Property(p => p.Discount)
                  .HasDefaultValueSql("(0)");

            builder.Entity<Product>()
                  .Property(p => p.UnitPrice)
                  .HasDefaultValueSql("(0)");

            builder.Entity<Product>()
                  .Property(p => p.UnitsInStock)
                  .HasDefaultValueSql("(0)");

            builder.Entity<Product>()
                  .Property(p => p.UnitsOnOrder)
                  .HasDefaultValueSql("(0)");

            builder.Entity<Product>()
                  .Property(p => p.ReorderLevel)
                  .HasDefaultValueSql("(0)");

            builder.Entity<Product>()
                  .Property(p => p.Discontinued)
                  .HasDefaultValueSql("(0)");

            OnModelBuilding(builder);
        }


        public DbSet<Category> Categories
        {
            get;
            set;
        }

        public DbSet<Customer> Customers
        {
            get;
            set;
        }

        public DbSet<CustomerCustomerDemo> CustomerCustomerDemos
        {
            get;
            set;
        }

        public DbSet<CustomerDemographic> CustomerDemographics
        {
            get;
            set;
        }

        public DbSet<Employee> Employees
        {
            get;
            set;
        }

        public DbSet<EmployeeTerritory> EmployeeTerritories
        {
            get;
            set;
        }

        public DbSet<Order> Orders
        {
            get;
            set;
        }

        public DbSet<OrderDetail> OrderDetails
        {
            get;
            set;
        }

        public DbSet<Product> Products
        {
            get;
            set;
        }

        public DbSet<Region> Regions
        {
            get;
            set;
        }

        public DbSet<Supplier> Suppliers
        {
            get;
            set;
        }

        public DbSet<Territory> Territories
        {
            get;
            set;
        }
    }
}