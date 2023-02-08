using information_system.Data_Types;
using information_system.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace information_system.Roles
{
    internal class WarehouseManager
    {
        private List<Item> items;
        private string filePath = Environment.CurrentDirectory + "\\items.json";

        public WarehouseManager(string filePath)
        {
            this.filePath = filePath;
            items = SerializationDeserialization.Deserialize<Item>(filePath);
        }

        public void ShowAllItems()
        {
            Console.WriteLine("All items in the warehouse: ");
            for (int i = 0; i < items.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {items[i].Name}");
            }
        }

        public void ViewItemDetails()
        {
            Console.WriteLine("Enter the number of the item you want to view: ");
            int itemIndex = int.Parse(Console.ReadLine()) - 1;
            Item selectedItem = items[itemIndex];
            Console.WriteLine($"Name: {selectedItem.Name}");
            Console.WriteLine($"Id: {selectedItem.Id}");
            Console.WriteLine($"Equals: {selectedItem.Equals}");
            Console.WriteLine($"PricePerItem: {selectedItem.PricePerItem}");
        }

        public void CreateItem()
        {
            Console.WriteLine("Enter the name of the item: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter the description of the item: ");
            string description = Console.ReadLine();
            Console.WriteLine("Enter the price of the item: ");
            double price = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter the quantity of the item: ");
            int quantity = int.Parse(Console.ReadLine());
            //Item newItem = new Item(name, description, price, quantity);
            //items.Add(newItem);
            //SerializationDeserialization.Serialize(items, filePath);
        }

        /*public void UpdateItem()
        {
            Console.WriteLine("Enter the number of the item you want to update: ");
            int itemIndex = int.Parse(Console.ReadLine()) - 1;
            Item selectedItem = items[itemIndex];
            Console.WriteLine("Enter the new name of the item: ");
            selectedItem.Name = Console.ReadLine();
            Console.WriteLine("Enter the new description of the item: ");
            selectedItem.Description = Console.ReadLine();
            Console.WriteLine("Enter the new price of the item: ");
            selectedItem.Price = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter the new quantity of the item: ");
            selectedItem.Quantity = int.Parse(Console.ReadLine());
            SerializationDeserialization.Serialize(items, filePath);
        }*/

        public void DeleteItem()
        {
            Console.WriteLine("Enter the number of the item you want to delete: ");
            int itemIndex = int.Parse(Console.ReadLine()) - 1;
            items.RemoveAt(itemIndex);
            SerializationDeserialization.Serialize(items, filePath);
        }
    }
}
