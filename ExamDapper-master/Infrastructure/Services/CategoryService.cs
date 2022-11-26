using Dapper;
using Npgsql;

public class CategoryService
{
    private string _connectionString = "Server=127.0.0.1;Port=5432;Database=NExam;User Id=postgres;Password=sqlj123;";
    public List<Category> GetCategory()
    {
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            string sql = "SELECT * FROM Categories";
            var result = connection.Query<Category>(sql).ToList();
            return result;
        }
    }

    public int InsertCategory(Category category)
    {
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            string sql = $"INSERT INTO Categories (categoryName) Values ('{category.CategoryName}')";
            var result = connection.Execute(sql);
            return result;
        }
    }

    public int UpdateCategory(Category category)
    {
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            string sql = $"Update Categories Set" +
            $"categoryName = '{category.CategoryName}', " +
            $"Where id = {category.Id}"; 

            var result = connection.Execute(sql);

            return result;
        }
    }
    public int DeleteCategory(int id)
    {
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            string sql = $"Delete from Categories Where id = {id}";
            var result = connection.Execute(sql);
            return result;
        }
    }
}
