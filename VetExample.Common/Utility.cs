using System.Windows.Forms;

namespace VetExample.Common.Ui
{
    public sealed class Utility
    {
        public static void Clessidra(bool tipo)
        {
            if (tipo)
                Cursor.Current = Cursors.WaitCursor;
            else
                Cursor.Current = Cursors.Default;
        }
    }
}
