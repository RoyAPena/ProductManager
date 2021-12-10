using ProductManagerApi.Entities.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductManagerApi.Contract.Repository
{
    public interface IProductoRepository
    {
        Task Insert(Producto producto);
        Task<List<Producto>> GetAll();
    }
}
