using demoapp.Model;
using MySql.Data.MySqlClient;
using System.Data;

namespace demoapp.DbHandler
{
    public class DataDBhandler
    {
        private readonly string _connectionString;
        public DataDBhandler()
        {
            // Read the connection string from appsettings.json
            _connectionString = "Datasource=13.126.125.20;Port=3306;Database=linux_database;uid=VyayAWSDBServer;pwd=Botmatic123$;";//"Server=3.110.5.126;Database=linux_database;User=VyayAWSDBServer;Password=Botmatic123$;Port=3306;";//configuration.GetConnectionString("DefaultConnection");
        }
        public dataModel fetchdatafromdatabase()
        {
            dataModel model = new dataModel();
            string storedProcedureName = "GetTheDatafromthedatabase"; MySqlParameter[] parameters = null;
            try
            {
                DataTable resultTable = new DataTable();

                using (var connection = new MySqlConnection(_connectionString))
                {
                    using (var command = new MySqlCommand(storedProcedureName, connection))
                    {
                        // Specify that this command is a stored procedure
                        command.CommandType = CommandType.StoredProcedure;

                        // Add parameters, if any
                        if (parameters != null)
                        {
                            command.Parameters.AddRange(parameters);
                        }

                        // Use MySqlDataAdapter to fill the DataTable
                        using (var adapter = new MySqlDataAdapter(command))
                        {
                            adapter.Fill(resultTable);
                        }
                        model.day = Convert.ToString(resultTable.Rows[0][0]);
                        model.season = Convert.ToString(resultTable.Rows[0][1]);
                        model.tempreture = Convert.ToString(resultTable.Rows[0][2]);
                    }
                }

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return model;
        }
    }
}
