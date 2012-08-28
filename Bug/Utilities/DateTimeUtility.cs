using System;

namespace Bug.Utilities
{
  public static class DateTimeUtility
  {
    public static string GetTimeFromSeconds(int seconds)
    {
      if (seconds == 0) return "None";

      var minutes = seconds / 60;
      seconds -= minutes * 60;

      var hours = minutes / 60;
      minutes -= hours * 60;
      seconds -= hours * 60 * 60;

      return String.Format("{0}{1}{2}", hours > 0 ? hours + " hrs " : String.Empty, minutes > 0 ? minutes + " min " : String.Empty, seconds + " secs");
    }
  }
}