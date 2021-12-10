using ProductManagerApi.Contract.Services;
using ProductManagerApi.Entities.Request.DetalleProducto;
using ProductManagerApi.Entities.Result.DetalleProducto;
using System;
using System.Threading.Tasks;

namespace ProductManagerApi.BL.Countries
{
    public class DetalleProductoErrorServices : IDetalleProductoServices
    {
        private readonly IDetalleProductoServices _detalleProductoService;

        public DetalleProductoErrorServices(IDetalleProductoServices detalleProductoService)
        {
            _detalleProductoService = detalleProductoService;
        }

        public async Task<IDeleteDetalleProductoResult> DeleteDetalleProducto(DeleteDetalleProductoRequest request)
        {
            try
            {
                return await _detalleProductoService.DeleteDetalleProducto(request).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                var error = DeleteDetalleProductoResult.Failed.Instance;
                error.Error = ex.ToString();
                return error;
            }
        }
    }
}