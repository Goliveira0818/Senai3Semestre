using System.ComponentModel.DataAnnotations;

namespace EventPlus.webAPI.DTO
{
    public class InstituicaoDTO
    {
        [Required(ErrorMessage = "O titulo do tipo de instituicao e obrigatorio!")]
        public string? NomeFantasia { get; set; }

        public string? Cnpj { get; set; }

        public string? Endereco {  get; set; }
    }
}