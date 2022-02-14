using System;
using System.IO;

namespace ChangeDumpExportedToImport
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Folder of the dump exported
            DirectoryInfo d = new DirectoryInfo(@"C:\Users\hiago\Desktop\Projetos\BUNAC\Database Backups\Preview");
            FileInfo[] infos = d.GetFiles();
            foreach (FileInfo f in infos)
            {
                var script = File.ReadAllText(f.FullName);
                //the first param is the that you want to replace
                //the second the new name that you wants
                script = script.Replace("content-service-preview", "content-service-prod");
                script = script.Replace("SET @@SESSION.SQL_LOG_BIN= 0;", "");
                script = script.Replace("SET @@GLOBAL.GTID_PURGED=/*!80000 '+'*/ '';", "");
                script = script.Replace("SET @@SESSION.SQL_LOG_BIN = @MYSQLDUMP_TEMP_LOG_BIN;", "");
                File.WriteAllText(f.FullName, script);
                //the first param is the that you want to replace
                //the second the new name that you wants
                File.Move(f.FullName, f.FullName.Replace("content-service-preview_", "content-service-prod_"));
            }
        }
    }
}
