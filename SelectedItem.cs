namespace information_system.Data_Types
{
    public class SelectedItem : Item
    {
        public int SelectedQuantity { get; set; }

        public SelectedItem(int id, string name, decimal pricePerItem, int quantityInStock, int selectedQuantity)
            : base(id, name, pricePerItem, quantityInStock)
        {
            SelectedQuantity = selectedQuantity;
        }
    }
}
