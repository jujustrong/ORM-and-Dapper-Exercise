namespace ORM_Dapper;

//Determines how we are going to control the Department class

public interface IDepartmentRepository
{
    public IEnumerable<Department> GetAllDepartments();
    public void InsertDepartment(string newDepartmentName);
}