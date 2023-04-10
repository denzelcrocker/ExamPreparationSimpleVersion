using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPreparationSimpleVersion.Pages
{
    internal class Modules
    {
        public struct children
        {
            public string name { get; set; }
            public string birthday { get; set; }
            public string gender { get; set; }
        }
        public static string OpenDialog()
        {
            string path = null;
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            Nullable<bool> result = openFileDialog.ShowDialog();
            if (result == true)
            {
                path = openFileDialog.FileName;
            }
            return path;
        }
        public static List<children> ListOfChildrens = new List<children>();
        public static List<children> ReadChildrens(string path)
        {
            try
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    ListOfChildrens.Clear();
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] fields = line.Split(",");
                        try
                        {
                            ListOfChildrens.Add(new children { name = fields[0].Replace("\"", ""), birthday = fields[1].Replace("\"", ""), gender = fields[2].Replace("\"", "") });
                        }
                        catch { break; }
                    }
                }
            }
            catch { }
            return ListOfChildrens;
        }
        public static void WriteChildrens(List<children> childrens, string path)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(path))
                {
                    foreach (children item in childrens)
                    {
                        string line = $"{item.name},{item.birthday},{item.gender}";
                        writer.WriteLine(line);
                    }
                }
            }
            catch { }
        }
    }
}
