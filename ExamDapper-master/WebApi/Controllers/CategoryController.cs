using Microsoft.AspNetCore.Mvc;
[ApiController]
[Route("[controller]")]

public class CategoryController 
{
    private CategoryService _categoryService;
    public CategoryController()
    {
        _categoryService = new CategoryService();
    }
    
    [HttpGet]
    public List<Category> GetCategory()
    {
        return _categoryService.GetCategory();
    }

    [HttpPost("Insert")]
    public int InsertCategory(Category category)
        {
            return _categoryService.InsertCategory(category);
        }
    [HttpPut("Update")]

    public int UpdateCategory(Category category)
    {
        return _categoryService.UpdateCategory(category);
    }

    [HttpDelete("Delete")]    
        public int DeleteCategory(int id)
        {
            return _categoryService.DeleteCategory(id);
        } 
}