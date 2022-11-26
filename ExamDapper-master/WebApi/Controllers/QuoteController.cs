using Microsoft.AspNetCore.Mvc;
[ApiController]
[Route("[controller]")]

public class QuoteController 
{
    private QuoteService _quoteService;
    public QuoteController()
    {
        _quoteService = new QuoteService();
    }
    
    [HttpGet]
    public List<Quote> GetQuotes()
    {
        return _quoteService.GetQuotes();
    }

    [HttpPost("Insert")]
    public int InsertQuotes(Quote quote)
        {
            return _quoteService.InsertQuotes(quote);
        }
    [HttpPut("Update")]

    public int UpdateQuote(Quote quote)
    {
        return _quoteService.UpdateQuote(quote);
    }

    [HttpDelete("Delete")]    
        public int DeleteQuote(int id)
        {
            return _quoteService.DeleteQuote(id);
        } 

    [HttpGet("Random")]

        public int GetRandom()
        {
            return _quoteService.GetRandom();
        }
}