using ZstdSharp.Unsafe;

namespace ORM_Dapper;

public interface IProductRepository
{
    public IEnumerable<Product> GetAllProducts();       //SELECT ALL method
    public void CreateProduct(string name, double price, int categoryID, bool onSale, int stockLevel);
    public void UpdateProduct(string name, double price, int categoryID, bool onSale, int stockLevel, int productID);
    public void DeleteProduct(int productID);
}