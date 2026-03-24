using EventPlus.webAPI.BdContextEvent;
using EventPlus.webAPI.Interfaces;
using EventPlus.webAPI.Models;
using EventPlus.webAPI.Utils;
using EventPlus.WebAPI.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EventPlus.webAPI.Repositories;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly EventContext _context;

    //metodo construtor que aplica a injeção de dependencia 
    public UsuarioRepository(EventContext context)
    {
        _context = context;
    }
    /// <summary>
    /// BUsca o usuario pelo e-mail e valida o hash da senha 
    /// </summary>
    /// <param name="Email">Email do usuario a ser buscado </param>
    /// <param name="Senha">Senha para validar o usuario</param>
    /// <returns>Usuario buscado</returns>
    public Usuario BuscarPorEmailESenha(string Email, string Senha)
    {
        //primeiro,buscamos o usuario pelo e-mail
        var usuarioBuscado = _context.Usuarios.Include(usuario => usuario.IdTipoUsuarioNavigation).FirstOrDefault(usuario => usuario.Email == Email);

        //verificamos se o usuario foi encontrao 
        if(usuarioBuscado != null) 
        {
            //comparamos o hash da senha digitada com o que esta no banco 
            bool confere = Criptografia.CompararHash(Senha, usuarioBuscado.Senha);
            if (confere) 
            
            {
                return usuarioBuscado;
            }
        }
        return null!;
    }

    /// <summary>
    /// Busca um usuario pelo id, incluindo os dados do seu tipo de usuario
    /// </summary>
    /// <param name="id">id do usuario a ser buscado</param>
    /// <returns>Usuario Buscado e seu tipo de usuario</returns>

    public Usuario BuscarPorId(Guid id)
    {
        return _context.Usuarios.Include(usuario => usuario.IdTipoUsuarioNavigation).FirstOrDefault(Usuario => Usuario.IdUsuario == id)!;
    }
    /// <summary>
    /// Cadastrar um novo usuario.A senha e Cripotografada e o Id gerado pelo banco
    /// </summary>
    /// <param name="usuario">Usuario s ser cadastrado</param>
    public void Cadastrar(Usuario usuario)
    {
        usuario.Senha = Criptografia.GerarHash(usuario.Senha);

        _context.Usuarios.Add(usuario);
        _context.SaveChanges();
    }
}
