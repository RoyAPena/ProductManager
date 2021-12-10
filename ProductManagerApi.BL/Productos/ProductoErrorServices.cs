using ProductManagerApi.Contract.Repository;
using ProductManagerApi.Contract.Services;
using ProductManagerApi.Entities.Request.Producto;
using ProductManagerApi.Entities.Result.Producto;
using System;
using System.Threading.Tasks;

namespace ProductManagerApi.BL.Countries
{
    public class ProductoErrorServices : IProductoServices
    {
        private readonly IProductoServices _productoService;

        public ProductoErrorServices(IProductoServices productoService)
        {
            _productoService = productoService;
        }

        public async Task<IGetAllProductoResult> GetAllProducto(GetAllProductoRequest request)
        {
            try
            {
                return await _productoService.GetAllProducto(request).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                var error = GetAllProductoResult.Failed.Instance;
                error.Error = ex.ToString();
                return error;
            }
        }

        public async Task<IInsertProductoResult> InsertProducto(InsertProductoRequest request)
        {
            try
            {
                return await _productoService.InsertProducto(request).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                var error = InsertProductoResult.Failed.Instance;
                error.Error = ex.ToString();
                return error;
            }
        }
    }
}
