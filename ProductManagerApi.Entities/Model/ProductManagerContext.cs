using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.SqlClient;
using DbContext = System.Data.Entity.DbContext;

namespace ProductManagerApi.Entities.Model
{
    public class ProductManagerContext : DbContext
    {

        public ProductManagerContext() : base("ProductManagerContext")
        {
        }
        
        public virtual DbSet<Marca> Marca { get; set; }
        public virtual DbSet<Modelo> Modelo { get; set; }
        public virtual DbSet<Color> Color { get; set; }
        public virtual DbSet<Capacidad> Capacidad { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<DetalleProducto> DetalleProducto { get; set; }

        protected override void OnModelCreating(DbModelBuilder dbModelBuilder)
        {
            dbModelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public static string GenerateCommandText(string storedProcedure, SqlParameter[] parameters)
        {
            string CommandText = "EXEC {0} {1}";
            string[] ParameterNames = new string[parameters.Length];

            for (int i = 0; i < parameters.Length; i++)
            {
                ParameterNames[i] = parameters[i].ParameterName;
            }

            return string.Format(CommandText, storedProcedure, string.Join(",", ParameterNames));
        }
    }
}