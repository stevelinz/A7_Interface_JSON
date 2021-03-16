

namespace A4___Movie_Library_Assignment_LINZ
{
    class Exit : IExit
    {
        NLogger nLogger = new NLogger();
        public void exitTest()
        {
            System.Console.WriteLine("Good bye.");
            nLogger.nLog("Exit the Program");
            System.Environment.Exit(0);
        }
    }
}