namespace ProductManagementService.Model.Products
{
    public class ProductDTO
    {
        public long ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public long StockQuantity { get; set; }
    }
}
