using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Tratatui
{
    public enum StaffType
    {
        Waiter,
        Chef,
        Admin
    }

    public enum TableState
    {
        Free,
        Ordering,
        Waiting,
        Calling,
        Served,
        Finished
    }

    public enum OrderType
    {
        Cleanup,
        Order,
        Request
    }

    public enum DishType
    {
        Appetiser,
        MainDish,
        SideDish,
        Dessert,
        Drink
    }

    public class Staff
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PasswordHash { get; set; }
        public ICollection<Order> Orders { get; set; }
        public StaffType Type { get; set; }
    }

    public class Table
    {
        public int Id { get; set; }
        public TableState State { get; set; }
        public ICollection<Order> Orders { get; set; }
    }

    public class Order
    {
        public int Id { get; set; }
        public TimeOnly CreationTime { get; set; }
        public OrderType Type { get; set; }
        public ICollection<Dish> Dishes { get; set; }
        [Required] public Table Table { get; set; }
    }

    public class Dish
    {
        public int Id { get; set; }
        public DishType Type { get; set; }
        public string Name {  get; set; }
        public string Description { get; set; }
        public string Recipe { get; set; }
        public decimal Price { get; set; }
        public ICollection<Order> InOrders { get; set; }
    }

    public class TratatuiContext : DbContext
    {
        public TratatuiContext(DbContextOptions<TratatuiContext> options) : base(options)
        { }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Staff> Staff {  get; set; }
    }
}


