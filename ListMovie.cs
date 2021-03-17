using System;
using System.Collections;
using System.IO;

namespace A4___Movie_Library_Assignment_LINZ
{
    class ListMovie : IListMovie
    {
        NLogger nLogger = new NLogger();
        private const int V = 30;
        int currentStart = 0;
        int nextStart = 31;
        string start = "";
        string line = "";
        StreamReader sr = new StreamReader("movies.csv");
        public void useFile()
        {

            string listReverseOrder = "";

            System.Console.WriteLine("\tThis is a LONG list. You are given the option to start at the beginning.");
            System.Console.WriteLine("\t\tOr you can start at the end and read the back to front\n\n");

            System.Console.Write("\tWould you like to view the list from the end to the beginning? [Y]es [N]o?    ");
            nLogger.nLog("Deciding on forward or reverse order.");
            listReverseOrder = Console.ReadLine();

            if (listReverseOrder == "Y" || listReverseOrder == "y" || listReverseOrder == "yes" || listReverseOrder == "Yes")
            {
                reverseList();
            }

            while (!sr.EndOfStream)
            {
                line = sr.ReadLine();

                fewAtaTime();
            }
            nLogger.nLog("Close Read for Not reverse order");
            sr.Close();
        }

        void reverseList()
        {
            ArrayList arrText = new ArrayList();
            string sLine = "start";
            nLogger.nLog("Movies viewed in reserve order.");
            while (sLine != null)
            {
                sLine = sr.ReadLine();
                if (sLine != null)
                    arrText.Add(sLine);
            }
            nLogger.nLog("Close Read for reverse order");
            sr.Close(); 
            arrText.Reverse();

            foreach (string sOutput in arrText)
            {
                fewAtaTime();
                System.Console.Write(sOutput);
            }
        }
        void fewAtaTime()
        {
            if (currentStart == nextStart)
            {
                System.Console.WriteLine("\nPress Enter for the next 30 movies or Q to quit");
                nLogger.nLog("Another 30 movies viewed.");
                start = Console.ReadLine();
                if (start == "q" || start == "Q" || start == "quit" || start == "Quit")
                {
                    nLogger.nLog("Quit the movie viewing.");
                    nLogger.nLog("Closing Reader");
                    sr.Close();
                    ActionSelected action = new ActionSelected();
                    action.selectAction();
                }
                currentStart = 0;
                nextStart = V;
            }
            currentStart++;
            System.Console.WriteLine(line);

        }
    }


}

