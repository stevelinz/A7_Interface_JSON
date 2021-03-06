using System;
using System.IO;
namespace A4___Movie_Library_Assignment_LINZ
{

    public class AddMovie : IAddMovie
    {
        public static string movieString;
        public static string movieJSONString;
        ActionSelected action = new ActionSelected();
        GenreAdder genreAdder = new GenreAdder();
        NLogger nLogger = new NLogger();
        public void addMovieProcess()
        {
            string file = "movies.csv";
            StreamReader sr = new StreamReader("movies.csv");
            {
                int movieIdNew = 0;
                string movieId = "", line = "";
                try
                {
                    {
                        while (!sr.EndOfStream)
                        {
                            line = sr.ReadLine();
                        }
                    }
                }
                catch (FileNotFoundException e)
                {
                    Console.WriteLine($"The file was not found: '{e}'");
                }
                catch (DirectoryNotFoundException e)
                {
                    Console.WriteLine($"The directory was not found: '{e}'");
                }
                catch (IOException e)
                {
                    Console.WriteLine($"The file could not be opened: '{e}'");
                }

                if (sr.Peek() == -1) Console.WriteLine("\nThis is the most recent movie added:  " + line);

                string lastLine = line;
                movieId = lastLine.Substring(0, lastLine.IndexOf(","));
                // increment movieId
                movieIdNew = int.Parse(movieId);
                movieIdNew++;

                string movieName = "";
                Console.Write("Enter the name of the movie you want to add, date in form (yyyy)\n");
                System.Console.WriteLine("\t(You will have the opportunity to abort if needed)");
                System.Console.Write("\nMovie: ");
                movieName = Console.ReadLine();

                abortProcess();

                if (movieName.Contains(","))
                {
                    movieName = "\"" + movieName.Trim() + "\"";
                    nLogger.nLog("An attempt to add a Movie was aborted");
                }
                sr.Close();
                sr = new StreamReader(file);

                while (!sr.EndOfStream)
                {
                    line = sr.ReadLine();
                    string duplicate = line;

                    int first = duplicate.IndexOf(",") + ",".Length;
                    int last = duplicate.LastIndexOf(",");
                    string dupFound = duplicate.Substring(first, last - first);

                    if (movieName.Contains(dupFound))
                    {
                        nLogger.nLog("Tried to add an existing movie");
                        System.Console.WriteLine(" This movie is already on the list");
                        sr.Close();
                        action.selectAction();
                    }
                }
                sr.Close();

                string genreAddCopy = genreAdder.genreAdd();
                movieString = movieIdNew + "," + movieName.Trim() + "," + genreAddCopy;

                movieJSONString =
                ",{" + "\n" + "\t" + "\"" + "movieId" + "\"" + ": " + movieIdNew + "," + "\n"
                 + "\t" + "\"" + "title" + "\"" + ": " + "\"" + movieName.Trim() + "\"" + "," + "\n"
                 + "\t" + "\"" + "genres" + "\"" + ": " + "\"" + genreAddCopy + "\"" + "\n" + "}" + "\n";

                System.Console.WriteLine("\t\n"+ movieString);

                IRepository repositoryCSV = new WriteCSV();
                repositoryCSV.fileWrite();

                removeBracket();

                IRepository repositoryJSON = new WriteJSON();
                repositoryJSON.fileWrite();

                sr.Close();
                action.selectAction();
            }
        }
        public string addNewMovie()
        {
            string movieTemp;
            movieTemp = movieString;
            return movieTemp;
        }
        public string addNewJSON()
        {
            string movieJSON;
            movieJSON = movieJSONString;
            return movieJSON;
        }

        void abortProcess()
        {
            Console.Write("\n Press Enter to continue or Escape (Esc) to abort the movie adding process. \t");
            var key = Console.ReadKey();
            if (key.Key == ConsoleKey.Escape)
            {
                nLogger.nLog("Aborted the new movie add");
                StreamReader sr = new StreamReader("movies.csv");
                sr.Close();
                action.selectAction();
            }
        }
        void removeBracket()
        {
            StreamReader sr = new StreamReader("movies.json");
            string line;
            StreamWriter sw = new StreamWriter("movies.tmp");
            nLogger.nLog("Creating a temp file for JSON");
            while (!sr.EndOfStream)
            {
                line = sr.ReadLine();
                if (!line.Contains("]"))
                {
                    sw.WriteLine(line);
                    continue;
                }
                else
                {
                    sr.Close();
                    sw.Close();
                    break;
                }
            }
        }
    }
}




