using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using TortugasKarp;

namespace CountDiscountTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ValueBigCostCorrect()
        {
            decimal cost = 10000;
            DateTime date = new DateTime(2022, 10, 29);
            decimal ex = 8900;
            decimal res = TortugasKarp.ClassHelper.CountDiscount.Sum(date,cost);
            Assert.AreEqual(res, ex);
        } 
        [TestMethod]
        public void ValueSmallCostCorrect()
        {
            decimal cost = 200;
            DateTime date = new DateTime(2022, 10, 29);
            decimal ex = 178 ;
            decimal res = TortugasKarp.ClassHelper.CountDiscount.Sum(date,cost);
            Assert.AreEqual(res, ex);
        }
        
        [TestMethod]
        public void DateInCorrect()
        {
            decimal cost = 100;
            DateTime date = new DateTime(2022, 10, 28);
            decimal ex = 100;
            decimal res = TortugasKarp.ClassHelper.CountDiscount.Sum(date,cost);
            Assert.AreEqual(res, ex);
        }
    }
}
