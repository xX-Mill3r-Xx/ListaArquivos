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

namespace ListaDiretorios
{
    public partial class Form1 : Form
    {
        //@"d:\dados"
        string path = @"d:\dados";
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Listar_Click(object sender, EventArgs e)
        {
            using(var openDlg = new FolderBrowserDialog())
            {
                openDlg.SelectedPath = path;
                if(openDlg.ShowDialog() == DialogResult.OK)
                {
                    path = openDlg.SelectedPath; // Caminho da pasta selecionada;
                }
            }

            list_Directorios.Items.Clear();
            GetDir(path);
            GetFiles(path);
        }

        private void GetFiles(string files)
        {
            var infiles = Directory.GetFiles(files);
            foreach(string file in infiles)
            {
                list_Directorios.Items.Add(file + "<Arquivo>");
            }
        }

        private void GetDir(string path)
        {
            var diretorios = Directory.GetDirectories(path);
            foreach(string dir in diretorios)
            {
                list_Directorios.Items.Add(dir +"<Directory>");
            }
        }
    }
}
