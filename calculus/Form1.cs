using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace calculus
{
    public partial class Form1 : Form
    {
        class row
        {
            public double time;
            public double voltage;
            public double current;
            public double voltageDerivative;
            public double charge;
        }

        List<row> table = new List<row>();
        public Form1()
        {
            InitializeComponent();
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
        
            {
                openFileDialog1.FileName = "";
                openFileDialog1.Filter = "CSV Files|*.csv";
                DialogResult result = openFileDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    try
                    {
                        using (StreamReader sr = new StreamReader(openFileDialog1.FileName))
                        {
                            string line = sr.ReadLine();
                            while (!sr.EndOfStream)
                            {
                                table.Add(new row());
                                string[] l = sr.ReadLine().Split(',');
                                table.Last().time = double.Parse(l[0]); 
                                table.Last().voltage = double.Parse(l[0]);
                                table.Last().current = double.Parse(l[1]);
                            }
                        }
                    }
                    catch (IOException)
                    {
                        MessageBox.Show(openFileDialog1.FileName + " failed to open.");
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show(openFileDialog1.FileName + " is not in the required format.");
                    }
                    catch (IndexOutOfRangeException)
                    {
                        MessageBox.Show(openFileDialog1.FileName + " is not in the required format");
                    }
                }
            }

        }
    }
}
