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
using System.Text.RegularExpressions;

namespace TehProg4
{
    public partial class Form1 : Form
    {
        List<string> s = new List<string>() { "C:\\Windows", "C:\\Program Files", "C:\\Student"}; 
        List<string> extention = new List<string>() { ".exlm", ".exlx" };
        int k = 1;
        public Form1()
        {
            InitializeComponent();
            for (int i = 0; i < s.Count; i++)
            {
                listBox1.Items.Add(s[i]); // заполняю listBox1 путями к папке
            }
            for (int i = 0; i < extention.Count; i++)
            {
                listBox3.Items.Add(extention[i]); // заполняю listBox3 расширениями
            }
        }

        private void button3_Click(object sender, EventArgs e) // Найти
        {
            int lb1 = listBox1.Items.Count, ls = s.Count, le = extention.Count, lb2 = listBox2.Items.Count;
            for (int i = 0; i < lb1; i++)
            {
                if (ls > i) //если длинна строки меньше длинны listBox'а
                    s[i] = Convert.ToString(listBox1.Items[i]);
                else
                    s.Add(Convert.ToString(listBox1.Items[i]));
            }
            for (int i = 0; i < lb2; i++)
            {
                if (le > i) //если длинна строки меньше длинны listBox'а
                    extention[i] = Convert.ToString(listBox3.Items[i]);
                else
                    extention.Add(Convert.ToString(listBox3.Items[i]));
            }
            Search();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text!=null)
                listBox1.Items.Add(textBox1.Text); // добавляю строку в listBox1
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int t = Convert.ToInt32(listBox1.SelectedIndex.ToString());
            if(t!=-1)
                listBox1.Items.RemoveAt(t); // удаляю выбранную строку из listBox1
        }
        private void Search()
        {
            for(int i = 0; i < s.Count; i++)
            {
                string[] allfiles = Directory.GetFiles(s[i]);
                for (int j = 0; j < extention.Count; j++)
                {
                    List<string> needfiles = new List<string>();
                    foreach (string str in allfiles)
                    {
                        if (str.ToLower().EndsWith(extention[j]))
                        {
                            string ss = extention[j] + "($)";
                            Regex reg = new Regex(ss);
                            string S=Path.GetFileName(str);
                            string Str = string.Join("", Regex.Replace(S, @"\" + extention[j], ""), "_<", j, "> ", k, " ", Convert.ToString(reg.Match(S)));
                            needfiles.Add(Str);
                            k++;
                        }
                    }
                    needfiles.Sort();
                    for (int t = 0; t < needfiles.Count; t++)
                    {
                        listBox2.Items.Add(needfiles[t]); // заполняю listBox2 найденными файлами
                    }
                }

            }
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != null)
                listBox3.Items.Add(textBox2.Text); // добавляю строку в listBox3
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int t = Convert.ToInt32(listBox3.SelectedIndex.ToString());
            if (t != -1)
                listBox3.Items.RemoveAt(t); // удаляю выбранную строку из listBox1
        }
    }
}
