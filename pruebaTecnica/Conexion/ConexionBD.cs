namespace pruebaTecnica.Conexion
{
    public class ConexionBD
    {
        private string connectionString;
        public ConexionBD()
        {
            var constructor = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            connectionString = constructor.GetSection("ConnectionStrings:conexion").Value;
        }
        public string cadenaSQL()
        {
            return connectionString;
        }
    }
}
