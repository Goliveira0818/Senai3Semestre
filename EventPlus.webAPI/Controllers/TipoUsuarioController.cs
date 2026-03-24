using EventPlus.webAPI.DTO;
using EventPlus.webAPI.Interfaces;
using EventPlus.webAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventPlus.webAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TipoUsuarioController : ControllerBase
{
    private ITipoUsuarioRepository _tipoUsuarioRepository;

    public TipoUsuarioController(ITipoUsuarioRepository tipoUsuarioRepository)
    {
        _tipoUsuarioRepository = tipoUsuarioRepository;
    }

    /// <summary>
    /// Endpoint da API que faz chamada para o metodo que lista os tipos de usuário
    /// </summary>
    /// <returns>Status code 200 e a lista de tipos de usuário</returns>
    [HttpGet]
    public IActionResult Listar()
    {
        try
        {
            return Ok(_tipoUsuarioRepository.Listar());
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }

    /// <summary>
    /// Endpoint da API que busca um tipo de usuário pelo id
    /// </summary>
    /// <param name="id">id do tipo de usuário buscado</param>
    /// <returns>Status code 200 e o tipo de usuário</returns>
    [HttpGet("{id}")]
    public IActionResult BuscarPorId(Guid id)
    {
        try
        {
            return Ok(_tipoUsuarioRepository.BuscarPorId(id));
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }

    /// <summary>
    /// Endpoint da API que cadastra um tipo de usuário
    /// </summary>
    /// <param name="novoTipoUsuario">tipo de usuário a ser cadastrado</param>
    /// <returns>Status code 201</returns>
    [HttpPost]
    public IActionResult Post(TipoUsuarioDTO novoTipoUsuario)
    {
        try
        {
            var tipoUsuario = new TipoUsuario
            {
                Titulo = novoTipoUsuario.Titulo!
            };

            _tipoUsuarioRepository.Cadastrar(tipoUsuario);

            return StatusCode(201, novoTipoUsuario);
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }

    /// <summary>
    /// Endpoint da API que atualiza um tipo de usuário
    /// </summary>
    /// <param name="id">id do tipo de usuário</param>
    /// <param name="tipoUsuario">dados atualizados</param>
    /// <returns>Status code 204</returns>
    [HttpPut("{id}")]
    public IActionResult Atualizar(Guid id, TipoUsuarioDTO tipoUsuario)
    {
        try
        {
            var tipoUsuarioAtualizado = new TipoUsuario
            {
                Titulo = tipoUsuario.Titulo!
            };

            _tipoUsuarioRepository.Atualizar(id, tipoUsuarioAtualizado);

            return StatusCode(204, tipoUsuarioAtualizado);
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }

    /// <summary>
    /// Endpoint da API que deleta um tipo de usuário
    /// </summary>
    /// <param name="id">id do tipo de usuário</param>
    /// <returns>Status code 204</returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        try
        {
            _tipoUsuarioRepository.Deletar(id);

            return NoContent();
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }
}
