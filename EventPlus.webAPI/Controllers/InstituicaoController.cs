using EventPlus.webAPI.DTO;
using EventPlus.webAPI.Interfaces;
using EventPlus.webAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventPlus.webAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class InstituicaoController : ControllerBase
{
    private IInstituicaoRepository _instituicaoRepository;

    public InstituicaoController(IInstituicaoRepository instituicaoRepository)
    {
        _instituicaoRepository = instituicaoRepository;
    }

    /// <summary>
    /// Endpoint da API que faz chamada para o metodo que lista as instituições
    /// </summary>
    /// <returns>Status code 200 e a lista de instituições</returns>
    [HttpGet]
    public IActionResult Listar()
    {
        try
        {
            return Ok(_instituicaoRepository.Listar());
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }

    /// <summary>
    /// Endpoint da API que busca uma instituição pelo id
    /// </summary>
    /// <param name="id">id da instituição buscada</param>
    /// <returns>Status code 200 e a instituição buscada</returns>
    [HttpGet("{id}")]
    public IActionResult BuscarPorId(Guid id)
    {
        try
        {
            return Ok(_instituicaoRepository.BuscarPorId(id));
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }

    /// <summary>
    /// Endpoint da API que cadastra uma instituição
    /// </summary>
    /// <param name="novaInstituicao">instituição a ser cadastrada</param>
    /// <returns>Status code 201</returns>
    [HttpPost]
    public IActionResult Post(InstituicaoDTO novaInstituicao)
    {
        try
        {
            var instituicao = new Instituicao
            {
                NomeFantasia = novaInstituicao.NomeFantasia!,
                Cnpj = novaInstituicao.Cnpj!,
                Endereco = novaInstituicao.Endereco
            };

            _instituicaoRepository.Cadastrar(instituicao);

            return StatusCode(201, novaInstituicao);
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }

    /// <summary>
    /// Endpoint da API que atualiza uma instituição
    /// </summary>
    /// <param name="id">id da instituição</param>
    /// <param name="instituicao">dados atualizados</param>
    /// <returns>Status code 204</returns>
    [HttpPut("{id}")]
    public IActionResult Atualizar(Guid id, InstituicaoDTO instituicao)
    {
        try
        {
            var instituicaoAtualizada = new Instituicao
            {
                NomeFantasia = instituicao.NomeFantasia!,
                Cnpj = instituicao.Cnpj!,
                Endereco = instituicao.Endereco!
            };

            _instituicaoRepository.Atualizar(id, instituicaoAtualizada);

            return StatusCode(204, instituicaoAtualizada);
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }

    /// <summary>
    /// Endpoint da API que deleta uma instituição
    /// </summary>
    /// <param name="id">id da instituição</param>
    /// <returns>Status code 204</returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        try
        {
            _instituicaoRepository.Deletar(id);

            return NoContent();
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }
}