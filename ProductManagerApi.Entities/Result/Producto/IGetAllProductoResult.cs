using ProductManagerApi.Entities.ViewModel;
using System.Collections.Generic;

namespace ProductManagerApi.Entities.Result.Producto
{
    public interface IGetAllProductoResult
    {
    }

    public class GetAllProductoResult : IGetAllProductoResult
    {
        public abstract class Base<T> : GetAllProductoResult where T : new()
        {
            public static T Instance
            {
                get { return new T(); }
            }
        }

        public sealed class Success : Base<Success>
        {
            public ICollection<ProductoViewModel> ListProducto { get; set; }
        }

        public sealed class Failed : Base<Failed>
        {
            public string Error { get; set; }
        }

        public sealed class ValidationError : Base<ValidationError>
        {
            public string ValidationErrors { get; set; }
        }
    }
}
