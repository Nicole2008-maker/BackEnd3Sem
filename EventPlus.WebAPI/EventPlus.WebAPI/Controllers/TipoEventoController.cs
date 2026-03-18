using EventPlus.WebAPI.DTO;
using EventPlus.WebAPI.Interface;
using EventPlus.WebAPI.Models;
using EventPlus.WebAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventPlus.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoEventoController : ControllerBase
    {
        private ITipoEventoRepository _tipoEventoRepository;

        public TipoEventoController(ITipoEventoRepository tipoEventoRepository)
        {
            _tipoEventoRepository = tipoEventoRepository;
        }
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_tipoEventoRepository.Listar());
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(Guid id)
        {
            try
            {
                return Ok(_tipoEventoRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }

        }

        [HttpPost]
        public IActionResult Cadastrar(TipoEventoDTO tipoEvento)
        {
            try
            {
                var novoTipoEvento = new TipoEvento
                {
                    Titulo = tipoEvento.Titulo!
                };

                _tipoEventoRepository.Cadastrar(novoTipoEvento);
                return StatusCode(201, novoTipoEvento);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }
        [HttpPut("{id}")]
        public IActionResult Atualizar(Guid id, TipoEvento tipoEvento)
        {            try
            {
                var tipoEventoAtualizado = new TipoEvento
                {
                    Titulo = tipoEvento.Titulo!

                };
                _tipoEventoRepository.Atualizar(id, tipoEvento);
                return StatusCode(204, tipoEvento);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }
        [HttpDelete("{id}")]

        public IActionResult Delete(Guid id)
        {
            try
            {
                _tipoEventoRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }
    }
}

