using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace SpartaToDo.App.Models;

public class EditToDoVM
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Title is Required")]
    [StringLength(50)]
    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    [Display(Name = "Complete?")]
    public bool Complete { get; set; }
}
