using EventPlus.webAPI.DTO;
using EventPlus.webAPI.DTOs;
using EventPlus.webAPI.Interfaces;
using EventPlus.webAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace EventPlus.webAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PresencaController : ControllerBase
{
    private IPresencaRepository _presencaRepository;
    public PresencaController(IPresencaRepository presencaRepository)
    {
        _presencaRepository = presencaRepository;
    }

    /// <summary>
    /// endpoint da API que retorna uma presencapor id 
    /// </summary>
    /// <param name="id">id da presenca a ser buscada</param>
    /// <returns>Satus code 200 e presenca buscada</returns>
    [HttpGet("{id}")]
    public IActionResult BuscarPorId(Guid id)
    {
        try
        {
            return Ok(_presencaRepository.BuscarPorId(id));
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }

    /// <summary>
    /// endpoint da API que retorna um lista de presencas filtrada por usuario
    /// </summary>
    /// <param name="IdUsuario">id do usuario para filtragem</param>
    /// <returns>uma lista de presencas filtrad pelo usuario</returns>
    [HttpGet("ListarMinhas/{IdUsuario}")]
    public IActionResult BuscarPorUsuario(Guid IdUsuario)
    {
        try
        {
            return Ok(_presencaRepository.ListarMinhas(IdUsuario));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    /// <summary>
    /// endpoint que cadastra uma nova presença
    /// </summary>
    [HttpPost]
    public IActionResult Inscrever(PresencaDTO dto)
    {
        try
        {
            Presenca novaPresenca = new Presenca
            {
                IdUsuario = dto.IdUsuario,
                IdEvento = dto.IdEvento,
                Situacao = dto.Situacao
            };

            _presencaRepository.Inscrever(novaPresenca);
            return StatusCode(201);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    /// <summary>
    /// endpoint que deleta uma presença
    /// </summary>
    [HttpDelete("{id}")]
    public IActionResult Deletar(Guid id)
    {
        try
        {
            _presencaRepository.Deletar(id);
            return NoContent();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    /// <summary>
    /// endpoint que atualiza uma presença
    /// </summary>
    [HttpPut("{id}")]
    public IActionResult Atualizar(Guid id)
    {
        try
        {
            _presencaRepository.Atualizar(id);
            return NoContent();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    /// <summary>
    /// endpoint que lista todas as presenças
    /// </summary>
    [HttpGet]
    public IActionResult Listar()
    {
        try
        {
            return Ok(_presencaRepository.Listar());
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}