using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloydsAlgorithm
{
    internal static class Utilities
    {
        static int INF = 99999;

        public static int[,] GetMatrixFromFile(string path)
        {
            string matrixAsStr = GetTextFromPath(path);
            return StringToMatrix(matrixAsStr);
        }

        public static string GetTextFromPath(string path)
        {
            // Check if the file exist. If not, return ""
            if (File.Exists(path))
            {
                string result = "";
                using (StreamReader reader = new StreamReader(path))
                {
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        if (line.Length > 0)
                        {
                            result += line + "\n";
                        }
                    }
                }
                return result;
            }
            return "";
        }

        public static int[,] StringToMatrix(string str)
        {
            string[] lines = str.Split("\n");
            int columnCount = lines[0].Split("\t").Length;
            int rowCount = lines.Length;
            // Remove last row if empty
            if (lines[rowCount - 1].Length == 0) rowCount--;

            int[,] result = new int[rowCount, columnCount];
            // Do the parsing
            for (int i = 0; i < rowCount; i++)
            {
                string[] row = lines[i].Split('\t');
                for (int j = 0; j < rowCount; j++)
                {
                    if (row[j] == "∞")
                    {
                        result[i, j] = INF;
                    } else
                    {
                        result[i, j] = int.Parse(row[j]);
                    }
                }
            }
            return result;
        }
    }
}
