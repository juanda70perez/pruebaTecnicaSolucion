using MySql.Data.MySqlClient;
using pruebaTecnica.Conexion;
using pruebaTecnica.Models;
using System.Data;
using System.Data.SqlClient;
//Se encarga de comunicarse con la base de datos con la tabla element
namespace pruebaTecnica.Datos
{
    public class Delementos
    {
        ConexionBD conexion = new ConexionBD();
        public async Task<List<Element>> MostrarElementos()
        {
            var lista = new List<Element>();
            using (var sql = new MySqlConnection(conexion.cadenaSQL()))
            {
                //Llamada a procedimiento almacenado llamado "mostrarElementos" en la base de datos
                using (var cmd = new MySqlCommand("mostrarElementos", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var element = new Element();
                            element.Id = (int)reader["idelement"];
                            element.Nombre = (string)reader["nombre"];
                            element.Peso = (int)reader["peso"];
                            element.Calorias = (int)reader["calorias"];
                            lista.Add(element);
                        }
                    }
                }
            }
                return lista;
        }
        public async Task InsertarElementos(Element element)
        {
            try
            {
                using (var sql = new MySqlConnection(conexion.cadenaSQL()))
                {
                    //comunicarse con la base de datos en forma de setencia sql, enviarle datos al procedimiento me dio errores
                    string query = "insert into Element(Nombre,Peso,Calorias) values  (?nombre1,?peso1,?calorias1);";
                    using (var cmd = new MySqlCommand(query, sql))
                    {
                        //pasar los parametros y mirar si van con el tipo de dato acorde
                        cmd.Parameters.Add("?nombre1",MySqlDbType.String).Value = element.Nombre;
                        cmd.Parameters.Add("?peso1", MySqlDbType.Int64).Value = element.Peso;
                        cmd.Parameters.Add("?calorias1", MySqlDbType.Int64).Value = element.Calorias ;
                        await sql.OpenAsync();
                        await cmd.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception e)
            {
                //pequeño fragmento para mirar en el debug el mensaje del error
                var a = e.Message;
            }
            
        }
        public async Task EditarElementos(Element element)
        {
            try
            {
                //comunicarse con la base de datos en forma de setencia sql, enviarle datos al procedimiento me dio errores
                using (var sql = new MySqlConnection(conexion.cadenaSQL()))
                {
                    string query = "update element set nombre = ?nombre1, peso = ?peso1, calorias = ?calorias1 where idElement=?id;";
                    using (var cmd = new MySqlCommand(query, sql))
                    {
                        //pasar los parametros y mirar si van con el tipo de dato acorde
                        cmd.Parameters.AddWithValue("?id", element.Id);
                        cmd.Parameters.AddWithValue("?nombre1", element.Nombre);
                        cmd.Parameters.AddWithValue("?peso1", element.Peso);
                        cmd.Parameters.AddWithValue("?calorias1", element.Calorias);
                        await sql.OpenAsync();
                        await cmd.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex) {
              var a =   ex.Message;
            }
        }
        public async Task EliminarElemento(Element element)
        {
            try
            {
                using (var sql = new MySqlConnection(conexion.cadenaSQL()))
                {
                    string query = "delete from element where idElement=?id;";
                    using (var cmd = new MySqlCommand(query, sql))
                    {
                        cmd.Parameters.AddWithValue("?id", element.Id);
                        await sql.OpenAsync();
                        await cmd.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                var a = ex.Message;
            }
        }
    }
}
