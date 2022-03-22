using APIClientes.Modelos.DTO;

namespace APIClientes.Repositorio
{
    public interface IClienteRepositorio
    {
        Task<List<ClienteDTO>> GetClientes();
        Task<ClienteDTO> GetClientesById(int id);
        Task<ClienteDTO> CreateUpdate(ClienteDTO clienteDTO);
        Task<bool> DeleteCliente(int id);

    }
}
