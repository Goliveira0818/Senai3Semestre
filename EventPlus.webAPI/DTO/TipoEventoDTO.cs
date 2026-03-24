using System.ComponentModel.DataAnnotations;

namespace EventPlus.webAPI.DTO;

public class TipoEventoDTO
{
    [Required(ErrorMessage = "O titulo do tipo de eventos e obrigatorio!")]
    public string? Titulo { get; set; }
}
