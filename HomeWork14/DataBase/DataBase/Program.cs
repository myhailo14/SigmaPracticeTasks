using System;
using System.Data;
using System.Reflection.Metadata;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.Data.Sqlite;
using SQLitePCL;

namespace DataBase
{
    public class ProductValidTo
    {
        protected int _id;
        protected string _name;
        protected double _price;
        protected double _weight;
        protected DateOnly _validToDate;

        public string Name => _name;
        public double Price => _price;
        public double Weight => _weight;

        public DateOnly ValidToDate => _validToDate;
        public ProductValidTo()
        {
            _id = -1;
            _name = "Default product";
            _price = 1;
            _weight = 1;
            _validToDate = new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
        }
        public ProductValidTo(int id, string name, double price, double weight, DateOnly validToDate)
        {
            _id = id;
            _name = name;
            _price = price;
            _weight = weight;
            _validToDate = validToDate;
        }

        public static ProductValidTo Create(IDataRecord data)
        {
            var fullDate = Convert.ToDateTime(data["MadeDate"]).AddDays(Convert.ToDouble(data["Expiration"]));
            DateOnly dateOnly = new DateOnly(fullDate.Year, fullDate.Month, fullDate.Day);
            return new ProductValidTo(
                Convert.ToInt32(data["Id"]),
                data["Name"].ToString(),
                Convert.ToDouble(data["Price"]),
                Convert.ToDouble(data["weight"]),
                dateOnly);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append($" Name: {_name}");
            sb.Append($" Price: {_price}");
            sb.Append($" Weight: {_weight}");
            sb.Append($" Valid to: {_validToDate}");

            return sb.ToString();
        }
    }

    public class Product
    {
        protected int _id;
        protected string _name;
        protected double _price;
        protected double _weight;
        protected int _expirationTerm;
        protected DateOnly _madeDate;

        public string Name => _name;
        public double Price => _price;
        public double Weight => _weight;
        public int ExpirationTerm => _expirationTerm;
        public DateOnly MadeDate => _madeDate;
        public bool IsValid => _madeDate.AddDays(_expirationTerm) > new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

        public Product()
        {
            _id = -1;
            _name = "Default product";
            _price = 1;
            _weight = 1;
            _expirationTerm = 20;
            _madeDate = new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
        }
        public Product(int id, string name, double price, double weight, int expirationTerm, DateOnly madeDate)
        {
            _id = id;
            _name = name;
            _price = price;
            _weight = weight;
            _expirationTerm = expirationTerm;
            _madeDate = madeDate;
        }
        public static Product Create(IDataRecord data)
        {
            var fullDate = Convert.ToDateTime(data["MadeDate"]);
            DateOnly dateOnly = new DateOnly(fullDate.Year, fullDate.Month, fullDate.Day);
            return new Product(
                Convert.ToInt32(data["Id"]),
                data["Name"].ToString(),
                Convert.ToDouble(data["Price"]),
                Convert.ToDouble(data["weight"]),
                Convert.ToInt32(data["Expiration"]),
                dateOnly);
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append($" Name: {_name}");
            sb.Append($" Price: {_price}");
            sb.Append($" Weight: {_weight}");
            sb.Append($" Expiration: {_expirationTerm}");
            sb.Append($" Made date: {_madeDate}");

            return sb.ToString();
        }
    }
    static class DbHelper
    {
        public static Product GetProduct(this Db db, string name)
        {
            return db
                .GetList<Product>($"SELECT * FROM Products WHERE NAME LIKE '{name}%' LIMIT 1", Product.Create)
                .FirstOrDefault();
        }

        public static Product GetProductLinq(this Db db, string name)
        {
            return db.GetProductList().FirstOrDefault(x => x.Name == name);
        }

        public static List<Product> GetProductList(this Db db)
        {
            return db.GetList<Product>("SELECT * FROM Products", Product.Create);
        }

        public static List<ProductValidTo> GetProductValidToList(this Db db)
        {
            return db.GetList<ProductValidTo>("SELECT * FROM Products", ProductValidTo.Create);
        }
    }
    class Db
    {
        public SqliteConnection Connection;

        public Db() { }

        public Db(string connection)
        {
            this.Connection = new SqliteConnection(connection);
            this.Connection.Open();
        }

        public void ExecuteSQL(string query)
        {
            using (Connection)
            {
                Connection.Open();
                SqliteCommand command = new SqliteCommand();
                command.Connection = Connection;
                command.CommandText = query;
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public List<T> GetList<T>(string query, Func<IDataRecord, T> generator)
        {
            var resultList = new List<T>();
            using (Connection)
            {
                Connection.Open();
                SqliteCommand command = new SqliteCommand(query, Connection);
                try
                {
                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            resultList.Add(generator(reader));
                        }
                    }
                }
                catch
                {
                    return null;
                }
            }

            return resultList;
        }
    }
    internal class Program
    {
        public static void Main(string[] args)
        {
            Db db = new Db("Data Source=ProductDataBase.db");
            Console.WriteLine("List");
            foreach (var product in db.GetProductList())
            {
                Console.WriteLine(product);
            }
            db.ExecuteSQL($"INSERT INTO Products (Name, Price, Weight, Expiration, MadeDate) VALUES (\"Mango\", 40, 0.3, 3, \"30/12/2021\" ); SELECT * FROM Products");

            do
            {
                Console.WriteLine("Do you want to add record to base?");
                char.TryParse(Console.ReadLine(), out char answer);
                if (answer == 'y')
                {
                    Console.WriteLine("Enter product name: ");
                    string name = Console.ReadLine();
                    double price = 0;
                    double weight = 0;
                    int expirationTerm = 0;
                    //DateOnly madeDate = new DateOnly();
                    Console.WriteLine("Enter product price: ");
                    while (!double.TryParse(Console.ReadLine(), out price))
                    {
                        Console.WriteLine("Try again");
                    }
                    Console.WriteLine("Enter product weight: ");
                    while (!double.TryParse(Console.ReadLine(), out weight))
                    {
                        Console.WriteLine("Try again");
                    }
                    Console.WriteLine("Enter expiration term: ");
                    while (!int.TryParse(Console.ReadLine(), out expirationTerm))
                    {
                        Console.WriteLine("Try again");
                    }
                    Console.WriteLine("Enter manufacture date: ");
                    string madeDate =  Console.ReadLine();
                    while (!Regex.IsMatch(madeDate, @"^([0-2][0-9]|3[0-1])\\(0[1-9]|1[0-2])\\\d{4}")) 
                    {
                        Console.WriteLine("Try again (dd/mm/yyyy");
                    }
                    db.ExecuteSQL($"INSERT INTO Products (Name, Price, Weight, Expiration, MadeDate) VALUES (\"{name}\", {price}, {weight}, {expirationTerm}, \"{madeDate}\" ); SELECT * FROM Products");
                }
                else
                {
                    break;
                }
            } while (true);

            Console.WriteLine("Valid to  list");
            foreach (var product in db.GetProductValidToList())
            {
                Console.WriteLine(product);
            }
        }
    }
}
