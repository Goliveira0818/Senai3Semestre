using Filmes.WebAPI.Models;

namespace Filmes.WebAPI.interfaces;

public interface IGeneroRepository
{
    void Cadastrar(Genero novoGenero);
    void AtualizarIdCorpo(Genero generoAtualizado);

    void AtualizarIdUrl(Guid id, Genero generoAtulizado);

    List<Genero> Listar();

    void Deletar(Guid id);

    Genero BuscarPorId(Guid id);
}
