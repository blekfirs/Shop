namespace information_system.Data_Types
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal PricePerItem { get; set; }
        public int QuantityInStock { get; set; }

        public Item(int id, string name, decimal pricePerItem, int quantityInStock)
        {
            Id = id;
            Name = name;
            PricePerItem = pricePerItem;
            QuantityInStock = quantityInStock;
        }
    }
}
