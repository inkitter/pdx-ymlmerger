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
        public string[] LinesOutput;
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
            FilesListbox.SelectedIndex=0;
        }

        private void MergeButton_Click(object sender, EventArgs e)
        {
            string sourcefile, targetfile;
            sourcefile = "eng\\" + FilesListbox.Text;
            targetfile = "chn\\" + FilesListbox.Text;
            Merge(sourcefile, targetfile);
            
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
        
        private void Merge(string EngPath, string ChnPath)
        {
            Logtxtbox.Clear();
            Savetxtbox.Clear();
            string Insertlineno = "";

            string[] LinesEng = File.ReadAllLines(EngPath);
            if (!File.Exists(ChnPath)){ File.Create(ChnPath);}
            string[] LinesChn = File.ReadAllLines(ChnPath);
            List<string> listEng = new List<string>(LinesEng);
            List<string> listChn = new List<string>(LinesChn);
            string engname = "", chnname = "";
            int insertedcount = 0;
            engname = RexWords(listEng.ElementAt(0));
            chnname = RexWords(listChn.ElementAt(0));
            for (int i = 0; i < listEng.Count; i++)
            {
                engname = RexWords(listEng.ElementAt(i));
                if (i < listChn.Count)
                {
                    chnname = RexWords(listChn.ElementAt(i));
                    if (engname == chnname)
                    {
                        Logtxtbox.AppendText(engname + "  OK \r\n");
                    }
                    else
                    {
                        listChn.Insert(i, listEng.ElementAt(i));
                        Logtxtbox.AppendText(engname + "  Modified \r\n");
                        insertedcount++;
                        Insertlineno += (i+1).ToString()+", ";
                    }
                }
                else
                {
                    listChn.Add(listEng.ElementAt(i));
                    Logtxtbox.AppendText(engname + "  Modified \r\n");
                    insertedcount++;
                    Insertlineno += (i + 1).ToString()+",";
                }
            }
            Logtxtbox.AppendText(insertedcount.ToString() + " Lines Modified \r\n");


            for (int i = listChn.Count-1 ; i > listEng.Count; i--)
            {
                engname = RexWords(listChn.ElementAt(i));

                for (int k=1; k<listChn.Count-1;k++)
                {
                    chnname= RexWords(listChn.ElementAt(k));

                    if (engname == chnname)
                    {
                        listChn.Insert(k, listChn.ElementAt(i));
                        listChn.RemoveAt(k+1);
                        listChn.RemoveAt(i);
                        break;
                    }
                }
            }
            if (Insertlineno != "") { listChn.Add(" Added_Line_Nombers:0 \"" + Insertlineno + "\""); }
            LinesOutput = listChn.ToArray();
            for (int i = 0; i < LinesOutput.Length; i++)
            {
                Savetxtbox.AppendText(LinesOutput[i] + "\r\n");
            }
        }

        private void Mainfrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
