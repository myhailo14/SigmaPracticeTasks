using System;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using Task1;
using Task1.Classes;

namespace Task1
{
    public abstract class StorageDecorator : IStorage
    {
        protected IStorage _storage;

        protected StorageDecorator(IStorage storage)
        {
            _storage = storage;
        }

        public abstract void AddProduct(Product product);
        public abstract void RemoveProduct(Product product);
    }

    public class AddRemoveWitLimits : StorageDecorator
    {
        public AddRemoveWitLimits(IStorage storage) : base(storage)
        {
        }

        public override void AddProduct(Product product)
        {
            if (product.IsValid == true)
            {
                _storage.AddProduct(product);
            }
            else
            {

            }
           
            
        }

        public override void RemoveProduct(Product product)
        {
            _storage.RemoveProduct(product);
        }

       
    }


    class Program
    {
        private static void Main(string[] args)
        {
            IStorage storage = new Storage(@"C:\Users\mykha\Desktop\Sigma_School\homework\HomeWork13\Task1\Task1\productList.txt");
            IStorage storageAdderRemover = new AddRemoveWitLimits(storage);
            storageAdderRemover.AddProduct(new Product("brevno", 10, 20, 55, DateTime.Now));
            Console.WriteLine("Product added");
        }
    }
}

