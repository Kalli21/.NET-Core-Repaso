using APIClientes.Data;
using APIClientes.Modelos;
using APIClientes.Modelos.DTO;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace APIClientes.Repositorio
{
    public class Clienterepositorio : IClienteRepositorio
    {
        private readonly ApplicationDbContext _db;
        private IMapper _mapper;

        public Clienterepositorio(ApplicationDbContext db, IMapper mapper)
        { 
            _db = db;
            _mapper = mapper;   
        }

        public async Task<ClienteDTO> CreateUpdate(ClienteDTO clienteDTO)
        {
            Cliente cliente = _mapper.Map<ClienteDTO, Cliente>(clienteDTO);
            if (cliente.Id>0)
            {
                _db.Clientes.Update(cliente);
            }
            else
            {
                await _db.Clientes.AddAsync(cliente);
            }
            await _db.SaveChangesAsync();
            return _mapper.Map<Cliente, ClienteDTO>(cliente);
        }

        public async Task<bool> DeleteCliente(int id)
        {
            try
            {
                Cliente cliente = await _db.Clientes.FindAsync(id);
                if (cliente == null)
                    return false;
                _db.Clientes.Remove(cliente);
                await _db.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<List<ClienteDTO>> GetClientes()
        {
            List<Cliente> clientes = await _db.Clientes.ToListAsync();
            return _mapper.Map<List<ClienteDTO>>(clientes);
        }

        public async Task<ClienteDTO> GetClientesById(int id)
        {
            Cliente cliente = await _db.Clientes.FindAsync(id);
            return _mapper.Map<ClienteDTO>(cliente);
        }
    }
}
