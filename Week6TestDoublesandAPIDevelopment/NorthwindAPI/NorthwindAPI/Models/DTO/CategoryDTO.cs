namespace NorthwindAPI.Models;

public class CategoryDTO
{
    public CategoryDTO()
    {
        Products = new List<ProductDTO>();
    }
    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public string? Description { get; set; }

    public ICollection<ProductDTO> Products { get; set; }
}
