using EventPlus.webAPI.Models;

namespace EventPlus.webAPI.Interfaces;

public interface IPresencaRepository
{
    void Inscrever(Presenca Inscricao);
    void Deletar(Guid id);
    List<Presenca> Listar();
    Presenca BuscarPorId(Guid id);
    void Atualizar(Guid id);
    List<Presenca> ListarMinhas(Guid IdUsuario);

}
