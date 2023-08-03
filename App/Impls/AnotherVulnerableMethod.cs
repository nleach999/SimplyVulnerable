using App.Interfaces;
using Microsoft.Data.SqlClient;

namespace App.Impls
{
    public class AnotherVulnerableMethod : IDBWrite
    {
        public String WriteToDB(string something)
        {
            SqlConnection con = new SqlConnection();

            SqlCommand cmd = new SqlCommand($"SELECT * FROM SomeTable WHERE SomeColumn = '{something}'", con);

            return cmd.ExecuteScalar() as String;
        }

        // FIXED VERSION
/*        
        public String WriteToDB(string something)
        {
            using (SqlConnection con = new SqlConnection())
            using(SqlCommand cmd = new SqlCommand($"SELECT * FROM SomeTable WHERE SomeColumn = @X", con))
            {
                cmd.Parameters.Add("@X", SqlDbType.String);
                cmd.Parameters["@X"] = something;
            }

            return cmd.ExecuteScalar() as String;
        }
*/        
        
    }
}
