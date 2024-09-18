using System.Data;
using Dapper;

namespace ORM_Dapper;

public class DapperProductRepo : IProductRepository
{
    private readonly IDbConnection _connection;

    public DapperProductRepo(IDbConnection connection)
    {
        _connection = connection;
    }
    
    public IEnumerable<Product> GetAllProducts()
    {
        return _connection.Query<Product>("SELECT * FROM products;");
    }

    public void CreateProduct(string name, double price, int categoryID, bool onSale, int stockLevel)
    {
        _connection.Execute("INSERT INTO products (Name, Price, CategoryID, OnSale, StockLevel) " +
                            "VALUES (@name, @price, @categoryID, @onSale, @stockLevel)", 
                        new {name, price, categoryID, onSale, stockLevel});
    }

    public void UpdateProduct(string name, double price, int categoryID, bool onSale, int stockLevel, int productID)
    {
        _connection.Execute("UPDATE products SET Name = @name, Price = @price, CategoryID = @categoryID, OnSale = @onSale, StockLevel = @stockLevel WHERE ProductID = @productID", 
            new {name, price, categoryID, onSale, stockLevel, productID});
    }

    public void DeleteProduct(int productID)
    {
        //delete from foreign tables first before the original table so that we avoid ghost data or we miss a tale.
        _connection.Execute("DELETE FROM reviews WHERE ProductID = @productID", new {productID});
        _connection.Execute("DELETE FROM sales WHERE ProductID = @productID", new {productID});
        _connection.Execute("DELETE FROM products WHERE ProductID = @productID", new {productID});
    }
}