using System;
using Bug.Utilities;

namespace Bug.Objects
{
  public class TimeEntry
  {
    public string Text { get; set; }
    public string Reference { get; set; }
    public int Duration { get; set; }
    public DateTime CreationTime { get; set; }

    public int CurrentRunTime
    {
      get
      {
        return (int)(DateTime.Now - CreationTime).TotalSeconds;
      }
    }

    public string Elapsed
    {
      get
      {
        return DateTimeUtility.GetTimeFromSeconds(Duration + CurrentRunTime);
      }
    }

    public TimeEntry(string text, string reference, int duration)
    {
      Text = text;
      Reference = reference;
      Duration = duration;

      CreationTime = DateTime.Now;
    }

    public override string ToString()
    {
      return String.Format("{0}##{1}##{2}", Text, Reference, Duration);
    }

    public static TimeEntry FromString(string line)
    {
      var s = line.Split(new[] { "##" }, StringSplitOptions.None);
      return new TimeEntry(s[0], s[1], Int32.Parse(s[2]));
    }
  }
}