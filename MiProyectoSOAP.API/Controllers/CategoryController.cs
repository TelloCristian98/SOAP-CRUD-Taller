using Microsoft.AspNetCore.Mvc;
using MiProyectoSOAP.Contrato;
using MiProyectoEntities;

[ApiController]
[Route("soap/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _service;

    public CategoryController(ICategoryService service)
    {
        _service = service;
    }

    [HttpGet("GetAll")]
    public IActionResult GetAllCategories()
    {
        var categories = _service.GetAllCategories();
        return Ok(categories);
    }

    [HttpGet("GetById/{id}")]
    public IActionResult GetCategoryById(int id)
    {
        var category = _service.GetCategoryById(id);
        if (category == null) return NotFound();
        return Ok(category);
    }

    [HttpPost("Create")]
    public IActionResult CreateCategory(Category category)
    {
        var newCategory = _service.CreateCategory(category);
        return CreatedAtAction(nameof(GetCategoryById), new { id = newCategory.categoryid }, newCategory);
    }

    [HttpPut("Update/{id}")]
    public IActionResult UpdateCategory(int id, Category category)
    {
        var updatedCategory = _service.UpdateCategory(id, category);
        if (updatedCategory == null) return NotFound();
        return Ok(updatedCategory);
    }

    [HttpDelete("Delete/{id}")]
    public IActionResult DeleteCategory(int id)
    {
        var result = _service.DeleteCategory(id);
        if (!result) return NotFound();
        return NoContent();
    }
}