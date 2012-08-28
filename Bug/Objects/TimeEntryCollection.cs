using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Bug.Utilities;

namespace Bug.Objects
{
  public class TimeEntryCollection
  {
    private List<TimeEntry> _entries;
    private string _file;

    public TimeEntry Current = null;

    public string Elapsed
    {
      get
      {
        var s = _entries.Sum(x => x.Duration);
        if (Current != null) s += Current.CurrentRunTime;

        return DateTimeUtility.GetTimeFromSeconds(s);
      }
    }

    public TimeEntryCollection()
    {
      _entries = new List<TimeEntry>();

      var folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), Application.ProductName);
      if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);

      _file = Path.Combine(folder, DateTime.Now.ToString("yyyyMMdd") + ".bug");
      if (!File.Exists(_file)) File.WriteAllText(_file, String.Empty);

      foreach (var line in File.ReadAllLines(_file))
      {
        _entries.Add(TimeEntry.FromString(line));
      }
    }

    public void Save()
    {
      if (Current != null)
      {
        Current.Duration += Current.CurrentRunTime;
        File.AppendAllLines(_file, new[] { Current.ToString() });
      }
    }

    public void Insert(TimeEntry entry)
    {
      Save();

      Current = entry;
      _entries.Add(entry);
    }
  }
}