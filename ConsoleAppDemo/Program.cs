namespace ConsoleAppDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the input file");
            string path = Console.ReadLine();

            DisplayFileContent(path);

            DisplayMenu();
        }

        static void DisplayMenu()
        {
            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine(@"Select an option:
1. Add unit
2. Remove unit
3. Read a new file
4. Exit program");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        // Replace with your logic
                        Console.WriteLine("Adding a unit");
                        break;
                    case "2":
                        // Replace with your logic
                        Console.WriteLine("Removing a unit");
                        break;
                    case "4":
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }
            }
        }

        static void DisplayFileContent(string path)
        {
            if (File.Exists(path))
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        Console.WriteLine(line);
                    }
                }
            }
        }
    }
}