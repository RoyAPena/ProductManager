using ProductManagerApi.Contract.Repository;
using ProductManagerApi.Contract.Services;
using ProductManagerApi.Entities.Request.Producto;
using ProductManagerApi.Entities.Result.Producto;
using System.Threading.Tasks;

namespace ProductManagerApi.BL.Countries
{
    public class ProductoValidationServices : IProductoServices
    {
        private readonly IProductoServices _productoService;
        private readonly IProductoRepository _productoRepository;

        public ProductoValidationServices(IProductoServices productoService, IProductoRepository productoRepository)
        {
            _productoService = productoService;
            _productoRepository = productoRepository;
        }

        public async Task<IGetAllProductoResult> GetAllProducto(GetAllProductoRequest request)
        {
            return await _productoService.GetAllProducto(request).ConfigureAwait(false);
        }

        public async Task<IInsertProductoResult> InsertProducto(InsertProductoRequest request)
        {
            return await _productoService.InsertProducto(request).ConfigureAwait(false);
        }
    }
}
