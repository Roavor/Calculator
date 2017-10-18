using System;
using System.Windows;
using System.Windows.Controls;

namespace BrainAcademy.SampleCalculator
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

        private void Grid_Click(object sender, RoutedEventArgs e)
        {
            
            Button btn = e.Source as Button;
            if (btn == null)
                return;
            // Event handler work only for button with content
            string value = btn.Content.ToString();
            if (String.IsNullOrEmpty(value))
                return; //pisos
            switch(value)
            {
                // delete TextBoxMain.Text
                case "C":
                    TextBoxMain.Text = "0";
                    break;

                // counting value with this library 
                // https://ncalc.codeplex.com/
                case "=":
                    try
                    {
                        NCalc.Expression exp = new NCalc.Expression(TextBoxMain.Text);
                        TextBoxMain.Text = exp.Evaluate().ToString().Replace(",",".");
                    }
                    catch
                    {
                        TextBoxMain.Text = "Error";
                    }
                    break;
                
                // add new value to TextBoxMain
                default:
                    TextBoxMain.Text = TextBoxMain.Text.TrimStart('0') + value;                    
                    break;
            }
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Delete last symbol in TextBoxMain
            if (TextBoxMain.Text.Length>1)
            {
                TextBoxMain.Text = TextBoxMain.Text.Remove(TextBoxMain.Text.Length - 1);
            }
            else
            {
                TextBoxMain.Text = "0";
            }
        }
    }
}
