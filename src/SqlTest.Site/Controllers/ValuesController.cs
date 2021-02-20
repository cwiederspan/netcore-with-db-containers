using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using SqlTest.Site.Models;

namespace SqlTest.Site.Controllers {

    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase {

        private readonly DataContext Context;

        public ValuesController(DataContext context) {

            System.Diagnostics.Debug.WriteLine($"ValuesController.ctor()...");

            this.Context = context;
        }

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> GetAsync() {

            System.Diagnostics.Debug.WriteLine("ValuesController.GetAsync()...");

            try {

                var items = await this.Context.Items.ToListAsync();

                return new JsonResult(items);

            }
            catch (Exception ex) {

                // Can return content that matches what your error filter returns.
                return this.StatusCode(500, ex.Message);
            }
        }
    }
}
