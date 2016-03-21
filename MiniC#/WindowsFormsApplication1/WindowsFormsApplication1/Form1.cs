using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public RichTextBox actualCodeTextBox;
        public TabPage actualTab;
        public string Global_Text;
        public Form1()
        {
            InitializeComponent();
            onLoad();

        }
        private void onLoad()
        {
            actualCodeTextBox = richTextBox1;



        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string title = "Aplicacion " + (tabControl1.TabCount + 1).ToString();
            TabPage myTabPage = new TabPage(title);
            tabControl1.TabPages.Add(myTabPage);


            RichTextBox myRichTextBox = new RichTextBox();
            myRichTextBox.Dock = DockStyle.Fill;
            myRichTextBox.AcceptsTab = true;
            myTabPage.Controls.Add(myRichTextBox);

        }

        private void cerrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Remove(tabControl1.SelectedTab);
        }

        private void pegarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void archivoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }



        private void tabControl1_Selectedtab(Object sender, EventArgs e)
        {
            TabPage actualTab = tabControl1.SelectedTab;
            if (tabControl1.TabCount != 0)
            {
                foreach (Control ctl in actualTab.Controls)
                {
                    actualCodeTextBox = (RichTextBox)ctl;
                    Global_Text = actualCodeTextBox.Text;
                }
            }
        }



        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabPage myTabPage = new TabPage();
            tabControl1.TabPages.Add(myTabPage);


            TabPage actualTab = myTabPage;


            RichTextBox myRichTextBox = new RichTextBox();
            myRichTextBox.Dock = DockStyle.Fill;
            myRichTextBox.AcceptsTab = true;
            myTabPage.Controls.Add(myRichTextBox);



            
            string contenidoR = richTextBox1.Text.ToString();

            // Create an instance of the open file dialog box.
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            // Set filter options and filter index.
            openFileDialog1.Filter = "Text Files (.txt)|*.txt|All Files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;

            openFileDialog1.Multiselect = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                actualCodeTextBox = myRichTextBox;
                actualCodeTextBox.LoadFile(openFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                actualTab.Text = openFileDialog1.SafeFileName;
            }

        }



        private void button1_Click(object sender, EventArgs e)
        {
            actualCodeTextBox.SaveFile(actualTab.Text.ToString(), RichTextBoxStreamType.PlainText);

        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            SaveFileDialog saveFile1 = new SaveFileDialog();
            saveFile1.DefaultExt = "*.rtf";
            //saveFile1.Filter = "RTF Files|*.rtf";
            saveFile1.Filter = "Text Files (.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFile1.ShowDialog() == System.Windows.Forms.DialogResult.OK &&
               saveFile1.FileName.Length > 0)
            {
                actualCodeTextBox.SaveFile(saveFile1.FileName, RichTextBoxStreamType.PlainText);
                MessageBox.Show("Se ha guardado correctamente");
            }
        }

    }

}
    

