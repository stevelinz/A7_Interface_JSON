using System.IO;

namespace A4___Movie_Library_Assignment_LINZ
{
    class WriteCSV : IRepository
    {
        NLogger nLogger = new NLogger();
        void IRepository.fileWrite()
        {
            addCSV();    
        }
        void addCSV (){

            StreamReader sr = new StreamReader("movies.csv");
            StreamWriter sw = new StreamWriter("movies.csv", true);

            AddMovie addMovie = new AddMovie();
            addMovie.addNewMovie();

            sw.WriteLine(addMovie.addNewMovie());
            nLogger.nLog("Added: " + addMovie.addNewMovie());
            sr.Close();
            sw.Close();

        }
    }
}