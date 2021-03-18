using System.IO;

namespace A4___Movie_Library_Assignment_LINZ
{
    class WriteJSON : IRepository
    {
        NLogger nLogger = new NLogger();
        void IRepository.fileWrite()
        {
            addJSON();
        }
        void addJSON()
        {

            AddMovie addJSONMovie = new AddMovie();
            addJSONMovie.addNewJSON();
            
            nLogger.nLog("appending a JSON entry");
            File.AppendAllText("movies.tmp", addJSONMovie.addNewJSON());
            File.AppendAllText("movies.tmp", "]" + "\n");
            File.Delete("movies.json");
            File.Move("movies.tmp", "movies.json");

        }
    }
}