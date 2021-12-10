using ProductManagerApi.Contract.Services;
using ProductManagerApi.Entities.Request.Producto;
using ProductManagerApi.Entities.Result.Producto;
using System.Threading.Tasks;
using System.Web.Http;

namespace ProductManagerApi.Controllers
{
    //[Authorize]
    [RoutePrefix("api/Producto")]
    public class ProductoController : ApiController
    {
        private readonly IProductoServices _productoService;

        public ProductoController(IProductoServices productoService)
        {
            _productoService = productoService;
        }

        [HttpPost]
        [Route("GetAllProducto")]
        public async Task<IGetAllProductoResult> GetAllProducto(GetAllProductoRequest request)
        {
            var result = await _productoService.GetAllProducto(request).ConfigureAwait(false);

            switch (result)
            {
                case GetAllProductoResult.Success success:
                    {
                        var resultExpanded = success;
                        return resultExpanded;
                    }

                case GetAllProductoResult.ValidationError error:
                    {
                        var resultExpanded = error;
                        return resultExpanded;
                    }

                default:
                    {
                        var resultExpandedError = result as GetAllProductoResult.Failed;
                        return resultExpandedError;
                    }
            }
        }

        [HttpPost]
        [Route("InsertProducto")]
        public async Task<IInsertProductoResult> InsertProducto(InsertProductoRequest request)
        {
            var result = await _productoService.InsertProducto(request).ConfigureAwait(false);

            switch (result)
            {
                case InsertProductoResult.Success success:
                    {
                        var resultExpanded = success;
                        return resultExpanded;
                    }

                case InsertProductoResult.ValidationError error:
                    {
                        var resultExpanded = error;
                        return resultExpanded;
                    }

                default:
                    {
                        var resultExpandedError = result as InsertProductoResult.Failed;
                        return resultExpandedError;
                    }
            }
        }
    }
}