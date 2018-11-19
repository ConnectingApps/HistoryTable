using System;
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

        public ValuesController(FinanceContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<int> Get(DateTime? moment)
        {
            if (moment == null) moment = DateTime.UtcNow;
            var result = _context.BankAccounts.FromSql($"select * from BankAccounts FOR SYSTEM_TIME AS OF {moment}")
                .FirstOrDefault();
            if (result == null) return 0;
            return result.Euros;
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] Money money)
        {
            // ReSharper disable once PossibleNullReferenceException, table has been seeded
            _context.BankAccounts.SingleOrDefault().Euros = money.Euros;
            await _context.SaveChangesAsync();
            return Ok("Euros updated");
        }
    }
}