using Microsoft.AspNetCore.Http;

namespace Web.Data.ViewModels.AbstractViewModels
{
    public interface IPictureVM
    {
        IFormFile Picture { get; set; }
    }
}