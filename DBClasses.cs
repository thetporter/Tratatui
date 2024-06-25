using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Linq.Expressions;
using System.ComponentModel.Design;

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
        Drink,
        Other
    }

    public class Staff
    {
        public int Id { get; set; }
        public string Name { get; set; }
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
        public bool Active { get; set; }
        public TimeOnly CreationTime { get; set; }
        public OrderType Type { get; set; }
        public ICollection<Dish> Dishes { get; set; }
        [Required] public Table Table { get; set; }
        public int Status { get; set; }

        public override string ToString()
        {
            return $"Заказ {Id.ToString()} от столика {Table.Id.ToString()} типа {Type.ToString()}, сделанный в {CreationTime.ToString()}.";
        }
    }

    public static class StatusConverter
    {
        public static string Do(int status)
        {
            string readiness;
            switch (status)
            {
                case 1: readiness = "Начали готовить!"; break;
                case 2: readiness = "Варим, жарим, парим..."; break;
                case 3: readiness = "Финальные штрихи!"; break;
                case 4: readiness = "Сейчас принесем!"; break;
                default:
                    readiness = "Приступаем...";
                    break;
            }
            return readiness;
        }
    }

    public class Dish
    {
        public Dish() { }
        public Dish(int Id, DishType Type, string Name, string Description, string Recipe, decimal Price)
        {
            this.Id = Id;
            this.Type = Type;
            this.Name = Name;
            this.Description = Description; 
            this.Recipe = Recipe;
            this.Price = Price;
        }
        public int Id { get; set; }
        public DishType Type { get; set; }
        public string Name {  get; set; }
        public string Description { get; set; }
        public string Recipe { get; set; }
        public decimal Price { get; set; }
        public ICollection<Order> InOrders { get; set; }
    }

    public class DishorderLink
    {
        public int DishId { get; set; }
        public Dish Dish { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int Amount { get; set; }
    }

    public class TratatuiContext : DbContext
    {
        public TratatuiContext(DbContextOptions<TratatuiContext> options) : base(options)
        { }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Staff> Staff {  get; set; }
        public DbSet<DishorderLink> DishOrder {  get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .HasMany(e => e.Dishes)
                .WithMany(e => e.InOrders)
                .UsingEntity<DishorderLink>();
            modelBuilder.Entity<DishorderLink>()
                .HasKey(e => new { e.OrderId, e.DishId });

            modelBuilder.Entity<Dish>()
                .Property(d => d.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Staff>()
                .Property(s => s.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Order>()
                .Property(o => o.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Dish>()
                .HasIndex(d => d.Name)
                .IsUnique();
        }
    }

    public static partial class DB {
        public static readonly TratatuiContext Database = new TratatuiContext(
                new DbContextOptionsBuilder<TratatuiContext>()
                    .UseSqlite("Filename=../../../Tratatui.db")
                    .Options);

        public static void InitializeDB ()
        {
            //Пользователь с правами доступа администратора, кодом 1 и паролем admin
            if (DB.Database.Staff.Find(1) == null)
            {
                Staff admin = new Staff();
                admin.Name = "admin";
                admin.Id = 1;
                admin.PasswordHash = Encrypter.Encrypt("admin", null);
                admin.Type = StaffType.Admin;
                DB.Database.Add(admin);
                DB.Database.SaveChanges();
            }

            #region Столы - проверить наличие, сбросить состояние при невозможности изменения стандартным образом
            //Проверка на добавление
            DB.Database.Tables.RemoveRange(from table in DB.Database.Tables where table.Id > 16 select table);
            for (int i = 1; i <= 16; i++)
            {
                //Проверка на удаление
                if (DB.Database.Tables.Find(i) == null)
                {
                    //Создать, если нет
                    Table table = new Table();
                    table.Id = i;
                    table.State = TableState.Free;
                    DB.Database.Tables.Add(table);
                }
                else
                {
                    //Перевести в стандартное или изменяемое состояние при неизменяемом состоянии
                    Table table = DB.Database.Tables.Include(t => t.Orders).Where(t => t.Id == i).First();
                    if (table.State == TableState.Ordering) table.State = TableState.Free;
                    if (table.State == TableState.Calling && !table.Orders.Where(o => OrderType.Request == o.Type).Any()) table.State = TableState.Waiting;
                    if (table.State == TableState.Waiting && !table.Orders.Where(o => OrderType.Order == o.Type).Any()) table.State = TableState.Free;
                    if (table.State == TableState.Served && !Application.OpenForms.OfType<FinishForm>()
                                                            .Where(ff => ff.table == table).Any())
                    {
                        table.State = TableState.Finished;
                        Order ord = new Order();
                        ord.Type = OrderType.Cleanup;
                        ord.Table = table;
                        ord.Status = 0;
                        ord.Active = true;
                        ord.CreationTime = TimeOnly.Parse(DateTime.Now.TimeOfDay.ToString());
                        DB.Database.Orders.Add(ord);
                    }
                    if (table.State == TableState.Finished && !table.Orders.Where(o => OrderType.Cleanup == o.Type).Any()) table.State = TableState.Free;

                }
            }
            DB.Database.SaveChanges();
            #endregion

            //Стандартные блюда
            if (DB.Database.Dishes.Count() < 6)
            {
                if (DB.Database.Dishes.Find(1) == null)
                {
                    Dish d = new Dish(1, DishType.Appetiser, "Салат Цезарь", "Легкий классический салат с курицей",
                    "Взять все, что есть в холодильнике (кроме котлет), скидать вместе и перемешать", (decimal)19.99);
                    DB.Database.Dishes.Add(d);
                    DB.Database.SaveChanges();
                }
                if (DB.Database.Dishes.Find(2) == null){
                    Dish d = new Dish(2, DishType.MainDish, "Котлета от шеф-повара", "Большая, сочная котлета из говядины",
                    "Достать из холодильника, разогреть на сковородке", (decimal)24.99);
                    DB.Database.Dishes.Add(d);
                    DB.Database.SaveChanges();
                }
                if (DB.Database.Dishes.Find(3) == null) {
                    Dish d = new Dish(3, DishType.SideDish, "Отварной картофель", "Молодая картошечка, сваренная со специями и подающаяся с зеленью",
                    "Берем картоху, варим с солью, посыпаем укропчиком, подаем", (decimal)17.99);
                    DB.Database.Dishes.Add(d);
                    DB.Database.SaveChanges();
                }
                if (DB.Database.Dishes.Find(4) == null)
                {
                    Dish d = new Dish(4, DishType.Dessert, "Мороженое", "Шарик пломбира с шариком шоколадного мороженого, политые шоколадом",
                    "Достать мороженое из морозилки, сделать шарик того, шарик другого, побрызгать соусом", (decimal)19.99);
                    DB.Database.Dishes.Add(d);
                    DB.Database.SaveChanges();
                }
                if (DB.Database.Dishes.Find(5) == null)
                {
                    Dish d = new Dish(5, DishType.Drink, "Яблочный сок", "Свежий сок из отборных яблок",
                    "Налить Доброго в стакан", (decimal)9.99);
                    DB.Database.Dishes.Add(d);
                    DB.Database.SaveChanges();
                }
                if (DB.Database.Dishes.Find(6) == null)
                {
                    Dish d = new Dish(6, DishType.Other, "Хлеб (3 ломтика)", "Мягкий, свежий хлеб",
                    "Отрезать два куска хлеба, разрезать напополам, один оставить, подавать в хлебнице", (decimal)1.99);
                    DB.Database.Dishes.Add(d);
                    DB.Database.SaveChanges();
                }
            }
        }
    }
}


