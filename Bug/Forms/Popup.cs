using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
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

      cbInterval.Text = Settings.Default.BugInterval + (Settings.Default.BugInterval == 1 ? " minute" : " minutes");
      GlobalHotkeyWrapper.RegisterHotKey(this, Keys.Z | Keys.Alt);
    }

    private void Popup_FormClosing(object sender, FormClosingEventArgs e)
    {
      notificationIcon.Visible = false;
      GlobalHotkeyWrapper.UnregisterHotKey(this);
    }

    #region Popup

    private void Popup_Deactivate(object sender, EventArgs e)
    {
      if (Visible) Hide();

      if (tbEntry.Text == String.Empty && tbReference.Text == String.Empty) return;
      if (_entries.Current != null && tbEntry.Text == _entries.Current.Text && tbReference.Text == _entries.Current.Reference) return;

      _entries.Insert(new TimeEntry(tbEntry.Text, tbReference.Text));
      _entries.Save();
      btnStop.Enabled = true;
    }

    private void tbEntry_KeyPress(object sender, KeyPressEventArgs e)
    {
      tbReference.Text = String.Empty;
      tbReference_KeyPress(sender, e);
    }

    private void tbReference_KeyPress(object sender, KeyPressEventArgs e)
    {
      _lastConfirm = DateTime.Now;
      if (e.KeyChar == (char)Keys.Return) Hide();
    }

    private void btnView_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      Process.Start(Path.Combine(_entries.Folder, _entries.FileName));
    }

    private void btnStop_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      btnStop.Enabled = false;

      tbEntry.Text = String.Empty;
      tbReference.Text = String.Empty;
      lblCurrent.Text = " - pauzed -";

      _entries.Insert(null);
    }

    #endregion

    #region Notification Icon

    private void notificationIcon_Click(object sender, EventArgs e)
    {
      if (e == null || (((MouseEventArgs)e).Button == MouseButtons.Left))
      {
        Location = new Point(Cursor.Position.X - (Width / 2), Cursor.Position.Y - Height - 25);

        Show();

        Focus();
        tbReference.SelectAll();
      }
    }

    private void notificationIcon_BalloonTipClicked(object sender, EventArgs e)
    {
      notificationIcon_Click(null, null);
    }

    #endregion

    #region Context menu

    private void cbInterval_SelectedIndexChanged(object sender, EventArgs e)
    {
      Settings.Default.BugInterval = Int32.Parse(((string)cbInterval.SelectedItem).Substring(0, 2));
    }

    private void btnOpenDir_Click(object sender, EventArgs e)
    {
      Process.Start(_entries.Folder);
    }

    private void btnExit_Click(object sender, EventArgs e)
    {
      if (MessageBox.Show("Are you sure?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
      {
        notificationIcon.Visible = false;
        _entries.Save();
        _ctx.ExitThread();
      }
    }

    #endregion

    #region Timer

    private void timer_Tick(object sender, EventArgs e)
    {
      lblToday.Text = "Today: " + _entries.RunTime.ToSimpleString();
      if (_entries.Current != null) lblCurrent.Text = "Current: " + _entries.Current.RunTime.ToSimpleString();

      if (!Visible && ((DateTime.Now - _lastConfirm).TotalMinutes >= Settings.Default.BugInterval))
      {
        notificationIcon.ShowBalloonTip(1000);
      }

      if ((DateTime.Now - _entries.LastSaveTime).TotalMinutes >= 1) _entries.Save();
    }

    #endregion

    #region Global hotkey

    protected override void WndProc(ref Message m)
    {
      base.WndProc(ref m);

      if (m.Msg == GlobalHotkeyWrapper.WM_HOTKEY)
      {
        if (Visible) Popup_Deactivate(null, null);
        else notificationIcon_Click(null, null);
      }
    }

    #endregion
  }
}