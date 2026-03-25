using Azure;
using Azure.AI.ContentSafety;
using EventPlus.WebAPI.DTO;
using EventPlus.WebAPI.Interface;
using EventPlus.WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlTypes;

namespace EventPlus.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ComentarioEventoController : ControllerBase
{

    private readonly IComentarioEventoRepository _comentarioEventoRepository;


    private readonly ContentSafetyClient _contentSafetyClient;

    public ComentarioEventoController(ContentSafetyClient contentSafetyClient, IComentarioEventoRepository comentarioEventoRepository)
    {
        _comentarioEventoRepository = comentarioEventoRepository;
        _contentSafetyClient = contentSafetyClient;
    }

    [HttpGet]
    public IActionResult Listar()
    {
        try
        {
            return Ok(_comentarioEventoRepository.Listar());
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    
    [HttpGet("BuscarPorIdUsuario")]
    public IActionResult BuscarPorIdUsuario(Guid IdUsuario)
    {
        try
        {
            return Ok(_comentarioEventoRepository.BuscarPorIdUsuario(IdUsuario));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }




    [HttpGet("ListarSomenteExibe")]
    public IActionResult ListarSomenteExibe(Guid IdEvento)
    {
        try
        {
            return Ok(_comentarioEventoRepository.ListarSomenteExibe(IdEvento));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Post(ComentarioEventoDTO comentarioEvento)
    {
        try
        {
            if (String.IsNullOrEmpty(comentarioEvento.Descricao))
            {
                return BadRequest("A descrição do comentário não pode ser vazia.");
            }

           
            var request = new AnalyzeTextOptions(comentarioEvento.Descricao);

            Response<AnalyzeTextResult> response = await _contentSafetyClient.AnalyzeTextAsync(request);

            bool temConteudoImpropio = response.Value.CategoriesAnalysis.Any(c => c.Severity > 0);

            var novoComentario = new ComentarioEvento
            {
                Descricao = comentarioEvento.Descricao,
                IdUsuario = comentarioEvento.IdUsuario,
                IdEvento = comentarioEvento.IdEvento,
                Exibe = !temConteudoImpropio, 
                DataComentarioEvento = DateTime.Now
            };

            _comentarioEventoRepository.Cadastrar(novoComentario);
            return StatusCode(201, novoComentario);
        }
        catch (Exception e)
        {

            return BadRequest(e.Message);
        }
    }
    
    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        try
        {
            _comentarioEventoRepository.Deletar(id);
            return NoContent();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}