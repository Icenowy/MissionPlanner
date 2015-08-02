using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MissionPlanner
{
    public partial class OpenScriptDialog : Form
    {
        List<ScriptItem> l_siList;
        ImageList il;
        public string selectedItem = "";
        public OpenScriptDialog(List<ScriptItem> sil)
        {
            InitializeComponent();
            l_siList = sil;
            il = new ImageList();
            listView1.LargeImageList = il;
            listView1.SmallImageList = il;
            //listView1.StateImageList = il;
            foreach (ScriptItem si in l_siList)
            {
                Image i = Image.FromFile("ScriptIcons/" + si.iconKey + ".png");
                if(i != null)
                    il.Images.Add(si.iconKey,i);
                listView1.Items.Add(new ListViewItem(si.ToString(),si.iconKey));//Add(si);
            }
        }

        private void OpenScriptDialog_Load(object sender, EventArgs e)
        {

        }

        private void listView1_ItemActivate(object sender, EventArgs e)
        {
            selectedItem = listView1.SelectedItems[0].Text.Split('(')[0];
            this.Close();
        }
    }
}
