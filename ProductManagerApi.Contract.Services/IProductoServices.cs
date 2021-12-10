using ProductManagerApi.Entities.Request.Producto;
using ProductManagerApi.Entities.Result.Producto;
using System.Threading.Tasks;

namespace ProductManagerApi.Contract.Services
{
    public interface IProductoServices
    {
        Task<IInsertProductoResult> InsertProducto(InsertProductoRequest request);
        Task<IGetAllProductoResult> GetAllProducto(GetAllProductoRequest request);
    }
}