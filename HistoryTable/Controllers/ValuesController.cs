using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HistoryTable.WebModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HistoryTable.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly FinanceContext _context;

        //private static bool seedingSucceeded = false;

        /*private static void Seed(FinanceContext context)
        {
            context.Database.Migrate();
            if (!context.BankAccounts.Any())
            {              
                context.BankAccounts.Add(new BankAccount
                {
                    Euros = 0,
                });
                context.SaveChanges();
            }
            seedingSucceeded = true;
        }*/

        public ValuesController(FinanceContext context)
        {
            _context = context;
            /*if (!seedingSucceeded)
            {
                Seed(_context);
            }*/
        }

        [HttpGet]
        public ActionResult<int> Get(DateTime? moment)
        {
            if (moment == null)
            {
                moment = DateTime.UtcNow;
            }
            var result = _context.BankAccounts.FromSql($"select * from BankAccounts FOR SYSTEM_TIME AS OF {moment}").FirstOrDefault();
            if (result == null)
            {
                return 0;
            }
            return result.Euros;
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] Money money)
        {
            _context.BankAccounts.SingleOrDefault().Euros = money.Euros;
            await _context.SaveChangesAsync();
            return Ok("Euros updated");
        }
    }
}
