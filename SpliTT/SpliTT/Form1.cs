using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpliTT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            od.InitialDirectory = Environment.CurrentDirectory;
            if (od.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            List<string> inf = new List<string>(File.ReadAllLines(od.FileName));
            string oldfn=Path.GetFileName(od.FileName);
            string path = Path.GetDirectoryName(od.FileName);
            List<string> outf = new List<string>();
            string delim = tbRazdelitel.Text;
            int count = 0;
            int poz = int.Parse(tbPoziciya.Text);
            foreach (var item in inf)
            {
                count++;
                try
                {
                    outf.Add(item.Split(delim.ToCharArray()[0])[poz - 1]);
                }
                catch 
                {
                    MessageBox.Show("Строка - "+ item +"\n\r #"+ count.ToString()+"\n\r Error");
                }
            }
            
            File.WriteAllLines(path+"\\result"+ oldfn, outf);
            MessageBox.Show("Fin");
        }
    }
}
