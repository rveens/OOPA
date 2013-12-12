#region Using Statements

using System.Windows;
using System.Windows.Forms;

using OOPA.Factory;
using OOPA.IO.Parsing;

#endregion


namespace OOPA
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private OpenFileDialog openFileDialog;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            InitializeView();

            /* Node test = FactoryMethod<String, LogicNode>.create("AND");
            Node test1 = FactoryMethod<String, Node>.create("INPUT_HIGH"); */
        }


        private static void InitializeView()
        {
            //TODO: Add initialization code for the view here...
        }


        #region GUI Event Handlers

        /// <summary>
        /// Handles clicking the 'Open...' entry in the window's menu.
        /// </summary>
        /// <param name="sender">The sender of this event.</param>
        /// <param name="routedEventArgs">The arguments of this event.</param>
        protected void OnOpenCircuitFile(object sender, RoutedEventArgs routedEventArgs)
        {
            openFileDialog = new OpenFileDialog
            {
                Title = @"Open Circuit File",
                Filter = @"Text Files Only (.txt)|*.txt",
                FilterIndex = 1,
                Multiselect = false
            };

            var dialogResult = openFileDialog.ShowDialog();

            Circuit c = null;
            if (dialogResult == System.Windows.Forms.DialogResult.OK)
                c = CircuitFileParser.Parse(openFileDialog.FileName);
            c.Start();
            c.PrintResults();
        }

        /// <summary>
        /// Handles clicking the 'Close' entry in the window's menu.
        /// </summary>
        /// <param name="sender">The sender of this event.</param>
        /// <param name="routedEventArgs">The arguments of this event.</param>
        protected void OnClose(object sender, RoutedEventArgs routedEventArgs)
        {
            System.Windows.Application.Current.Shutdown();
        }

        #endregion
    }
}
