using System;
using System.Windows.Forms;
using Bug.Forms;

namespace Bug
{
  static class Program
  {
    [STAThread]
    static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);

      using (var ctx = new ApplicationContext())
      {
        var form = new Popup(ctx);
        Application.Run(ctx);
      }
    }
  }
}