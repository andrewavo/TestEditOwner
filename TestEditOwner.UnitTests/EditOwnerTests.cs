using System;
using System.Collections.Generic;
using TestEditOwner;
using NUnit.Framework;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;

namespace TestEditOwner.UnitTests
{
    [TestFixture]
    public class EditOwnerTests
    {
        [Test]
        public void TestEditOwner()
        {
            EditOwner eo = new EditOwner(new Model.Test1Context());

            var res = (eo.List() as ViewResult).Model as List<SummaryResult>;

            Assert.AreEqual("5678", res[0].AccountNumber);
            Assert.AreEqual(900M, res[0].Balance);
            Assert.AreEqual("физ", res[0].OrgType);
            Assert.AreEqual("Иванов Андрей", res[0].Owner);
           
            Assert.AreEqual("7876", res[1].AccountNumber);
            Assert.AreEqual(100M, res[1].Balance);
            Assert.AreEqual("юр", res[1].OrgType);
            Assert.AreEqual("ЗАО Рога и копыта", res[1].Owner);

            Assert.AreEqual("7656", res[2].AccountNumber);
            Assert.AreEqual(200M, res[2].Balance);
            Assert.AreEqual("физ", res[2].OrgType);
            Assert.AreEqual("Петров Сергей", res[2].Owner);

            res = (eo.Change() as ViewResult).Model as List<SummaryResult>;
            Assert.AreEqual("5678", res[0].AccountNumber);
            Assert.AreEqual(900M, res[0].Balance);
            Assert.AreEqual("юр", res[0].OrgType);
            Assert.AreEqual("ЗАО Рога и копыта", res[0].Owner);

            Assert.AreEqual("7876", res[1].AccountNumber);
            Assert.AreEqual(100M, res[1].Balance);
            Assert.AreEqual("физ", res[1].OrgType);
            Assert.AreEqual("Иванов Андрей", res[1].Owner);

            Assert.AreEqual("7656", res[2].AccountNumber);
            Assert.AreEqual(200M, res[2].Balance);
            Assert.AreEqual("физ", res[2].OrgType);
            Assert.AreEqual("Петров Сергей", res[2].Owner);

            res = (eo.Change() as ViewResult).Model as List<SummaryResult>;
            Assert.AreEqual("5678", res[0].AccountNumber);
            Assert.AreEqual(900M, res[0].Balance);
            Assert.AreEqual("физ", res[0].OrgType);
            Assert.AreEqual("Иванов Андрей", res[0].Owner);

            Assert.AreEqual("7876", res[1].AccountNumber);
            Assert.AreEqual(100M, res[1].Balance);
            Assert.AreEqual("юр", res[1].OrgType);
            Assert.AreEqual("ЗАО Рога и копыта", res[1].Owner);

            Assert.AreEqual("7656", res[2].AccountNumber);
            Assert.AreEqual(200M, res[2].Balance);
            Assert.AreEqual("физ", res[2].OrgType);
            Assert.AreEqual("Петров Сергей", res[2].Owner);
        }
    }
}

