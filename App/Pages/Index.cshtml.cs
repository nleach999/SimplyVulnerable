using App.Interfaces;
using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;

namespace App.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        private readonly IDBWrite _db;


        public IndexModel(ILogger<IndexModel> logger, IDBWrite db)
        {
            _logger = logger;
            _db = db;
        }

        public void OnPost()
        {
            String response = _db.WriteToDB(Request.Form["some_value"]);

            Response.StatusCode = 202;
            Response.Body.Write(new ReadOnlySpan<byte>(Encoding.UTF8.GetBytes(response.ToArray())));
        }

        public void OnGet()
        {

        }
    }
}