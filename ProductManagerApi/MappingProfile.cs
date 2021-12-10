using AutoMapper;
using ProductManagerApi.Entities.Model;
using ProductManagerApi.Entities.Request.Producto;
using ProductManagerApi.Entities.ViewModel;

namespace ProductManager
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<InsertProductoRequest, Producto>();
            CreateMap<Producto, ProductoViewModel>()
                .ForMember(x => x.Marca, from => from.MapFrom(p => p.Marca.Descripcion))
                .ForMember(x => x.Modelo, from => from.MapFrom(p => p.Modelo.Descripcion));
            CreateMap<ProductoViewModel, Producto>();
            CreateMap<DetalleProductoViewModel, DetalleProducto>();
            CreateMap<DetalleProducto, DetalleProductoViewModel>()
                .ForMember(x => x.Color, from => from.MapFrom(p => p.Color.Descripcion))
                .ForMember(x => x.Capacidad, from => from.MapFrom(p => p.Capacidad.Descripcion));
            CreateMap<InsertDetalleProductoViewModel, DetalleProducto>();
            CreateMap<DetalleProducto, InsertDetalleProductoViewModel>();

        }
    }
}