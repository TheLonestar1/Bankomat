using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad1
{
    class Formatter
    {
        public string pathLoad;
        public string pathSave;
        public int maxLength;
        public bool isDelete; 

        public void StartFormatter()
        {
            Thread t = new Thread(Formater);
            t.Start();
        }
        public void Formater()
        {
            StreamWriter sw;
            try
            {
                sw = new StreamWriter(pathSave);
            }
            catch
            {
                MessageBox.Show("Не могу открыть файл для сохранения");
                return;
            }
            try
            {
                using (StreamReader sr = new StreamReader(pathLoad))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        List<string> words = line.Split(" ").ToList();
                        for (int i = 0; i < words.Count; i++)
                        {
                            if (words[i].Count() > maxLength)
                            {
                                words.Remove(words[i]);
                                continue;
                            }

                            if (isDelete)
                            {
                                List<char> buff= words[i].ToList();
                                buff.RemoveAll(x => char.IsPunctuation(x));
                                words[i] = String.Concat(buff);
                            }
                        }
                        foreach(var word in words)
                        {
                            sw.Write(word + " ");
                        }
                        sw.Write('\n');
                    }
                }
            }
            catch
            {
                MessageBox.Show("Не могу открыть файл для загрузки");
                return;
            }
            sw.Dispose();
        }
    }
}
