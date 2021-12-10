using AutoMapper;
using ProductManagerApi.Contract.Repository;
using ProductManagerApi.Contract.Services;
using ProductManagerApi.Entities.Model;
using ProductManagerApi.Entities.Request.Producto;
using ProductManagerApi.Entities.Result.Producto;
using ProductManagerApi.Entities.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductManagerApi.BL.Countries
{
    public class ProductoInnerServices : IProductoServices
    {
        private readonly IProductoRepository _productoRepository;
        private readonly IMapper _mapper;

        public ProductoInnerServices(IProductoRepository productoRepository, IMapper mapper)
        {
            _productoRepository = productoRepository;
            _mapper = mapper;
        }

        public async Task<IGetAllProductoResult> GetAllProducto(GetAllProductoRequest request)
        {
            var success = GetAllProductoResult.Success.Instance;
            var result = await _productoRepository.GetAll().ConfigureAwait(false);
            success.ListProducto = _mapper.Map<List<ProductoViewModel>>(result);
            return success;
        }

        public async Task<IInsertProductoResult> InsertProducto(InsertProductoRequest request)
        {
            var success = InsertProductoResult.Success.Instance;

            var producto = _mapper.Map<Producto>(request);

            await _productoRepository.Insert(producto).ConfigureAwait(false);

            return success;
        }
    }
}
