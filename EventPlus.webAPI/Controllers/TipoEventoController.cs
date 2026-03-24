using EventPlus.webAPI.DTO;
using EventPlus.webAPI.Interfaces;
using EventPlus.webAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventPlus.webAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TipoEventoController : ControllerBase
{
    private ITipoEventoRepository _tipoEventoRepository;
    public TipoEventoController(ITipoEventoRepository tipoEventoRepository)
    {
        _tipoEventoRepository = tipoEventoRepository;
    }

    /// <summary>
    /// Endpoint da API que faz chamada para o metodo que listar os tipos de evento
    /// </summary>
    /// <returns>Status code 200 e a lista de tipos de evento</returns>



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


    /// <summary>
    /// endpoint da API que faz a chamada para um metodo de busca um tipo de evento especifico
    /// </summary>
    /// <param name="id">id do tipo de evento buscado</param>
    /// <returns>Satus code 200 e tipo de evento buscado</returns>
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
    /// <summary>
    /// Endpoint da API que faz a chamada para um metodo de cadastrar um tipop de evento
    /// </summary>
    /// <param name="novotipoEvento">tipo de evento a ser cancelado</param>
    /// <returns>Status  code 201 e o tipo de evento cadastrado</returns>




    [HttpPost]
    public IActionResult Post(TipoEventoDTO novotipoEvento)
    {
        try
        {
            var novoTipoEvento = new TipoEvento

            {
                Titulo = novotipoEvento.Titulo!
            };
            _tipoEventoRepository.Cadastrar(novoTipoEvento);

            return StatusCode(201, novotipoEvento);
        }
        catch (Exception erro)
        {

            return BadRequest(erro.Message);
        }
    }

    /// <summary>
    /// endpoint a API que faz a chamada para o metodo de atualizar um tipo de evento
    /// </summary>
    /// <param name="id">id do tipo de evento a ser atualizado</param>
    /// <param name="tipoEvento">tipo de evento com os dados atualizados </param>
    /// <returns>Status code 204 e o tipo </returns>

    [HttpPut("{id}")]
    public IActionResult Atualizar(Guid id, TipoEventoDTO tipoEvento)
    {
        try
        {
            var tipoEventoAtualizado = new TipoEvento
            {
                Titulo = tipoEvento.Titulo!
            };

            _tipoEventoRepository.Atualizar(id, tipoEventoAtualizado);
            return StatusCode(204, tipoEventoAtualizado);
        }
        catch (Exception erro)
        {

            return BadRequest(erro.Message);
        }
    }

    /// <summary>
    /// endpoint a API que faz a chamada para o metodo de deletar um tipo de evento
    /// </summary>
    /// <param name="id">id do tipo do eventoa ser excluido </param>
    /// <returns>Status code 204</returns>

    [HttpDelete("{id}")]

    public IActionResult Delete (Guid id)
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
