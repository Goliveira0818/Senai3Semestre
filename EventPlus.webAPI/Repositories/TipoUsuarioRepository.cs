using EventPlus.webAPI.BdContextEvent;
using EventPlus.webAPI.DTO;
using EventPlus.webAPI.Interfaces;
using EventPlus.webAPI.Models;

namespace EventPlus.webAPI.Repositories;

public class TipoUsuarioRepository : ITipoUsuarioRepository
{
    private readonly EventContext _context;

    public TipoUsuarioRepository(EventContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Atualiza um tipo de usuário usando o rastreamento automático
    /// </summary>
    /// <param name="id">Id do tipo de usuário que será atualizado</param>
    /// <param name="tipoUsuario">Objeto contendo as novas informações</param>
    public void Atualizar(Guid id, TipoUsuario tipoUsuario)
    {
        var tipoUsuarioBuscado = _context.TipoUsuarios.Find(id);

        if (tipoUsuarioBuscado != null)
        {
            tipoUsuarioBuscado.Titulo = tipoUsuario.Titulo;

            _context.SaveChanges();
        }
    }

    public void Atualizar(Guid id, TipoUsuarioDTO tipoUsuario)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Busca um tipo de usuário pelo id
    /// </summary>
    /// <param name="id">Id do tipo de usuário</param>
    /// <returns>Objeto TipoUsuario com as informações encontradas</returns>
    public TipoUsuario BuscarPorId(Guid id)
    {
        return _context.TipoUsuarios.Find(id)!;
    }

    /// <summary>
    /// Cadastra um novo tipo de usuário
    /// </summary>
    /// <param name="tipoUsuario">Objeto contendo os dados do tipo de usuário</param>
    public void Cadastrar(TipoUsuario tipoUsuario)
    {
        _context.TipoUsuarios.Add(tipoUsuario);

        _context.SaveChanges();
    }

    /// <summary>
    /// Deleta um tipo de usuário
    /// </summary>
    /// <param name="id">Id do tipo de usuário que será removido</param>
    public void Deletar(Guid id)
    {
        var tipoUsuarioBuscado = _context.TipoUsuarios.Find(id);

        if (tipoUsuarioBuscado != null)
        {
            _context.TipoUsuarios.Remove(tipoUsuarioBuscado);

            _context.SaveChanges();
        }
    }

    /// <summary>
    /// Lista todos os tipos de usuários cadastrados
    /// </summary>
    /// <returns>Lista de tipos de usuários</returns>
    public List<TipoUsuario> Listar()
    {
        return _context.TipoUsuarios.OrderBy(tipoUsuario => tipoUsuario.Titulo).ToList();
    }

}

