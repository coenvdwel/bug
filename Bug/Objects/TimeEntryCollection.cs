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
    private string _folder;

    public DateTime LastSaveTime { get; set; }
    public string Folder { get { return _folder; } }
    public string FileName { get { return _fileName; } }
    public TimeEntry Current { get; private set; }
    public TimeSpan RunTime { get { return new TimeSpan(_entries.Sum(r => r.RunTime.Ticks)); } }

    public TimeEntryCollection()
    {
      _entries = new List<TimeEntry>();
      _fileName = DateTime.Now.ToString("yyyyMMdd") + ".html";
      _folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), Application.ProductName);

      if (!Directory.Exists(_folder)) Directory.CreateDirectory(_folder);
      if (!File.Exists(Path.Combine(_folder, _fileName))) File.WriteAllText(Path.Combine(_folder, _fileName), String.Empty);

      var lines = File.ReadAllLines(Path.Combine(_folder, _fileName));
      for (var i = 1; i < lines.Length - 1; i++)
      {
        _entries.Add(new TimeEntry(lines[i]));
      }
    }

    public void Save()
    {
      // day check
      _fileName = DateTime.Now.ToString("yyyyMMdd") + ".html";
      _entries.RemoveAll(e => e.From < DateTime.Today);

      var sb = new StringBuilder("<html><head>");
      sb.Append("<title>" + _fileName + "</title>");
      sb.Append("<style type=\"text/css\">");
      sb.Append("body{background-color:#333;color:white;font-family:Arial;margin:100px 0 0 100px;}");
      sb.Append("table{margin-top: 50px;border-right:1px solid black;border-bottom:1px solid black;font-size:small;}tr,td,th{padding:2px 10px 2px 10px;}td,th{border-top:1px solid black;border-left: 1px solid black;}");
      sb.Append("</style></head><body>");
      sb.Append("<h1>" + _fileName + "</h1>");
      sb.AppendLine("<table cellpadding=0 cellspacing=0><thead><tr><th>Text</th><th>Reference</th><th>From</th><th>To</th><th>Duration</th></tr></thead><tbody>");
      foreach (var entry in _entries) sb.AppendLine(entry.ToString());
      sb.Append("</tbody></table></body></html>");

      LastSaveTime = DateTime.Now;
      File.WriteAllText(Path.Combine(_folder, _fileName), sb.ToString());
    }

    public void Insert(TimeEntry entry)
    {
      if (Current != null) Current.To = DateTime.Now;
      Current = entry;
      if (Current != null) _entries.Add(entry);
    }
  }
}