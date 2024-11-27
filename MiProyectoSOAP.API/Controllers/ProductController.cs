using Microsoft.AspNetCore.Mvc;
using MiProyectoSOAP.Contrato;
using MiProyectoEntities;

[ApiController]
[Route("soap/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _service;

    public ProductController(IProductService service)
    {
        _service = service;
    }

    [HttpGet("GetAll")]
    public IActionResult GetAllProducts()
    {
        var products = _service.GetAllProducts();
        return Ok(products);
    }

    [HttpGet("GetById/{id}")]
    public IActionResult GetProductById(int id)
    {
        var product = _service.GetProductById(id);
        if (product == null) return NotFound();
        return Ok(product);
    }

    [HttpPost("Create")]
    public IActionResult CreateProduct(Product product)
    {
        var newProduct = _service.CreateProduct(product);
        return CreatedAtAction(nameof(GetProductById), new { id = newProduct.productid }, newProduct);
    }

    [HttpPut("Update/{id}")]
    public IActionResult UpdateProduct(int id, Product product)
    {
        var updatedProduct = _service.UpdateProduct(id, product);
        if (updatedProduct == null) return NotFound();
        return Ok(updatedProduct);
    }

    [HttpDelete("Delete/{id}")]
    public IActionResult DeleteProduct(int id)
    {
        var result = _service.DeleteProduct(id);
        if (!result) return NotFound();
        return NoContent();
    }
}