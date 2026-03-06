namespace FilmesMoura1.WebAPI.DTO;

public class FilmeDTO
{
    public string? Titulo { get; set; }
    public IFormFile? Imagem { get; set; }
    public Guid? IdGenero { get; set; }

}
