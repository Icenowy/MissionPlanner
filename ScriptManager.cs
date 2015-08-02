using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace MissionPlanner
{

    public struct ScriptItem
    {
        public string name;
        public string description;
        public string iconKey;
        public override string ToString()
        {
            if (description != "")
                return name + "(" + description + ")";
            return name;
        }
    }

    public class ScriptManager
    {
        DirectoryInfo dirScripts;
        FileInfo[] a_fiFiles;
        List<ScriptItem> l_siItems;
        public ScriptManager()
        {
            l_siItems = new List<ScriptItem>();
            dirScripts = null;
            a_fiFiles = null;
            try
            {
                dirScripts = new DirectoryInfo("scripts");
                a_fiFiles = dirScripts.GetFiles();
                foreach(FileInfo fi in a_fiFiles)
                {
                    string fn = fi.Name;
                    ScriptItem si;
                    si.name = fn;
                    si.description = "";
                    si.iconKey = "default";
                    StreamReader r = null;
                    try
                    {
                        r = new StreamReader(fi.OpenRead());
                        string fl = r.ReadLine();
                        if(fl.StartsWith("# mpscript"))
                        {
                            // Try to read metadata
                            fl = fl.Substring("# mpscript".Length);
                            string[] md = fl.Split(' ');
                            foreach(string s in md)
                            {
                                if(s.StartsWith("description="))
                                {
                                    si.description = s.Substring("description=".Length);
                                }
                                if(s.StartsWith("icon="))
                                {
                                    si.iconKey = s.Substring("icon=".Length);
                                }
                            }
                        }
                    }
                    catch
                    {

                    }
                    finally
                    {
                        if(r != null)
                            r.Close();
                    }
                    l_siItems.Add(si);
                }
            }
            catch
            {
                CustomMessageBox.Show("No scripts found, scripting will be disabled.");
            }
        }
        public List<ScriptItem> Items
        {
            get { return l_siItems; }
        }
    }
}
