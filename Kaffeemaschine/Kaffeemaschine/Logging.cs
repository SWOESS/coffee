using System;
using System.IO;
using System.Reflection;

namespace ProduktverwaltungmitLog

{
    public class Logger
    {
        private string path = string.Empty;

        public Logger(string fName)
        {
            this.path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\logs\\";
            
            (new FileInfo(path)).Directory.Create();
            
            path += fName + ".txt";
        }

        public void Information(string Message)
        {
            try
            {
                using (StreamWriter w = File.AppendText(path))
                {
                    Log("Information: " + Message, w);
                }
            }
            catch (Exception e)
            {
                //Passing Error to higher Level
                throw e;

            }
        }
        public void Error(string Message)
        {
            try
            {
                using (StreamWriter w = File.AppendText(path))
                {
                    Log("Error: " + Message, w);
                }
            }
            catch (Exception e)
            {
                //Passing Error to higher Level
                throw e;

            }
        }

        private void Log(string logMessage, TextWriter txtWriter)
        {
            try
            {
                string text = DateTime.Now.ToShortTimeString() + " " + DateTime.Now.ToShortDateString() + " - " + logMessage;
                txtWriter.WriteLine(text);
            }
            catch (Exception e)
            {
                //Passing Error to higher Level
                throw e;
            }
        }
    }
}
