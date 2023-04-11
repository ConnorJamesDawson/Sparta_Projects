using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace SpartaToDo.App.Models;

public class CreateToDoVM
{
    [Required(ErrorMessage = "Title is Required")]
    [StringLength(50)]
    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    [Display(Name = "Complete?")]
    public bool Complete { get; set; }
}
