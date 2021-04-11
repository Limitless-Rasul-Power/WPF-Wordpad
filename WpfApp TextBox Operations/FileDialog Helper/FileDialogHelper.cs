using Microsoft.Win32;

namespace WpfApp_TextBox_Operations
{
    public static class FileDialogHelper
    {
        public static string HandleDialogThenGetFileName(FileDialog fileDialog)
        {
            fileDialog.DefaultExt = ".txt";
            fileDialog.Filter = "Text Files(*txt)|*txt";

            return fileDialog.ShowDialog() == true ? fileDialog.FileName : string.Empty;
        }


    }
}
