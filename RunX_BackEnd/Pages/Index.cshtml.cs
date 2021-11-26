using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using DataAccess.Context;
using DataAccess.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace RunX_BackEnd.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly RunXContext _db;

        public IndexModel(ILogger<IndexModel> logger, RunXContext db)
        {
            _logger = logger;
            _db = db;
        }

        public void OnGet()
        {      
           
        }

     



    }
}
