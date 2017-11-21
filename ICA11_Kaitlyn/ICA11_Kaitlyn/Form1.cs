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

namespace ICA11_Kaitlyn
{
    public partial class Form1 : Form
    {
        Dictionary<byte, int> dic = new Dictionary<byte, int>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ShowDictionary()
        {
            listView1.Items.Clear();
            AvgBtn.Text = "Average: " + dic.Average(kvp => kvp.Value).ToString("#.##");
            ListViewItem item;
            foreach (KeyValuePair<byte, int> kvp in dic)
            {
                item = new ListViewItem(kvp.Key.ToString("X"));
                item.UseItemStyleForSubItems = false;
                item.SubItems.Add(kvp.Value.ToString(), ForeColor, kvp.Value < dic.Average(kvp1 => kvp1.Value) ? Color.LightCoral:Color.LightGreen,Font);
                listView1.Items.Add(item);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadBtn_Click(object sender, EventArgs e)
        {

            openFileDialog1.InitialDirectory = "C:\\Users\\kmurphy23\\Pictures";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {

                    byte[] ArrayByte = File.ReadAllBytes(openFileDialog1.FileName);
                    foreach(byte b in ArrayByte)
                    {
                        if (!(dic.ContainsKey(b)))
                        {
                            dic[b] = 1;
                        }
                        else
                        {
                            dic[b]+=1;
                        }

                    }

                    ShowDictionary();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void AvgBtn_Click(object sender, EventArgs e)
        {
            double avg = dic.Average(kvp => kvp.Value);
            foreach (KeyValuePair<byte, int> kvp in dic.Where(kvp => kvp.Value < avg).ToList())
                dic.Remove(kvp.Key);
            ShowDictionary();
        }

        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == 0)
            {
                dic = dic.OrderBy(kvp => kvp.Key).ToDictionary(key=>key.Key,value=>value.Value);
            }
            else if (e.Column == 1)
            {
                List<KeyValuePair<byte, int>> tempList = dic.ToList();
                tempList.Sort((kvp1,kvp2)=>kvp1.Value==kvp2.Value ? kvp1.Key.CompareTo(kvp2.Key): kvp1.Value.CompareTo(kvp2.Value));
                dic = tempList.ToDictionary(key => key.Key, value => value.Value);
            }
            ShowDictionary();
        }
    }
}
