namespace pruebaTecnica.Conexion
{
    public class ConexionBD
    {
        private string connectionString;
        public ConexionBD()
        {
            //saca la cadena de conexion de la base de datos que esta protegida en appsetting.json
            var constructor = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            connectionString = constructor.GetSection("ConnectionStrings:conexion").Value;
        }
        public string cadenaSQL()
        {
            return connectionString;
        }
    }
}
