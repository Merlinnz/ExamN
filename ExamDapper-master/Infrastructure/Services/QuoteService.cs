using Dapper;
using Npgsql;

public class QuoteService
{
    private string _connectionString = "Server=127.0.0.1;Port=5432;Database=NExam;User Id=postgres;Password=sqlj123;";
    public List<Quote> GetQuotes()
    {
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            string sql = "SELECT * FROM Quotes";
            var result = connection.Query<Quote>(sql).ToList();
            return result;
        }
    }

    public int InsertQuotes(Quote quote)
    {
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            string sql = $"INSERT INTO Quotes (Author, QuoteText, CategoryId) Values ('{quote.Author}', '{quote.QuoteText}', {quote.CategoryId})";
            var result = connection.Execute(sql);
            return result;
        }
    }

    public int UpdateQuote(Quote quote)
    {
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            string sql = $"Update Quotes Set" +
            $"Author = '{quote.Author}', " +
            $"QuoteText = '{quote.QuoteText}', " +
            $"Author = {quote.CategoryId}, " +
            $"Where id = {quote.id}"; 

            var result = connection.Execute(sql);

            return result;
        }
    }
     public int DeleteQuote(int id)
    {
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            var sql = $"Delete from Quotes Where id = {id}";
            var result = connection.Execute(sql);
            return result;
        }
    }

    public int GetRandom()
    {
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            string sql = $"Select * from Quotes Order by random() limit 1;";
            var result = connection.Execute(sql);
            return result;
        }
    }
}
