using System;
using Bug.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject
{
  [TestClass()]
  public class TimeEntryTest
  {
    private TestContext testContextInstance;

    [TestMethod()]
    public void TimeEntryConstructorTest()
    {
      var before = DateTime.Now;
      TimeEntry e = new TimeEntry("text", "reference");
      var after = DateTime.Now;

      Assert.AreEqual("text", e.Text);
      Assert.AreEqual("reference", e.Reference);

      Assert.IsNull(e.To);

      Assert.IsTrue(before <= e.From);
      Assert.IsTrue(e.From <= after);
    }

    [TestMethod()]
    public void TimeEntryParseConstructorTest()
    {
      TimeEntry e = new TimeEntry("<tr><td>text</td><td>reference</td><td>30-8-2012 1:07:40</td><td>30-8-2012 1:07:50</td><td>00h:00m:10s</td></tr>");

      Assert.AreEqual("text", e.Text);
      Assert.AreEqual("reference", e.Reference);

      Assert.AreEqual(new DateTime(2012, 8, 30, 1, 7, 40), e.From);
      Assert.AreEqual(new DateTime(2012, 8, 30, 1, 7, 50), e.To);
      Assert.AreEqual(10, e.RunTime.TotalSeconds);
    }

    [TestMethod()]
    public void ToStringTest()
    {
      String s;

      s = "<tr><td>text</td><td>reference</td><td>30-8-2012 1:07:40</td><td>30-8-2012 1:07:50</td><td>00h:00m:10s</td></tr>";
      Assert.AreEqual(s, new TimeEntry(s).ToString());

      s = "<tr><td>text</td><td></td><td>30-8-2012 1:07:40</td><td>30-8-2012 1:07:50</td><td>00h:00m:10s</td></tr>";
      Assert.AreEqual(s, new TimeEntry(s).ToString());

      s = "<tr><td>text</td><td>reference</td><td>30-7-2012 23:00:00</td><td>30-8-2012 1:00:00</td><td>02h:00m:00s</td></tr>";
      Assert.AreEqual(s, new TimeEntry(s).ToString());

      s = "<tr><td></td><td></td><td>30-8-2012 1:07:40</td><td>30-8-2012 1:07:50</td><td>00h:00m:10s</td></tr>";
      Assert.AreEqual(s, new TimeEntry(s).ToString());
    }
  }
}
