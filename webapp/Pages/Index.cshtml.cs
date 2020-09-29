using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace webapp.Pages
{
    public class IndexModel : PageModel
    {

        public void OnPost()
        {
            SqlConnection con = new SqlConnection();

            SqlCommand cmd = new SqlCommand("SELECT * FROM SomeTable WHERE SomeColumn = @RandomWord", con);
            var param = cmd.Parameters.Add("@RandomWord", System.Data.SqlDbType.VarChar);
            param.Value = Request.Form["RandomWord"];

            String response = HttpUtility.HtmlEncode (Request.Form["YourName"]) + ", here is the result: " + HttpUtility.HtmlEncode(cmd.ExecuteScalar());

            Response.Body.Write(new ReadOnlySpan<byte>(Encoding.UTF8.GetBytes (response.ToArray ()) ) );
        }
    }
}
