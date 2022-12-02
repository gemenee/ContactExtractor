using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BlazorWebApplication;

public class BufferedSingleFileUploadDbModel : PageModel
{
    [BindProperty]
    public BufferedSingleFileUploadDb FileUpload { get; set; }
}

public class BufferedSingleFileUploadDb
{
    [Required]
    [Display(Name = "File")]
    public IFormFile FormFile { get; set; }
}