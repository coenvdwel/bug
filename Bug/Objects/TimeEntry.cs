using System;
using Bug.Utilities;

namespace Bug.Objects
{
  public class TimeEntry
  {
    public string Text { get; set; }
    public string Reference { get; set; }
    public DateTime From { get; set; }
    public DateTime? To { get; set; }

    public TimeSpan RunTime { get { return (To ?? DateTime.Now) - From; } }

    public TimeEntry(string text, string reference)
    {
      Text = text;
      Reference = reference;
      From = DateTime.Now;
    }

    public TimeEntry(string s)
    {
      var line = s.Substring(8, s.Length - 18);
      var split = line.Split(new[] { "</td><td>" }, StringSplitOptions.None);

      Text = split[0].Trim();
      Reference = split[1].Trim();
      From = DateTime.Parse(split[2].Trim());
      To = DateTime.Parse(split[3].Trim());
    }

    public override string ToString()
    {
      return String.Format("<tr><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td>{4}</td></tr>", Text, Reference, From, To ?? DateTime.Now, RunTime.ToSimpleString());
    }
  }
}