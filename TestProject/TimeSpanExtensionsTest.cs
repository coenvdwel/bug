using Bug.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestProject
{
  [TestClass()]
  public class TimeSpanExtensionsTest
  {
    [TestMethod()]
    public void ToSimpleStringTest()
    {
      var a = DateTime.Now;
      var b = a;

      Assert.AreEqual("00h:00m:00s", (b - a).ToSimpleString());

      b = a.AddSeconds(59);
      Assert.AreEqual("00h:00m:59s", (b - a).ToSimpleString());

      b = a.AddMinutes(1);
      Assert.AreEqual("00h:01m:00s", (b - a).ToSimpleString());

      b = a.AddHours(1);
      Assert.AreEqual("01h:00m:00s", (b - a).ToSimpleString());

      b = a.AddSeconds(59).AddHours(1).AddMinutes(2);
      Assert.AreEqual("01h:02m:59s", (b - a).ToSimpleString());
    }
  }
}