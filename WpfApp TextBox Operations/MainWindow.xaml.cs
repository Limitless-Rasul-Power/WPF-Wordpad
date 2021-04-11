using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp_TextBox_Operations
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnOff_Click(object sender, RoutedEventArgs e)
        {
            SimulateToggleButton(BtnOff);
            ChangeButtonSettingsWhenOffButtonClicked();
        }

        private void BtnOn_Click(object sender, RoutedEventArgs e)
        {
            SimulateToggleButton(BtnOn);
            ChangeButtonSettingsWhenOnButtonClicked();
        }

        private void BtnOpen_Click(object sender, RoutedEventArgs e)
        {
            string fileName = FileDialogHelper.HandleDialogThenGetFileName(new OpenFileDialog());

            if (fileName != string.Empty)
            {
                TxtBlckFilePath.Text = fileName;
                TxtBxData.Text = File.ReadAllText(fileName);
            }

            TxtBxData.Focus();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(TxtBlckFilePath.Text))
            {
                File.WriteAllText(TxtBlckFilePath.Text, TxtBxData.Text);

                MessageBox.Show("Saved successfully.");
            }
            else
            {
                MessageBox.Show("Invalid file path.");
            }

            TxtBxData.Focus();
        }

        private void TxtBxData_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (BtnOn.IsEnabled)
            {
                if (!string.IsNullOrWhiteSpace(TxtBlckFilePath.Text))
                {
                    File.WriteAllText(TxtBlckFilePath.Text, TxtBxData.Text);
                }
            }
        }

        private void BtnSaveAs_Click(object sender, RoutedEventArgs e)
        {
            string fileName = FileDialogHelper.HandleDialogThenGetFileName(new SaveFileDialog());

            if (fileName != string.Empty)
            {
                File.WriteAllText(fileName, TxtBxData.Text);

                MessageBox.Show("Saved successfully.");
            }

            TxtBxData.Focus();
        }

        private void BtnCut_Click(object sender, RoutedEventArgs e)
        {
            TxtBxData.Cut();
            TxtBxData.Focus();
        }

        private void BtnCopy_Click(object sender, RoutedEventArgs e)
        {
            TxtBxData.Copy();
            TxtBxData.Focus();
        }

        private void BtnPaste_Click(object sender, RoutedEventArgs e)
        {
            TxtBxData.Paste();
        }

        private void BtnSelectAll_Click(object sender, RoutedEventArgs e)
        {
            TxtBxData.SelectAll();
            TxtBxData.Focus();
        }
        private void BtnUndo_Click(object sender, RoutedEventArgs e)
        {            
            if (TxtBxData.CanUndo)
            {
                TxtBxData.Undo();
            }
             TxtBxData.Focus();
        }


        #region HelperMethods
        private void ChangeButtonSettingsWhenOffButtonClicked()
        {
            BtnOn.IsEnabled = true;
            BtnOn.Background = new SolidColorBrush(Colors.SpringGreen);
            BtnOn.Cursor = Cursors.Hand;
            BtnOn.Content = "ON";
        }
        private void ChangeButtonSettingsWhenOnButtonClicked()
        {
            BtnOff.IsEnabled = true;
            BtnOff.Background = new SolidColorBrush(Colors.IndianRed);
            BtnOff.Cursor = Cursors.Hand;
            BtnOff.Content = "OFF";
        }
        private void SimulateToggleButton(Button button)
        {                                    
            button.Content = default;
            button.Cursor = Cursors.Arrow;
            button.IsEnabled = false;
            button.BorderThickness = new Thickness(0);
            button.IsEnabled = false;
        }

        #endregion

    }

}
