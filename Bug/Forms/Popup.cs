using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Bug.Objects;
using Bug.Properties;
using Bug.Utilities;

namespace Bug.Forms
{
  public partial class Popup : Form
  {
    private ApplicationContext _ctx;
    private TimeEntryCollection _entries;
    private DateTime _lastConfirm;

    public Popup(ApplicationContext ctx)
    {
      _ctx = ctx;
      _entries = new TimeEntryCollection();

      InitializeComponent();
    }

    private void Popup_Load(object sender, EventArgs e)
    {
      cbInterval.Text = Settings.Default.BugInterval + (Settings.Default.BugInterval == 1 ? " minute" : " minutes");
    }

    #region Popup

    private void Popup_Deactivate(object sender, EventArgs e)
    {
      if (Visible)
      {
        tbReference.SelectAll();
        Hide();
      }

      if (tbEntry.Text == String.Empty && tbReference.Text == String.Empty) return;
      if (_entries.Current != null && tbEntry.Text == _entries.Current.Text && tbReference.Text == _entries.Current.Reference) return;

      _entries.Insert(new TimeEntry(tbEntry.Text, tbReference.Text));
      _entries.Save();
    }

    private void tbEntry_KeyPress(object sender, KeyPressEventArgs e)
    {
      tbReference.Text = String.Empty;
      tbReference_KeyPress(sender, e);
    }

    private void tbReference_KeyPress(object sender, KeyPressEventArgs e)
    {
      _lastConfirm = DateTime.Now;
      if (e.KeyChar == (char)Keys.Return)
      {
        tbReference.SelectAll();
        Hide();
      }
    }

    #endregion

    #region Notification Icon

    private void notificationIcon_Click(object sender, EventArgs e)
    {
      if (((MouseEventArgs)e).Button == MouseButtons.Left)
      {
        Location = new Point(Cursor.Position.X - (Width / 2), Cursor.Position.Y - Height - 25);

        Show();
        Focus();
        tbEntry.SelectAll();
        tbEntry.Focus();
      }
    }

    private void btnView_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      Process.Start(_entries.FileName);
    }

    private void btnHide_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      tbReference.SelectAll();
      Hide();
    }

    #region Context menu

    private void cbInterval_SelectedIndexChanged(object sender, EventArgs e)
    {
      Settings.Default.BugInterval = Int32.Parse(((string)cbInterval.SelectedItem).Substring(0, 2));
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
      _entries.Save();

      notificationIcon.Visible = false;
      _ctx.ExitThread();
    }

    #endregion

    #endregion

    #region Timer

    private void timer_Tick(object sender, EventArgs e)
    {
      lblToday.Text = "Today: " + _entries.RunTime.ToSimpleString();
      if (_entries.Current != null) lblCurrent.Text = "Current: " + _entries.Current.RunTime.ToSimpleString();

      if (!Visible && ((DateTime.Now - _lastConfirm).TotalMinutes >= Settings.Default.BugInterval))
      {
        notificationIcon.ShowBalloonTip(2000);
      }

      if ((DateTime.Now - _entries.LastSaveTime).TotalMinutes >= 1) _entries.Save();
    }

    #endregion
  }
}