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
        const string StrRegexVarName = "(^.*?):";
        List<string> listOutput;
        List<string> listEng;
        List<string> listChn;
        string LoadedFileName = "";

        private void MergeButton_Click(object sender, EventArgs e)
        {
            ReadFile();
            Merge();
            Savetxtbox.AppendText(" ");
        }

        private void Savebtn_Click(object sender, EventArgs e)
        {
            File.WriteAllLines("chn\\" + LstFiles.Text, listOutput.ToArray(), Encoding.UTF8);
            // 保存文件
        }

        // 保存最终文本信息的全局变量，方便传递

        private void ReadFile()
        {
            Logtxtbox.Clear();
            Savetxtbox.Clear();
            string EngPath = "eng\\" + LstFiles.Text;
            string ChnPath = "chn\\" + LstFiles.Text;

            string[] str = File.ReadAllLines(EngPath);
            if (!File.Exists(ChnPath))
            {
                FileStream fs = File.Create(ChnPath);
                Byte[] info = new UTF8Encoding(true).GetBytes("l_english:");
                fs.Write(info, 0, info.Length);
                fs.Close();
            }

            listEng = new List<string>(File.ReadAllLines(EngPath));
            listChn = new List<string>(File.ReadAllLines(ChnPath));
            listOutput = new List<string>(File.ReadAllLines(EngPath));

            LoadedFileName = EngPath;
        }

        private void Merge()
        {
            bool CatchChn = false;
            string Insertlineno = "";
            int insertedcount = 0, exceedcount = 0;
            string engname = "";
            string chnname = "";
            // 以上为各种初始化

            // 以下for历遍英文变量
            for (int i = 0; i < listEng.Count; i++)
            {
                engname = YMLTools.FuncRegex(listEng.ElementAt(i), StrRegexVarName);
                CatchChn = false;
                if (engname=="")
                {
                    for (int k = 0; k < listChn.Count; k++)
                    {
                        if (listEng.ElementAt(i)==listChn.ElementAt(k))
                        {
                            listChn.RemoveAt(k);
                        }
                    }
                    continue;
                }
                // 以下for将汉化过的文本当作词典，将汉化过的部分插入listOutput。
                for (int k = 0; k < listChn.Count; k++)
                {
                    chnname = YMLTools.FuncRegex(listChn.ElementAt(k), StrRegexVarName);
                    if (engname == chnname)
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
                    insertedcount++;
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
            
            //if (Insertlineno != "") { listOutput.Add("#Added_Line_Nombers: " + Insertlineno ); }
            // 若有增加则末尾追加行号信息。

            Savetxtbox.Text = string.Join("\r\n",listOutput);
           // 预览要保存的文件
        }

        private void CheckSameLinebtn_Click(object sender, EventArgs e)
        {
            string samelineno = "";
            if (LoadedFileName != "eng\\" + LstFiles.Text)
            {
                ReadFile();
                Merge();
            }

            for (int i = 1; i < listEng.Count; i++)
            {
                if (listEng.ElementAt(i) == listOutput.ElementAt(i))
                {
                    samelineno += (i + 1).ToString() + ",";
                }
            }

            if (samelineno != "")
            {
                listOutput.Add("#Same_as_Eng_LineNum: " + samelineno);
                Savetxtbox.AppendText("\r\n#Same_as_Eng_LineNum: " + samelineno + "\r\n");
            }
            else
            {
                Savetxtbox.AppendText("\r\nNo Same lines.");
            }
        }

        private void Mainfrm_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists("eng\\"))
            {
                Directory.CreateDirectory("eng\\");
            }
            if (!Directory.Exists("chn\\"))
            {
                Directory.CreateDirectory("chn\\");
            }
            string[] stringList = Directory.GetFiles("eng\\", "*.yml");

            if (stringList.Length > 0)
            {
                foreach (string str in stringList)
                {
                    LstFiles.Items.Add(Path.GetFileName(str));
                }
                //从eng目录读取文件并载入listbox，默认选择第一个文件。
            }
            else
            {
                LstFiles.Items.Add("No YML File in directory");
                LstFiles.Enabled = false;
            }
        }

        public Mainfrm()
        {
            InitializeComponent();
        }
        private void Mainfrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
