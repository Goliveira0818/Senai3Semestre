using System.ComponentModel.DataAnnotations;

namespace EventPlus.webAPI.DTO
{
    public class TipoUsuarioDTO
    {
    [Required(ErrorMessage = "O titulo do tipo de usuario e obrigatorio!")]
    public string? Titulo { get; set; }
    }
}

