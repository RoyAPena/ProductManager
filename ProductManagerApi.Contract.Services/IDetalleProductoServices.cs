using ProductManagerApi.Entities.Request.DetalleProducto;
using ProductManagerApi.Entities.Result.DetalleProducto;
using System.Threading.Tasks;

namespace ProductManagerApi.Contract.Services
{
    public interface IDetalleProductoServices
    {
        Task<IDeleteDetalleProductoResult> DeleteDetalleProducto(DeleteDetalleProductoRequest request);
    }
}