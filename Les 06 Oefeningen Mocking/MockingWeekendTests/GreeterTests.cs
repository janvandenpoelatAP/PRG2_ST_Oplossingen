using Microsoft.VisualStudio.TestTools.UnitTesting;
using OefeningMockingWeekend;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;

namespace OefeningMockingWeekend.Tests
{
    [TestClass()]
    public class GreeterTests
    {
        [TestMethod()]
        public void GetMessage_Returns_Workhard_When_It_Is_Not_Weekend()
        {
            var dateGetter = new Mock<IDateGetter>();
            dateGetter.Setup(x => x.GetDate()).Returns(new DateTime(2020, 10, 19)); // --> Return a Monday
            var greeter = new Greeter(dateGetter.Object);
            Assert.AreEqual("Work hard, weekend is on his way....", greeter.GetMessage());
        }

        [TestMethod()]
        public void GetMessage_Returns_PartyTime_When_It_Is_Weekend()
        {
            var dateGetter = new Mock<IDateGetter>();
            dateGetter.Setup(x => x.GetDate()).Returns(new DateTime(2020, 10, 18)); // --> Return a Sunday
            var greeter = new Greeter(dateGetter.Object);
            Assert.AreEqual("Party time.....it's weekend", greeter.GetMessage());
        }
    }
}