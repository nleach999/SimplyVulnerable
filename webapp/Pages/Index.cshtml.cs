using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace webapp.Pages
{
    public class IndexModel : PageModel
    {

        [BindProperty]
        public string YourName { get; set; }
        [BindProperty]
        public string RandomWord { get; set; }


        public void OnPost()
        {
            SqlConnection con = new SqlConnection();

            SqlCommand cmd = new SqlCommand("SELECT * FROM SomeTable WHERE SomeColumn = '" + Request.Form["RandomWord"] + "'", con);
            
            ViewData["response"] = Request.Form["YourName"] + ", here is the result: " + cmd.ExecuteScalar ();
        }
    }
}
