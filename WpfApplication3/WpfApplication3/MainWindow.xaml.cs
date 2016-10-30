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

namespace WpfApplication3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        private Queue<string> operands = new Queue<string>();
        private Queue<string> operators = new Queue<string>();
        Boolean isUnOpBtClicked = false;
        private String lastResult = null;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void setOutputTextBlock(String value)
        {
            if(value == ".")
            {
                if(outputTextBlock.Text.Length == 0)
                {
                    outputTextBlock.Text = "0" + value;
                }
                else if(!outputTextBlock.Text.Contains("."))
                {
                    outputTextBlock.Text += value;
                }
            }
            else if(outputTextBlock.Text == "0")
            {
                outputTextBlock.Text = value;
            }
            else
            {
                outputTextBlock.Text += value;
            }
            
        }

        private void setInputTextBlock(String value)
        {
            if (!isUnOpBtClicked)
            {
                if (value == ".")
                {
                    if (inputTextBlock.Text.Length == 0)
                    {
                        inputTextBlock.Text = "0" + value;
                    }
                    else if (!inputTextBlock.Text.Contains("."))
                    {
                        inputTextBlock.Text += value;
                    }
                }
                else if (inputTextBlock.Text == "0")
                    {
                        inputTextBlock.Text = value;
                    }
                    else
                    {
                        inputTextBlock.Text += value;
                    }
            }
            else
            {
                operands.Enqueue(inputTextBlock.Text);
                inputTextBlock.Text = value;               
            }
            isUnOpBtClicked = false;
        }

        private void button_click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            setOutputTextBlock(btn.Content.ToString());
            setInputTextBlock(btn.Content.ToString());
        }

        private void binary_Click(object sender, RoutedEventArgs e)
        {
            if (!isUnOpBtClicked)
            {
                Button btn = (Button)sender;
                setOutputTextBlock(btn.Content.ToString());
                operators.Enqueue(btn.Content.ToString());
            }
            isUnOpBtClicked = true;
        }
        private void unary_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            if(btn.Content.ToString() == "Sqrt")
            {
                float inp1 = float.Parse(inputTextBlock.Text);
                string outputText = outputTextBlock.Text;
                outputText = outputText.Substring(0, (outputText.Length - inputTextBlock.Text.Length));
                inp1 = (float) Math.Sqrt(inp1);
                inputTextBlock.Text = inp1.ToString();
                outputText += outputText + inputTextBlock.Text;
                outputTextBlock.Text = outputText;
                operands.Enqueue(inputTextBlock.Text);              

            }
            if (btn.Content.ToString() == "Neg")
            {
                float inp1 = float.Parse(inputTextBlock.Text);
                inp1 = -inp1;
                inputTextBlock.Text = inp1.ToString();

            }
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            String text = inputTextBlock.Text;
            String outputText = outputTextBlock.Text;
            if (null != text && text.Length != 0)
            {
                text = text.Substring(0, (text.Length - 1));
                inputTextBlock.Text = text;
                outputText = outputText.Substring(0, (outputText.Length - 1));
                outputTextBlock.Text = outputText;
            }
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            outputTextBlock.Text = null;
            inputTextBlock.Text = null;
        }

        private void equalTo_Click(object sender, RoutedEventArgs e)
        {
            float inp1 = 0;
            float inp2 = 0;
            operands.Enqueue(inputTextBlock.Text);
            while (operands.Count > 0 && operators.Count > 0)
            {               
                if(inp1 == 0)
                {
                    string input1 = operands.Dequeue();
                    inp1 = float.Parse(input1);
                }                
                string input2 = operands.Dequeue();
                inp2 = float.Parse(input2);
                string operatr = operators.Dequeue();
                if(operatr=="X")
                {
                    inp1 = inp1 * inp2;  
                }
                if (operatr == "-")
                {
                    inp1 = inp1 - inp2;
                }
                if (operatr == "/")
                {
                    inp1 = inp1 / inp2;
                }
                if (operatr == "+")
                {
                    inp1 = inp1 + inp2;
                }
                if (operatr == "%")
                {
                    inp1 = inp1 % inp2;
                }
                if (operatr == "Pow")
                {
                    inp1 = (float) Math.Pow(inp1,inp2);
                }
            }
            outputTextBlock.Text = null;
            inputTextBlock.Text = inp1.ToString();
            lastResult = inputTextBlock.Text;
        }

        private void clear_Click(object sender, RoutedEventArgs e)
        {
            if (null != outputTextBlock.Text && null != inputTextBlock.Text && "" != outputTextBlock.Text && "" != inputTextBlock.Text)
            {
                String outputText = outputTextBlock.Text;
                outputText = outputText.Substring(0, (outputText.Length - inputTextBlock.Text.Length));
                outputTextBlock.Text = outputText;                
            }
            inputTextBlock.Text = null;
        }

        private void reload_Click(object sender, RoutedEventArgs e)
        {
            inputTextBlock.Text = lastResult;
            outputTextBlock.Text = lastResult;
        }

        private void keydown_click(object sender, KeyEventArgs e)
        {
            switch(e.Key)
            {
                case Key.D1:
                    button_click(one, null);
                    return;
                case Key.D2:
                    button_click(two, null);
                    return;
                case Key.D3:
                    button_click(three, null);
                    return;
                case Key.D4:
                    button_click(four, null);
                    return;
                case Key.D5:
                    button_click(five, null);
                    return;
                case Key.D6:
                    button_click(six, null);
                    return;
                case Key.D7:
                    button_click(seven, null);
                    return;
                case Key.D8:
                    button_click(eight, null);
                    return;
                case Key.D9:
                    button_click(nine, null);
                    return;
                case Key.D0:
                    button_click(zero, null);
                    return;
                case Key.NumPad1:
                    button_click(one, null);
                    return;
                case Key.NumPad2:
                    button_click(two, null);
                    return;
                case Key.NumPad3:
                    button_click(three, null);
                    return;
                case Key.NumPad4:
                    button_click(four, null);
                    return;
                case Key.NumPad5:
                    button_click(five, null);
                    return;
                case Key.NumPad6:
                    button_click(six, null);
                    return;
                case Key.NumPad7:
                    button_click(seven, null);
                    return;
                case Key.NumPad8:
                    button_click(eight, null);
                    return;
                case Key.NumPad9:
                    button_click(nine, null);
                    return;
                case Key.NumPad0:
                    button_click(zero, null);
                    return;          

            }
        }
    }
}
