using Autofac;
using AutoMapper;
using ProductManagerApi.BL.Countries;
using ProductManagerApi.Contract.Repository;
using ProductManagerApi.Contract.Services;
using ProductManagerApi.Entities.Model;
using ProductManagerApi.Repository.SQL;
using System.Reflection;
using Module = Autofac.Module;

namespace ProductManager.CompositionModel
{
    public class CompositionModel : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.Register(context => new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<MappingProfile>();
                }
            )).AsSelf().SingleInstance();

            builder.Register(c =>
                {
                    var context = c.Resolve<IComponentContext>();
                    var config = context.Resolve<MapperConfiguration>();
                    return config.CreateMapper(context.Resolve);
                })
                .As<IMapper>()
                .InstancePerLifetimeScope();
            builder.RegisterType<ProductManagerContext>().InstancePerRequest();

            var repository = Assembly.GetAssembly(typeof(ProductoRepository));
            builder.RegisterAssemblyTypes(repository)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces();

            builder.RegisterType<ProductoInnerServices>().Named<IProductoServices>("ProductoServices");
            builder.RegisterDecorator(
                delegate (IComponentContext c, IProductoServices inner)
                {
                    var validation = new ProductoValidationServices(inner, c.Resolve<IProductoRepository>());
                    var errorHandling = new ProductoErrorServices(validation);
                    return errorHandling;
                }, "ProductoServices");

            builder.RegisterType<DetalleProductoInnerServices>().Named<IDetalleProductoServices>("DetalleProductoServices");
            builder.RegisterDecorator(
                delegate (IComponentContext c, IDetalleProductoServices inner)
                {
                    var validation = new DetalleProductoValidationServices(inner, c.Resolve<IDetalleProductoRepository>());
                    var errorHandling = new DetalleProductoErrorServices(validation);
                    return errorHandling;
                }, "DetalleProductoServices");
        }
    }
}