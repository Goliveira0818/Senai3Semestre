using ConnectPlus.WebAPI.Models;

 namespace ConnectPlus.WebAPI.Interfaces;

    public interface IContatoRepository
{
   
    List<Contato> Listar();
    public Contato BuscarPorId(Guid id);
    public void Atualizar(Guid id, Contato contato);
    public void Deletar(Guid id);
    void Cadastrar(Contato novoContato);
}