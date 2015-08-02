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
    public partial class InteractiveScript : Form
    {
        Script script;
        Utilities.StringRedirectWriter writer;
        public InteractiveScript(Script s)
        {
            InitializeComponent();
            script = s;
            writer = script.OutputWriter;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == '\r')
            {
                Script.engine.Execute(textBox2.Text);
                textBox2.Text = "";
                textBox1.AppendText(writer.RetrieveWrittenString());
            }
        }

        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {

        }
    }
}
