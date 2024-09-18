using System.Data;
using Dapper;

namespace ORM_Dapper;

public class DapperDepartmentRepo : IDepartmentRepository
{
    //We need a database connection in order to use Dapper
    //readonly cannot be changed or edited, only read
    private readonly IDbConnection _connection;

    public DapperDepartmentRepo(IDbConnection connection)          //We NEED a database connection, so we are forcing the user to
    {                                                              //give a database connection in order to make a department.
        _connection = connection;
    }

    public IEnumerable<Department> GetAllDepartments()
    {
        return _connection.Query<Department>("SELECT * FROM departments;");
    }

    public void InsertDepartment(string newDepartmentName)
    {
        _connection.Execute("INSERT INTO departments (Name) VALUES (@newDepartmentName)", new {newDepartmentName});
    }
}