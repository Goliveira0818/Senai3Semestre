using EventPlus.webAPI.Models;

namespace EventPlus.webAPI.Interfaces;

public interface IEventoRepository
{
    void Cadastrar(Evento evento);
    List<Evento> Listar();
    void Deletar(Guid IdEvento);
    void Atualizar(Guid id, Evento evento);
    List<Evento> ListarPorId(Guid id);
    List<Evento> ProximosEventos();
    Evento BuscarPorId(Guid id);
}
