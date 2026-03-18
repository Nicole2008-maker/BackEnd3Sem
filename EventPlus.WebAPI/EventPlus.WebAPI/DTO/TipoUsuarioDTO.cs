using System.ComponentModel.DataAnnotations;

namespace EventPlus.WebAPI.DTO
{
    public class TipoUsuarioDTO
    {
        [Required(ErrorMessage = "O Titulo/Nome é obrigatorio")]
        public string? Titulo { get; set; }
    }
}
