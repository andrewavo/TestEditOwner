using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestEditOwner.Model;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestEditOwner
{
    public class SummaryResult
    {
        public string AccountNumber;
        public decimal? Balance;
        public string OrgType;
        public string Owner;
    }

    [Route("")]
    public class EditOwner : Controller
    {
        Test1Context _context;

        public EditOwner(Test1Context context)
        {
            _context = context;
        }

        private List<SummaryResult> GetSummaryList()
        {
            List<SummaryResult> res = new List<SummaryResult>();
            var acnts = _context.Account;


            foreach (Account a in acnts)
            {
                _context.Entry(a).Collection(x => x.Person).Load();
                _context.Entry(a).Collection(x => x.LegalEntity).Load();
                foreach (Person p in a.Person)
                {
                    SummaryResult sr = new SummaryResult();
                    sr.AccountNumber = a.Number;
                    sr.Balance = a.Balance;
                    sr.OrgType = "физ";
                    sr.Owner = p.SecondName + " " + p.FirstName;
                    res.Add(sr);
                }
                foreach (LegalEntity le in a.LegalEntity)
                {
                    SummaryResult sr = new SummaryResult();
                    sr.AccountNumber = a.Number;
                    sr.Balance = a.Balance;
                    sr.OrgType = "юр";
                    sr.Owner = le.Type + " " + le.Name;
                    res.Add(sr);
                }
            }
            return res;
        }

        private void MakeChange()
        {
            Account a1 = _context.Account.Where(a => a.Number == "5678").First();
            Account a2 = _context.Account.Where(a => a.Number == "7876").First();
            if (a1 != null && a2 != null)
            {
                _context.Entry(a1).Collection(x => x.Person).Load();
                _context.Entry(a1).Collection(x => x.LegalEntity).Load();
                _context.Entry(a2).Collection(x => x.Person).Load();
                _context.Entry(a2).Collection(x => x.LegalEntity).Load();
                foreach (Person p in a1.Person)
                {
                    p.AccountId = a2.AccoutId;
                    _context.Update(p);
                }
                foreach (LegalEntity le in a1.LegalEntity)
                {
                    le.AccountId = a2.AccoutId;
                    _context.Update(le);
                }
                foreach (Person p in a2.Person)
                {
                    p.AccountId = a1.AccoutId;
                    _context.Update(p);
                }
                foreach (LegalEntity le in a2.LegalEntity)
                {
                    le.AccountId = a1.AccoutId;
                    _context.Update(le);
                }
            }
            _context.SaveChanges();
        }

        [HttpGet]
        public IActionResult List()
        {
            return View("~/Result.cshtml", GetSummaryList());
        }

        [Route("EditOwner/Change")]
        public IActionResult Change()
        {
            MakeChange();
            return View("~/Result.cshtml", GetSummaryList());
        }
    }
}
