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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TextCopy;

namespace WheelDecideGeneratorApp
{
    /// <summary>
    /// Interaction logic for TextPreviewAndCopyButton.xaml
    /// </summary>
    public partial class TextPreviewAndCopyButton : UserControl
    {
        /// <summary>
        /// The text the user will see in the control.
        /// </summary>
        public string VisibleText { get; set; }

        /// <summary>
        /// Stores the height of the text box.
        /// </summary>
        public int TextBoxHeight { get; set; } = 18;

        public TextPreviewAndCopyButton()
        {
            InitializeComponent();
            ValuesTextBox.Text = VisibleText;
        }

        private void CopyButton_Click(object sender, RoutedEventArgs e)
        {
            //Courtsy of https://github.com/CopyText/TextCopy
            ClipboardService.SetText(VisibleText);
        }
    }
}
