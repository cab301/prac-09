using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Floyd
{
    internal static class MatrixReader
    {
        private const int INF = int.MaxValue / 2;

        public static int[,] ReadMatrixFromFile(string path)
        {
            string text = ReadFile(path);
            return ParseMatrix(text);
        }

        /// <summary>
        /// Parse a string of text into a 2D array, 
        /// representing an adjacency matrix
        /// </summary>
        /// <param name="text">The text to parse</param>
        /// <returns>The 2D array of the adjacency matrix</returns>
        private static int[,] ParseMatrix(string text)
        {
            string[] rows = text.Split("\n");
            int rowCount = rows.Length;

            // Remove empty rows from the row count
            foreach (string row in rows)
            {
                if (row.Length == 0) rowCount--;
            }

            int columnCount = rows[0].Split("\t").Length;
            int[,] result = new int[rowCount, columnCount];
            
            // Do some parsing here
            for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
            {
                // Get the col-th element from the row-th row
                string[] row = rows[rowIndex].Split("\t");
                for (int columnIndex = 0; columnIndex < columnCount; columnIndex++)
                {
                    string element = row[columnIndex];
                    if (element == "∞")
                    {
                        result[rowIndex, columnIndex] = INF;
                    } else
                    {
                        result[rowIndex, columnIndex] = int.Parse(element);
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Read the text from a file and return a string
        /// </summary>
        /// <param name="path">The path of the txt file</param>
        /// <returns>The content of the file</returns>
        private static string ReadFile(string path)
        {
            if (File.Exists(path))
            {
                // Use a StreamReader to read the file's content
                using (StreamReader reader = new StreamReader(path))
                {
                    // Initialise the result
                    string result = "";
                    while (!reader.EndOfStream)
                    {
                        result += reader.ReadLine() + "\n";
                    }
                    return result;
                }
            } else
            {
                Console.WriteLine("File does not exist, please try again");
                return "";
            }
        }
    }
}
