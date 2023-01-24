using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;

namespace BASICA
{
    public class Connection:IBasicConnection,IConnection
    {
        #region Variables
        string PathConfig = AppDomain.CurrentDomain.BaseDirectory + "Web.config";
        string PathConnection = AppDomain.CurrentDomain.BaseDirectory + @"..\Conexion.txt";
        SqlConnection MyConnection = new SqlConnection();
        SqlCommand MyCommand; //Representa una instrucción para ejecutar en una base de datos de SQL Server.
        #endregion
        #region Constructor Singleton
        static Connection instance = new Connection();
        public static Connection GetInstance => instance;
        private Connection()
        {
            string ConnectionString = "";
            if (File.Exists(PathConfig))
            {
                ConnectionString = ConfigurationManager.ConnectionStrings["My Connection"].ConnectionString;
            }
            else
                if (File.Exists(PathConnection)) ConnectionString = File.ReadAllText(PathConnection);
            else
                throw new Exception("Error no existe archivo de conexion ");
            MyConnection.ConnectionString = ConnectionString;
        }
        #endregion
        #region Iparameters
        public void AddBit(string name, bool value)
        {
            MyCommand.Parameters.Add("@" + name, SqlDbType.Bit).Value = value;
        }
        public void AddDateTime(string name, DateTime value)
        {
            MyCommand.Parameters.Add("@" + name, SqlDbType.SmallDateTime).Value = value.ToString();
        }
        public void AddFloat(string name, double value)
        {
            MyCommand.Parameters.Add("@" + name, SqlDbType.Float).Value = value;
        }
        public void AddInt(string name, int value)
        {
            MyCommand.Parameters.Add("@" + name, SqlDbType.Int).Value = value;
        }
        public void AddVarchar(string name, int length, string value)
        {
            MyCommand.Parameters.Add("@" + name, SqlDbType.VarChar,length).Value = value;
        }

        #endregion
        #region Iconnection
        public void CreateCommand(string StoreProc, string Data)
        {
            MyCommand = new SqlCommand(StoreProc, MyConnection)
            {
                CommandType = CommandType.StoredProcedure //Especifica cómo se interpreta una cadena de comando
            };
            this.AddData = Data;
        }
        public void Delete()
        {
            OpenConnection();
            try
            {
                MyCommand.ExecuteNonQuery(); //Ejecuta una instrucccion SQL contra la conexión y devuelve el número de filas afectadas.
            }
            catch (Exception err)
            {
                throw new Exception("Error: no se pudo eliminar " + AddData + err.Message);
            }
            finally { MyConnection.Close();}
        }
        public bool Exists()
        {
            OpenConnection();
            try
            {
                int i = int.Parse(MyCommand.ExecuteScalar().ToString()); 
                return i > 0;
            }
            catch (Exception)
            {
                throw new Exception("Error: no se pudo ver si existe " + AddData);
            }
            finally { MyConnection.Close();}
        }
        public DataRow Find()
        {
            OpenConnection();
            try
            {
                DataTable Dt = new DataTable();
                Dt.Load(MyCommand.ExecuteReader());
                return Dt.Rows[0];
            }
            catch (Exception err)
            {
                throw new Exception("Error: no existe " + AddData + err.Message);
            }
            finally { MyConnection.Close();}
        }
        public int Insert()
        {
            OpenConnection(); 
            try
            {
                int i = int.Parse(MyCommand.ExecuteScalar().ToString()); //retorna el ID
                return i ;
            }
            catch (Exception err)
            {
                throw new Exception("Error: no se pudo agregar" + AddData + "\n" + err.Message);
            }
            finally { MyConnection.Close();} //cierra la conexion
        }
        public DataTable List()
        {
            OpenConnection();
            try
            {
                DataTable Dt = new DataTable();
                Dt.Load(MyCommand.ExecuteReader());//Envía un CommandText a la conexión y construye un SqlDataReader, y la tabla carga los datos
                return Dt;
            }
            catch (Exception)
            {
                throw new Exception("Error: no se pudo Listar " + AddData);
            }
            finally { MyConnection.Close();}
        }
        public void Update()
        {
            OpenConnection();
            try
            {
                MyCommand.ExecuteNonQuery(); //ejecuta MyCommand
            }
            catch (Exception err )
            {
                throw new Exception("Error: no se pudo modificar " + AddData + err.Message);
            }
            finally { MyConnection.Close();} 
        }
        #endregion
        #region IBasicConnection
        public string AddData { get; set; }
        public void OpenConnection()
        {
            if (MyConnection.State != ConnectionState.Open)//si la conexion esta cerrada 
                MyConnection.Open();                   //Abre una conexión a la base de datos con la configuración
        }
        #endregion
    }
}
