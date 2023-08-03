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

// FIXED VERSION
/*
        public String WriteToDB(string something)
        {
            using (SqlConnection con = new SqlConnection())
            using(SqlCommand cmd = new SqlCommand($"SELECT * FROM SomeTable WHERE SomeColumn = @Y", con))
            {
                cmd.Parameters.Add("@Y", SqlDbType.String);
                cmd.Parameters["@Y"] = something;
            }

            return cmd.ExecuteScalar() as String;
        }
*/
    }
}
