using System.ComponentModel.DataAnnotations;

namespace EventPlus.WebAPI.DTO
{
    public class InstituicaoDTO
    {
        [Required(ErrorMessage = "blupp")]
        public string? NomeFantasia { get; set; }
        [Required(ErrorMessage = "bluppp")]
        public string? Cnpj { get; set; }
        [Required(ErrorMessage = "blupppp")]
        public string? Endereco { get; set; }

    }
}