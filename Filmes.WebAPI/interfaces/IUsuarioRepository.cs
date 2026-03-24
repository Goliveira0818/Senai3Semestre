using Filmes.WebAPI.Models;

namespace Filmes.WebAPI.interfaces;

public interface IUsuarioRepository
{
    void Cadastrar(Usuario novoUsuario);

    Usuario BuscarPorId(Guid id);

    Usuario BuscarPorEmaileSenha(string email, string senha);

}
