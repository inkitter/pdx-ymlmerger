using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;

namespace pdx_ymlmerger
{
    public partial class Mainfrm : Form
    {
        public Mainfrm()
        {
            InitializeComponent();
        }

        private void Mainfrm_Load(object sender, EventArgs e)
        {
            string[] stringList = Directory.GetFiles("eng\\", "*.yml");

            foreach (string str in stringList)
            {
                FilesListbox.Items.Add(Path.GetFileName(str));
            }
            FilesListbox.SelectedIndex = 0;
        }

        private void Mainfrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void MergeButton_Click(object sender, EventArgs e)
        {
            string sourcefile, targetfile;
            sourcefile = "eng\\" + FilesListbox.Text;
            targetfile = "chn\\" + FilesListbox.Text;
            MergeAlt(sourcefile, targetfile);

        }

        private void Savebtn_Click(object sender, EventArgs e)
        {
            File.WriteAllLines("chn\\" + FilesListbox.Text, LinesOutput);
        }


        private string RexWords(string RegText)
        {
            Regex Reggetname = new Regex(@"(^.*?):");
            string retext = "";
            var matches = Reggetname.Matches(RegText);

            foreach (var item in matches)
            {
                retext += item.ToString();
            }
            return retext;
        }
        public string[] LinesOutput;

        private void MergeAlt(string EngPath, string ChnPath)
        {
            string[] str = File.ReadAllLines(EngPath);
            Logtxtbox.Clear();
            Savetxtbox.Clear();
            bool CatchChn = false;
            string Insertlineno = "";

            string[] LinesEng = File.ReadAllLines(EngPath);
            if (!File.Exists(ChnPath)) { File.Create(ChnPath); }
            string[] LinesChn = File.ReadAllLines(ChnPath);

            List<string> listEng = new List<string>(LinesEng);
            List<string> listChn = new List<string>(LinesChn);
            List<string> listOutput = new List<string>(LinesEng);

            int insertedcount = 0,exceedcount=0;

            string engname = RexWords(listEng.ElementAt(0));
            string chnname = RexWords(listChn.ElementAt(0));

            for (int i = 0; i < listEng.Count; i++)
            {
                engname = RexWords(listEng.ElementAt(i));
                CatchChn = false;
                for (int k=0; k < listChn.Count; k++)
                {
                    chnname = RexWords(listChn.ElementAt(k));
                    if (engname==chnname)
                    {
                        listOutput.Insert(i, listChn.ElementAt(k));
                        listOutput.RemoveAt(i + 1);
                        listChn.RemoveAt(k);
                        CatchChn = true;
                        Logtxtbox.AppendText(engname + " OK \r\n");
                        break;
                    }
                }
                if (CatchChn == false)
                {
                    Logtxtbox.AppendText(engname + " Inserted \r\n");
                    insertedcount ++;
                    Insertlineno += (i + 1).ToString() + ",";
                }
            }
            //历遍英文，从中文查询并放入Output
            for (int i = 0; i < listChn.Count; i++)
            {
                listOutput.Add(listChn.ElementAt(i));
                exceedcount++;
            }
            Logtxtbox.AppendText("-------------------- \r\n");
            Logtxtbox.AppendText(insertedcount + "Lines Inserted \r\n");
            Logtxtbox.AppendText(exceedcount + "Lines Exceeded \r\n");
            //将剩余中文放入Output
            
            if (Insertlineno != "") { listOutput.Add("#Added_Line_Nombers:0 \"" + Insertlineno + "\""); }
            LinesOutput = listOutput.ToArray();
            for (int i = 0; i < LinesOutput.Length; i++)
            {
                Savetxtbox.AppendText(LinesOutput[i] + "\r\n");
            }
           
        }
    }
}
