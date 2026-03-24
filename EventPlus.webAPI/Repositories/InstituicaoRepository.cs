using EventPlus.webAPI.BdContextEvent;
using EventPlus.webAPI.Interfaces;
using EventPlus.webAPI.Models;

namespace EventPlus.webAPI.Repositories;

public class InstituicaoRepository : IInstituicaoRepository
{
    private readonly EventContext _context;

    public InstituicaoRepository(EventContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Atualiza uma instituição usando o rastreamento automático
    /// </summary>
    /// <param name="id">Id da instituição que será atualizada</param>
    /// <param name="instituicao">Objeto contendo as novas informações</param>
    public void Atualizar(Guid id, Instituicao instituicao)
    {
        var instituicaoBuscada = _context.Instituicaos.Find(id);

        if (instituicaoBuscada != null)
        {
            //atualiza os campo do tipo de instituicao
            instituicaoBuscada.NomeFantasia= String.IsNullOrWhiteSpace(instituicao.NomeFantasia) ? instituicaoBuscada.NomeFantasia : instituicao.NomeFantasia;
            instituicaoBuscada.Cnpj = String.IsNullOrWhiteSpace(instituicao.Cnpj) ? instituicaoBuscada.Cnpj : instituicao.Cnpj;
            instituicaoBuscada.Endereco = String.IsNullOrWhiteSpace(instituicao.Endereco) ? instituicaoBuscada.Endereco : instituicao.Endereco;
           


            _context.SaveChanges();
        }
    }

    /// <summary>
    /// Busca uma instituição pelo id
    /// </summary>
    /// <param name="id">Id da instituição</param>
    /// <returns>Objeto Instituicao com as informações encontradas</returns>
    public Instituicao BuscarPorId(Guid id)
    {
        return _context.Instituicaos.Find(id)!;
    }

    /// <summary>
    /// Cadastra uma nova instituição
    /// </summary>
    /// <param name="instituicao">Objeto contendo os dados da instituição</param>
    public void Cadastrar(Instituicao instituicao)
    {
        _context.Instituicaos.Add(instituicao);

        _context.SaveChanges();
    }

    /// <summary>
    /// Deleta uma instituição
    /// </summary>
    /// <param name="id">Id da instituição que será removida</param>
    public void Deletar(Guid id)
    {
        var instituicaoBuscada = _context.Instituicaos.Find(id);

        if (instituicaoBuscada != null)
        {
            _context.Instituicaos.Remove(instituicaoBuscada);

            _context.SaveChanges();
        }
    }

    /// <summary>
    /// Lista todas as instituições cadastradas
    /// </summary>
    /// <returns>Lista de instituições</returns>
    public List<Instituicao> Listar()
    {
        return _context.Instituicaos.OrderBy(instituicao => instituicao.NomeFantasia).ToList();
    }

    public List<Instituicao> Usuario()
    {
        throw new NotImplementedException();
    }

    object? IInstituicaoRepository.Listar()
    {
        return Listar();
    }
}