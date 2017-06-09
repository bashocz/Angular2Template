using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Angular2WithAspNetCore.Web.Controllers
{
    [Route("api/[controller]")]
    public class BankController : Controller
    {
        private static AccountSummary[] _accountSummaries = new AccountSummary[]
        {
            new AccountSummary{ AccountNumber = "123-465-7890", Type = AccountType.Checking, Name = "Petr's checking account", Balance = 1234.56m, },
            new AccountSummary{ AccountNumber = "987-654-3210", Type = AccountType.Savings, Name = "Petr's savings account", Balance = 123455.67m, },
            new AccountSummary{ AccountNumber = "111-222-3333", Type = AccountType.Credit, Name = "Platinum credit card", Balance = 123.45m, },
        };

        private static Random _random = new Random();

        [HttpGet("[action]")]
        public IActionResult GetAccountSummaries()
        {
            return new ObjectResult(_accountSummaries);
        }

        [HttpGet("[action]/{id}")]
        public IActionResult GetAccountDetail(string id)
        {
            var summary = _accountSummaries.FirstOrDefault(a => a.AccountNumber == id);
            if (summary == null)
            {
                return NotFound();
            }

            var transactions = new List<AccountTransaction>();
            for (int idx = 0; idx < 15; idx++)
            {
                transactions.Add(new AccountTransaction
                {
                    TransactionDate = DateTimeOffset.Now - TimeSpan.FromDays(idx),
                    Description = $"Server transaction #{idx}",
                    Amount = Convert.ToDecimal(_random.NextDouble() * 500 - 250),
                });
            }

            return new ObjectResult(new AccountDetail
            {
                AccountSummary = summary,
                AccountTransactions = transactions.ToArray(),
            });
        }
    }

    public enum AccountType
    {
        Checking,
        Savings,
        Credit,
    }

    public class AccountSummary
    {
        public string AccountNumber { get; set; }
        public AccountType Type { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; }
    }

    public class AccountTransaction
    {
        public DateTimeOffset TransactionDate { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
    }

    public class AccountDetail
    {
        public AccountSummary AccountSummary { get; set; }
        public AccountTransaction[] AccountTransactions { get; set; }
    }
}
