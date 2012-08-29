using System;

namespace Bug.Utilities
{
  public static class TimeSpanExtensions
  {
    public static string ToSimpleString(this TimeSpan t)
    {
      return String.Format("{0:D2}h:{1:D2}m:{2:D2}s", t.Hours, t.Minutes, t.Seconds);
    }
  }
}