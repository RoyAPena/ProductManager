using System.Threading.Tasks;

namespace ProductManagerApi.Contract.Repository
{
    public interface IDetalleProductoRepository
    {
        Task Delete(int id);
    }
}