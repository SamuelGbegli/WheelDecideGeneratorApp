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

namespace WheelDecideGeneratorApp
{
    /// <summary>
    /// Interaction logic for OutputWindow.xaml
    /// </summary>
    public partial class OutputWindow : Window
    {
        TextOutput TextOutput;

        public OutputWindow(TextOutput textOutput)
        {
            InitializeComponent();
            TextOutput = textOutput;

            ValuesTextBox.Text = textOutput.ValueString;
            BackgroundTextBox.Text = textOutput.BackgroundColourString;
            TextTextBox.Text = textOutput.TextColourString;
            WeightTextBox.Text = textOutput.WeightString;
            URLTextBox.Text = textOutput.URL;
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
    }
}
