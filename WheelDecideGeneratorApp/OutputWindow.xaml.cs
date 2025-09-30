using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using TextCopy;

namespace WheelDecideGeneratorApp
{
    /// <summary>
    /// Interaction logic for OutputWindow.xaml
    /// </summary>
    public partial class OutputWindow : Window
    {
        WheelOutput WheelOutput;

        public OutputWindow(WheelOutput wheelOutput)
        {
            InitializeComponent();
            WheelOutput = wheelOutput;

            URLTextBox.Text = WheelOutput.GetWheelUrl();
        }

        /// <summary>
        /// Closes the window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void CopyLinkButton_Click(object sender, RoutedEventArgs e)
        {
            ClipboardService.SetText(WheelOutput.GetWheelUrl());
        }

        private void CopyValueButton_Click(object sender, RoutedEventArgs e)
        {
            switch (ValueComboBox.SelectedIndex)
            {
                case 0:
                    ClipboardService.SetText(WheelOutput.GetValues);
                    break;
                case 1:
                    ClipboardService.SetText(WheelOutput.GetBackgroundColours);
                    break;
                case 2:
                    ClipboardService.SetText(WheelOutput.GetTextColours);
                    break;
                case 3:
                    ClipboardService.SetText(WheelOutput.GetWeights);
                    break;
            }
        }
    }
}
