using ProductManagerApi.Contract.Repository;
using ProductManagerApi.Entities.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagerApi.Repository.SQL
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly ProductManagerContext _context;

        public ProductoRepository(ProductManagerContext context)
        {
            _context = context;
        }

        public async Task<List<Producto>> GetAll()
        {
            return await _context.Producto.ToListAsync().ConfigureAwait(false);
        }

        public async Task Insert(Producto producto)
        {
            _context.Producto.Add(producto);
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
