using MySql.Data.MySqlClient; 
namespace Delivery_Carol {
     public class Conexao { 
        private string servidor = "localhost";
        private string banco = "DB_SistemaLoja";
        private string usuario = "root";
        private string senha = "matt";

        public MySqlConnection Conectar() { 
            string stringConexao = $"Server={servidor};Database={banco};Uid={usuario};Pwd={senha};"; return new MySqlConnection(stringConexao); 
            } 
        } 
    }
