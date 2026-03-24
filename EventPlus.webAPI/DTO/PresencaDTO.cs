namespace EventPlus.webAPI.DTOs
{
    public class PresencaDTO
    {
        public Guid IdUsuario { get; set; }
        public Guid IdEvento { get; set; }
        public bool Situacao { get; set; }
    }
}