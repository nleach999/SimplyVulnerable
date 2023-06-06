using App.Interfaces;
using Microsoft.Data.SqlClient;

namespace App.Impls
{
    public class OneVulnerableMethod : IDBWrite
    {
        public String WriteToDB(string something)
        {
            SqlConnection con = new SqlConnection();

            SqlCommand cmd = new SqlCommand("SELECT * FROM SomeTable WHERE SomeColumn = '" + something + "'", con);

            return cmd.ExecuteScalar() as String;

        }
    }
}
