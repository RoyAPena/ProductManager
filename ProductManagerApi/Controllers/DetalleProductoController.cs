using ProductManagerApi.Contract.Services;
using ProductManagerApi.Entities.Request.DetalleProducto;
using ProductManagerApi.Entities.Result.DetalleProducto;
using System.Threading.Tasks;
using System.Web.Http;

namespace ProductManagerApi.Controllers
{
    //[Authorize]
    [RoutePrefix("api/DetalleProducto")]
    public class DetalleProductoController : ApiController
    {
        private readonly IDetalleProductoServices _detalleProductoService;

        public DetalleProductoController(IDetalleProductoServices detalleProductoService)
        {
            _detalleProductoService = detalleProductoService;
        }

        [HttpPost]
        [Route("DeleteDetalleProducto")]
        public async Task<IDeleteDetalleProductoResult> DeleteDetalleProducto(DeleteDetalleProductoRequest request)
        {
            var result = await _detalleProductoService.DeleteDetalleProducto(request).ConfigureAwait(false);

            switch (result)
            {
                case DeleteDetalleProductoResult.Success success:
                    {
                        var resultExpanded = success;
                        return resultExpanded;
                    }

                case DeleteDetalleProductoResult.ValidationError error:
                    {
                        var resultExpanded = error;
                        return resultExpanded;
                    }

                default:
                    {
                        var resultExpandedError = result as DeleteDetalleProductoResult.Failed;
                        return resultExpandedError;
                    }
            }
        }
    }
}