using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrimeNumber
{
    public partial class Form1 : Form
    {
        List<DetectPrimeNumber> detectPrimeNumbers = new List<DetectPrimeNumber>();
        OpenFileDialog OpenFileDialog1 = new OpenFileDialog();
        public Form1()
        {
            InitializeComponent();
          
        }

        
        private void btnLoadFile_Click(object sender, EventArgs e)
        {

            OpenFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*"; 
            if(OpenFileDialog1.ShowDialog()==DialogResult.Cancel) return;
            string fileName = OpenFileDialog1.FileName;
            if(fileName == null) return;
            string FileText = System.IO.File.ReadAllText(fileName);
            string[] TextSplit = FileText.Split(new char[] {' '},StringSplitOptions.RemoveEmptyEntries);
            
            for (int i = 0; i < TextSplit.Length; i++) 
            {
                tboxInputText.AppendText($"{TextSplit[i]}\r\n"); 
            }

        }

        private void btnDetect_Click(object sender, EventArgs e)
        {
            long number;
            List<string> Numtext = new List<string>();
            string textTmp = tboxInputText.Text;            
            string[] TextSplit = textTmp.Split(new char[] { '\r','\n' });
            for (int i = 0;i < TextSplit.Length;i++)
            {
                if (TextSplit[i] != "") Numtext.Add(TextSplit[i]); 
            }

            foreach (string item in Numtext)
            {
                if (long.TryParse(item, out number))
                {
                    DetectPrimeNumber detectPrimeNumber = new DetectPrimeNumber(number);
                    detectPrimeNumbers.Add(detectPrimeNumber);
                    try
                    {
                        detectPrimeNumber.GetTask().Start();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"{ex.Message}");

                    }

                }
            }

            
        }
    }
}
