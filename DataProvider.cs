using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace AtomicBackuper
{
    internal static class DataProvider
    {
        public static Dictionary<string, string> LoadDataDict(string fileName, char delimeter = '=')
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            string[] text;
            try
            {
                text = File.ReadAllLines(fileName);
            }
            catch (FileNotFoundException)
            {
                return new Dictionary<string, string>();
            }
            catch (DirectoryNotFoundException)
            {
                return new Dictionary<string, string>();
            }
            if (text.Length == 0) return result;

            foreach (string line in text)
            {
                result.Add(line.Split(delimeter)[0], line.Split(delimeter)[1]);
            }

            return result;
        }

        public static List<List<string>> LoadDataList(string fileName, char delimeter = '=')
        {
            List<List<string>> result = new List<List<string>>();

            string[] text;
            try
            {
                text = File.ReadAllLines(fileName);
            }
            catch (FileNotFoundException)
            {
                return new List<List<string>>();
            }
            catch (DirectoryNotFoundException)
            {
                return new List<List<string>>();
            }
            if (text.Length == 0) return result;

            foreach (string line in text)
            {
                result.Add(new List<string>(line.Split(delimeter)));
            }

            return result;
        }

        public static void WriteDataDict(string fileName, Dictionary<string, string> data, char delimeter = '=')
        {
            var SplittedPath = fileName.Split('\\');
            string path = "";
            for (int i = 0; i < SplittedPath.Length - 1; i++)
            {
                path += SplittedPath[i] + "\\";
            }
            path = path.TrimEnd('\\');
            Directory.CreateDirectory(path);
            StreamWriter writer = new StreamWriter(fileName);
            foreach (string key in data.Keys)
            {
                if (key.Contains(delimeter.ToString()) || data[key].Contains(delimeter.ToString()))
                {
                    throw new InvalidDataProvidedException();
                }
                writer.WriteLine(key + delimeter + data[key]);
            }
            writer.Close();
            
        }

        public static void WriteDataList(string fileName, List<List<string>> data, char delimeter = '=')
        {
            StreamWriter writer = new StreamWriter(fileName);
            foreach (List<string> dataLine in data)
            {
                string output = "";
                foreach (string line in dataLine)
                {
                    if (line.Contains(delimeter.ToString()))
                    {
                        throw new InvalidDataProvidedException();
                    }
                    output += line + delimeter;
                }
                output = output.Remove(output.Length - 1, 1);
                writer.WriteLine(output);
            }
            writer.Close();
        }
    }
}
