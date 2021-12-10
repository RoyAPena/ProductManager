using ProductManagerApi.Contract.Repository;
using ProductManagerApi.Contract.Services;
using ProductManagerApi.Entities.Request.DetalleProducto;
using ProductManagerApi.Entities.Result.DetalleProducto;
using System.Threading.Tasks;

namespace ProductManagerApi.BL.Countries
{
    public class DetalleProductoValidationServices : IDetalleProductoServices
    {
        private readonly IDetalleProductoServices _detalleProductoService;
        private readonly IDetalleProductoRepository _detalleProductoRepository;

        public DetalleProductoValidationServices(IDetalleProductoServices detalleProductoService, IDetalleProductoRepository detalleProductoRepository)
        {
            _detalleProductoService = detalleProductoService;
            _detalleProductoRepository = detalleProductoRepository;
        }

        public async Task<IDeleteDetalleProductoResult> DeleteDetalleProducto(DeleteDetalleProductoRequest request)
        {
            return await _detalleProductoService.DeleteDetalleProducto(request).ConfigureAwait(false);
        }
    }
}