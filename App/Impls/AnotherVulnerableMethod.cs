using App.Interfaces;
using Microsoft.Data.SqlClient;

namespace App.Impls
{
    public class AnotherVulnerableMethod : IDBWrite
    {
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
    }
}
