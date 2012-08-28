using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Bug.Objects;
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

    private void notificationIcon_Click(object sender, EventArgs e)
    {
      if (((MouseEventArgs)e).Button == MouseButtons.Left)
      {
        Location = new Point(Cursor.Position.X - (Width / 2), Cursor.Position.Y - Height - 25);

        Show();
        Focus();
        tbEntry.Focus();
        tbEntry.SelectAll();
      }
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
      _entries.Save();
      _ctx.ExitThread();
    }

    private void tbEntry_KeyPress(object sender, KeyPressEventArgs e)
    {
      _lastConfirm = DateTime.Now;
      tbReference.Text = String.Empty;

      if (e.KeyChar == (char)Keys.Return)
      {
        Hide();
      }
    }

    private void tbReference_KeyPress(object sender, KeyPressEventArgs e)
    {
      _lastConfirm = DateTime.Now;
      if (e.KeyChar == (char)Keys.Return)
      {
        Hide();
      }
    }

    private void Popup_Deactivate(object sender, EventArgs e)
    {
      if (Visible) Hide();

      if (tbEntry.Text == String.Empty && tbReference.Text == String.Empty) return;

      if (_entries.Current == null || tbEntry.Text != _entries.Current.Text || tbReference.Text != _entries.Current.Reference)
      {
        _entries.Insert(new TimeEntry(tbEntry.Text, tbReference.Text, 0));
      }
    }

    private void timer_Tick(object sender, EventArgs e)
    {
      lblToday.Text = "Today: " + _entries.Elapsed;
      lblCurrent.Text = "Current: " + (_entries.Current == null ? DateTimeUtility.GetTimeFromSeconds(0) : _entries.Current.Elapsed);

      if (!Visible && ((DateTime.Now - _lastConfirm).TotalMinutes > 15))
      {
        notificationIcon.ShowBalloonTip(2000);
      }
    }

    private void btnHide_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      Hide();
    }

    private void btnExport2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      MessageBox.Show("Sorry, still working on this!");
    }

    private void btnExport_Click(object sender, EventArgs e)
    {
      MessageBox.Show("Sorry, still working on this!");
    }
  }
}