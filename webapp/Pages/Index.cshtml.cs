using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using System.IO;

namespace webapp.Pages
{
    public class IndexModel : PageModel
    {

        public void OnPost()
        {
            SqlConnection con = new SqlConnection();

            SqlCommand cmd = new SqlCommand("SELECT * FROM SomeTable WHERE SomeColumn = '" + Request.Form["RandomWord"] + "'", con);
            
            String response = Request.Form["YourName"] + ", here is the result: " + cmd.ExecuteScalar();

            MemoryStream body = new MemoryStream();

            StreamWriter sw = new StreamWriter(body);
            sw.Write(response);
            sw.Flush();

            Response.Body.Write(new ReadOnlySpan<byte>(body.ToArray () ) );
        }
    }
}
