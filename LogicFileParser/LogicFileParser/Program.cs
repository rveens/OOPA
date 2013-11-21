using System;
using System.Windows.Forms;

using Parser.IO.Parsing;


namespace LogicFileParser
{
    public class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Title = "Open Circuit File";
            openFileDialog.Filter = "Text Files (.txt)|*.txt|All Files(*.*)|*.*";
            openFileDialog.FilterIndex = 1;

            openFileDialog.Multiselect = false;
            DialogResult dialogResult = openFileDialog.ShowDialog();

            if (dialogResult == DialogResult.OK)
                CircuitFileParser.Parse(openFileDialog.FileName);

            Console.Read();
        }
    }
}
