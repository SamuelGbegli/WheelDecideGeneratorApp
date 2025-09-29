using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WheelDecideGeneratorApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        /// <summary>
        /// Stores the values inputted by the user.
        /// </summary>
        ObservableCollection<SegmentInput> Segments { get; set; } = new ObservableCollection<SegmentInput>();

        public MainWindow()
        {
            InitializeComponent();

            //Sets datagrid items
            segmentDataGrid.ItemsSource = Segments;

        }

        /// <summary>
        /// Sets the maximum of the multiplier control and whether the user can click on the add button.
        /// </summary>
        void updateAddButtonAndMultiplierMaximum()
        {
            //Disables the add button if adding a new value would mean an output of over 100
            if((Segments.Count + 1) * multiplierUpDown.Value > 100)
            {
                addButton.IsEnabled = false;
            }
            //Enables the add button the total would be 100 or less
            else
            {
                addButton.IsEnabled = true;
            }
            //Updates multiplier control to ensure maximum value results in 100 or fewer 
            multiplierUpDown.Maximum = Segments.Count > 0 ? 100 / Segments.Count : 100;
            if (multiplierUpDown.Value > multiplierUpDown.Maximum)
            {
                multiplierUpDown.Value = multiplierUpDown.Maximum;
            }
        }

        /// <summary>
        /// Sets the "Total values" label.
        /// </summary>
        void setTotalValuesLabel()
        {
            totalValuesLabel.Content = $"Total values: {Segments.Count}";
        }

        /// <summary>
        /// Enables or disables the button to remove all items in the list when the value changes
        /// </summary>
        void updateRemoveAllButton()
        {
            if (Segments.Count > 0) 
            {
                removeAllButton.IsEnabled = true;
            }
            else removeAllButton.IsEnabled = false;
}

        /// <summary>
        /// Enables or disables the button to generate the output based on the number of values.
        /// </summary>
        void updateGenerateButton()
        {
            if (Segments.Count > 0)
            {
                generateButton.IsEnabled = true;
            }
            else
            {
                generateButton.IsEnabled= false;
            }
        }

        /// <summary>
        /// Updates all controls affected by adding or removing a value
        /// </summary>
        void updateControls()
        {
            setTotalValuesLabel();
            updateAddButtonAndMultiplierMaximum();
            updateRemoveAllButton();
            if(generateButton != null) updateGenerateButton();
        }

        /// <summary>
        /// Adds an item to the list.
        /// </summary>
        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            Segments.Add(new());
            updateControls();       
        }

        /// <summary>
        /// Enables or disables the "remove selcected" button if there is at least one row selected.
        /// </summary>
        private void segmentDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (segmentDataGrid.SelectedItems.Count > 0)
            {
                removeSelectedButton.IsEnabled = true;
            }
            else removeSelectedButton.IsEnabled = false;
        }

        /// <summary>
        /// Removes the values currently selected by the user.
        /// </summary>
        private void removeSelectedButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedItems = segmentDataGrid.SelectedItems;
            var itemsToRemove = Segments.Where(s =>  selectedItems.Contains(s)).ToList();
            foreach (var item in itemsToRemove)
            {
                Segments.Remove(item);
            }
            updateControls();
        }

        /// <summary>
        /// Removes all values in the grid.
        /// </summary>
        private void removeAllButton_Click(object sender, RoutedEventArgs e)
        {
            Segments.Clear();
            updateControls();
        }

        private void multiplierUpDown_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            updateControls();
        }

        /// <summary>
        /// Outputs values to be copied on Wheel Decide's site.
        /// </summary>
        private void generateButton_Click(object sender, RoutedEventArgs e)
        {
            var outputList = new List<SegmentOutput>();
            for (int i = 0; i < multiplierUpDown.Value; i++)
            {
                for (int j = 0; j < Segments.Count; j++)
                {
                    outputList.Add(new(Segments[j]));
                }
            }
            if (shuffleSegmentsCheckBox.IsChecked == true)
            {
                int i = outputList.Count;
                while (i > 1)
                {
                    i--;
                    int k = Random.Shared.Next(i + 1);
                    var value = outputList[k];
                    outputList[k] = outputList[i];
                    outputList[i] = value;
                }
            }
            var textOutput = new TextOutput(outputList);

            new OutputWindow(textOutput).ShowDialog();
        }

    }
}