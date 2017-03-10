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
            //从eng目录读取文件并载入listbox，默认选择第一个文件。
        }

        private void Mainfrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void MergeButton_Click(object sender, EventArgs e)
        {
            string sourcefile = "eng\\" + FilesListbox.Text;
            string targetfile = "chn\\" + FilesListbox.Text;
            MergeAlt(sourcefile, targetfile);
            // 调用MergeAlt
        }

        private void Savebtn_Click(object sender, EventArgs e)
        {
            File.WriteAllLines("chn\\" + FilesListbox.Text, LinesOutput,Encoding.UTF8);
            // 保存文件
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
        // 根据正则表达式读取":"前的变量名。

        private string[] LinesOutput;
        // 保存最终文本信息的全局变量，方便传递

        private void MergeAlt(string EngPath, string ChnPath)
        {
            string[] str = File.ReadAllLines(EngPath);
            Logtxtbox.Clear();
            Savetxtbox.Clear();
            bool CatchChn = false;
            string Insertlineno = "";

            string[] LinesEng = File.ReadAllLines(EngPath);
            if (!File.Exists(ChnPath))
            {
                FileStream fs = File.Create(ChnPath);
                Byte[] info = new UTF8Encoding(true).GetBytes("l_english:");
                fs.Write(info,0,info.Length);
                fs.Close();
            }
            string[] LinesChn = File.ReadAllLines(ChnPath);

            List<string> listEng = new List<string>(LinesEng);
            List<string> listChn = new List<string>(LinesChn);
            List<string> listOutput = new List<string>(LinesEng);

            int insertedcount = 0,exceedcount=0;
            string engname = RexWords(listEng.ElementAt(0));
            string chnname = RexWords(listChn.ElementAt(0));
            // 以上为各种初始化

            // 以下for历遍英文变量
            for (int i = 0; i < listEng.Count; i++)
            {
                engname = RexWords(listEng.ElementAt(i));
                CatchChn = false;
                
                // 以下for将汉化过的文本当作词典，将汉化过的部分插入listOutput。
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
                // 如果未从汉化过的文本中找到该词，则将其记录为新加入的变量。

            }

            // 将剩余的中文放入listOutput，并计数
            for (int i = 0; i < listChn.Count; i++)
            {
                listOutput.Add(listChn.ElementAt(i));
                exceedcount++;
            }


            Logtxtbox.AppendText("-------------------- \r\n");
            Logtxtbox.AppendText(insertedcount + "Lines Inserted \r\n");
            Logtxtbox.AppendText(exceedcount + "Lines Exceeded \r\n");
            // 显示行增减
            
            if (Insertlineno != "") { listOutput.Add("#Added_Line_Nombers:0 \"" + Insertlineno + "\""); }
            // 若有增加则末尾追加行号信息。

            LinesOutput = listOutput.ToArray();
            // 将listOutput List<string> 转换为 string[]

            for (int i = 0; i < LinesOutput.Length; i++)
            {
                Savetxtbox.AppendText(LinesOutput[i] + "\r\n");
            }
           // 预览要保存的文件
        }
    }
}
