using System;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using Org.BouncyCastle.Crypto.Agreement;
using ORM_Dapper;

var config = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();
string connString = config.GetConnectionString("DefaultConnection");
IDbConnection conn = new MySqlConnection(connString);

//var dapperDepartmentRepo = new DapperDepartmentRepo(conn);

//dapperDepartmentRepo.InsertDepartment("CSharp-50");
//
// var departments = dapperDepartmentRepo.GetAllDepartments();
//
// foreach (var dep in departments)
// {
//     Console.WriteLine($"Name: {dep.Name} | ID: {dep.DepartmentID}");
// }

var productRepo = new DapperProductRepo(conn);

// productRepo.CreateProduct("Cortado", 5.00, 10, false, 20);

// productRepo.UpdateProduct("Iphone20", 999, 8, false, 200, 940);

// productRepo.DeleteProduct(940);

var products = productRepo.GetAllProducts();

foreach (var prod in products)
{
    Console.WriteLine($"ID: {prod.ProductID} | Name: {prod.Name} | Price: {prod.Price} | Category ID: {prod.CategoryID} | IsOnSale: {prod.OnSale} | StockLevel: {prod.StockLevel}");
}