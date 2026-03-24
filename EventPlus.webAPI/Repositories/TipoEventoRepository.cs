using EventPlus.webAPI.BdContextEvent;
using EventPlus.webAPI.Interfaces;
using EventPlus.webAPI.Models;

namespace EventPlus.webAPI.Repositorie;

public class TipoEventoRepositor : ITipoEventoRepository
{
    private readonly EventContext _context;
        public TipoEventoRepositor(EventContext context)
    {
        _context = context;
    }
    /// <summary>
    /// Atualizar um tipo de evento usando o rastreamento automatico
    /// </summary>
    /// <param name="id"></param>
    /// <param name="tipoEvento"></param>
    /// <exception cref="NotImplementedException"></exception>
    public void Atualizar(Guid id, TipoEvento tipoEvento)
    {
        var TipoEventoBuscado = _context.TipoEventos.Find(id);
        if(TipoEventoBuscado != null)
        {
            TipoEventoBuscado.Titulo = tipoEvento.Titulo;
            _context.SaveChanges();
        }
    }
    /// <summary>
    /// Busca um tipo de evento pot id
    /// </summary>
    /// <param name="id">id do tipo evento a ser buscado</param>
    /// <returns>Obejto de TipoEvento com as informacoes de tipo de evento buscado</returns>
    public TipoEvento BuscarPorId(Guid id)
    {
        return _context.TipoEventos.Find(id)!;
    }
    /// <summary>
    /// Cadastra um novo tipo de evento
    /// </summary>
    /// <param name="tipoEvento">tipo de evento a ser cadastrado</param>

    public void Cadastrar(TipoEvento tipoEvento)
    {
        _context.TipoEventos.Add(tipoEvento);
        _context.SaveChanges();
    }
    /// <summary>
    /// Deletar um tipo de evento
    /// </summary>
    /// <param name="id">ud do tipo </param>

    public void Deletar(Guid id)
    {
        var tipoEventoBuscado = _context.TipoEventos.Find(id);

        if(tipoEventoBuscado != null)
        {
            _context.TipoEventos.Remove(tipoEventoBuscado);
            _context.SaveChanges();
        }
    }
    /// <summary>
    /// Busca a lista de3 tipo de eventos cadastrado
    /// </summary>
    /// <returns>uma lsita de tipo eventos</returns>
    public List<TipoEvento> Listar()
    {
        return _context.TipoEventos.OrderBy(TipoEvento => TipoEvento.Titulo).ToList();
    }
}
