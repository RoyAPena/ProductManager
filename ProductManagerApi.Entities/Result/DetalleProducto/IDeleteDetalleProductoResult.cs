namespace ProductManagerApi.Entities.Result.DetalleProducto
{
    public interface IDeleteDetalleProductoResult
    {
    }
    public class DeleteDetalleProductoResult : IDeleteDetalleProductoResult
    {
        public abstract class Base<T> : DeleteDetalleProductoResult where T : new()
        {
            public static T Instance
            {
                get { return new T(); }
            }
        }

        public sealed class Success : Base<Success>
        {
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
