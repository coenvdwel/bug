using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Bug.Utilities
{
  class GlobalHotkeyWrapper
  {
    public static int MOD_ALT = 0x1;
    public static int MOD_CONTROL = 0x2;
    public static int MOD_SHIFT = 0x4;
    public static int MOD_WIN = 0x8;
    public static int WM_HOTKEY = 0x312;

    [DllImport("user32.dll")]
    private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vlc);

    [DllImport("user32.dll")]
    private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

    private static int keyId;
    public static void RegisterHotKey(Form f, Keys key)
    {
      int modifiers = 0;

      if ((key & Keys.Alt) == Keys.Alt)
        modifiers = modifiers | MOD_ALT;

      if ((key & Keys.Control) == Keys.Control)
        modifiers = modifiers | MOD_CONTROL;

      if ((key & Keys.Shift) == Keys.Shift)
        modifiers = modifiers | MOD_SHIFT;

      Keys k = key & ~Keys.Control & ~Keys.Shift & ~Keys.Alt;
      keyId = f.GetHashCode();
      RegisterHotKey((IntPtr)f.Handle, keyId, (int)modifiers, (int)k);
    }

    private delegate void Func();

    public static void UnregisterHotKey(Form f)
    {
      UnregisterHotKey(f.Handle, keyId);
    }
  }
}