using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Caesar_Cipher.Algorithm
{
    static class ReadTextFromFile
    {
        public static string ReadText(string path)
        {
            string text = "";
            try
            {
                text = File.ReadAllText(path, Encoding.GetEncoding(1251));
                return text;
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка чтения файла!");
                return "";
            }
        }
    }
}
