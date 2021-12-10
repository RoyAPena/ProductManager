using AutoMapper;
using ProductManagerApi.Contract.Repository;
using ProductManagerApi.Contract.Services;
using ProductManagerApi.Entities.Request.DetalleProducto;
using ProductManagerApi.Entities.Result.DetalleProducto;
using System.Threading.Tasks;

namespace ProductManagerApi.BL.Countries
{
    public class DetalleProductoInnerServices : IDetalleProductoServices
    {
        private readonly IDetalleProductoRepository _detalleDetalleProductoRepository;
        private readonly IMapper _mapper;

        public DetalleProductoInnerServices(IDetalleProductoRepository detalleDetalleProductoRepository, IMapper mapper)
        {
            _detalleDetalleProductoRepository = detalleDetalleProductoRepository;
            _mapper = mapper;
        }

        public async Task<IDeleteDetalleProductoResult> DeleteDetalleProducto(DeleteDetalleProductoRequest request)
        {
            await _detalleDetalleProductoRepository.Delete(request.IdDetalleProducto).ConfigureAwait(false);
            return DeleteDetalleProductoResult.Success.Instance;
        }
    }
}
