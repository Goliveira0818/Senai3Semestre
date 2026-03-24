using EventPlus.webAPI.DTO;
using EventPlus.webAPI.Interfaces;
using EventPlus.webAPI.Models;
using EventPlus.WebAPI.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventPlus.webAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioRepository _usuarioRepository;
    public UsuarioController(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }
    /// <summary>
    /// Endpoint da API que faz chamada para o metodo de buscar um salario por id 
    /// </summary>
    /// <param name="id">id do usuario a ser buscado</param>
    /// <returns>Status code 200 e o usuario buscado</returns>
    [HttpGet("{id}")]
    public IActionResult BuscarPorId(Guid id)
    {
        try 
        {
            return Ok(_usuarioRepository.BuscarPorId(id));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);  
        }
    }
    /// <summary>
    /// EndPoint da API que faz a chamada para o metodo de cadastrar um usuario
    /// </summary>
    /// <param name="usuario">Usuario a ser cadastrado</param>
    /// <returns>Status code 201 e o usuario cadastrado</returns>
    [HttpPost]
    public IActionResult Cadastrar(UsuarioDTO usuario)  
    {
        try
        {
            var novoUsuario = new Usuario
            {
                Email = usuario.Email!,
                Nome = usuario.Nome!,
                Senha = usuario.Senha!,
                IdTipoUsuario = usuario.IdTipoUsuario
            };
          
            _usuarioRepository.Cadastrar(novoUsuario);
            return StatusCode(201, novoUsuario);

        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
                
        }

    }
   
}

