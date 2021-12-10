using ProductManagerApi.Contract.Repository;
using ProductManagerApi.Entities.Model;
using System.Threading.Tasks;

namespace ProductManagerApi.Repository.SQL
{
    public class DetalleProductoRepository : IDetalleProductoRepository
    {
        private readonly ProductManagerContext _context;

        public DetalleProductoRepository(ProductManagerContext context)
        {
            _context = context;
        }

        public async Task Delete(int id)
        {
            var detalleProducto = new DetalleProducto { IdDetalleProducto = id };
            _context.DetalleProducto.Attach(detalleProducto);
            _context.DetalleProducto.Remove(detalleProducto);
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}