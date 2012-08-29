using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Bug.Objects
{
  public class TimeEntryCollection
  {
    private List<TimeEntry> _entries;
    private string _fileName;

    public DateTime LastSaveTime { get; set; }
    public string FileName { get { return _fileName; } }
    public TimeEntry Current { get; private set; }
    public TimeSpan RunTime { get { return new TimeSpan(_entries.Sum(r => r.RunTime.Ticks)); } }

    public TimeEntryCollection()
    {
      var folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), Application.ProductName);

      _entries = new List<TimeEntry>();
      _fileName = Path.Combine(folder, DateTime.Now.ToString("yyyyMMdd") + ".html");

      if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);
      if (!File.Exists(_fileName)) File.WriteAllText(_fileName, String.Empty);

      Load();
    }

    private void Load()
    {
      LastSaveTime = DateTime.Now;
      var lines = File.ReadAllLines(_fileName);
      for (var i = 1; i < lines.Length - 1; i++)
      {
        _entries.Add(new TimeEntry(lines[i]));
      }
    }

    public void Save()
    {
      var sb = new StringBuilder();

      sb.Append("<html><head>");
      sb.Append("<title>" + Path.GetFileNameWithoutExtension(_fileName) + "</title>");
      sb.Append("<style type=\"text/css\">");
      sb.Append("body{background-color:#333;color:white;font-family:Arial;margin:100px 0 0 100px;}");
      sb.Append("table{margin-top: 50px;border-right:1px solid black;border-bottom:1px solid black;font-size:small;}tr,td,th{padding:2px 10px 2px 10px;}td,th{border-top:1px solid black;border-left: 1px solid black;}");
      sb.Append("</style></head><body>");
      sb.Append("<h1>"+ Path.GetFileNameWithoutExtension(_fileName) +"</h1>");
      sb.Append("<table cellpadding=0 cellspacing=0><thead><tr><th>Text</th><th>Reference</th><th>From</th><th>To</th><th>Duration</th></tr></thead><tbody>");
      sb.AppendLine();

      foreach (var entry in _entries) sb.AppendLine(entry.ToString());
      sb.Append("</tbody></table></body></html>");

      File.WriteAllText(_fileName, sb.ToString());
      LastSaveTime = DateTime.Now;
    }

    public void Insert(TimeEntry entry)
    {
      if(Current != null) Current.To = DateTime.Now;

      Current = entry;
      _entries.Add(entry);
    }
  }
}