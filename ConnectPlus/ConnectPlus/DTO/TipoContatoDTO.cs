using System.ComponentModel.DataAnnotations;

namespace ConnectPlus.DTO;

public class TipoContatoDTO
{
    [Required(ErrorMessage = "Tipo de contato é obrigatório!")]
    public string? Titulo { get; set; }
}