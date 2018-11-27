using System;

namespace RadioControlledCarsSimulator.Models
{
    class View
    {
        public void PrintWelcomeMessage()
        {
            Console.WriteLine(Constants.ConsolePrint.WelcomeGoodbyeMessages.WelcomeMessage);
        }

        public void PrintGoodbyeMessage()
        {
            Console.WriteLine(Constants.ConsolePrint.WelcomeGoodbyeMessages.GoodbyeMessage);
        }

        public void FreezeApplicationUntilKeyPress()
        {
            Console.ReadKey();
        }

        public void PrintErrorValidationMessage()
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine(Constants.ConsolePrint.Error.CaughtException);
            Console.ResetColor();
        }

        public void PrintErrorValidationInnerExceptionMessage(string innerException)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine(Constants.ConsolePrint.Error.CaughtException);
            Console.WriteLine(innerException);
            Console.ResetColor();
        }

        public String AskStartingPositionHeading()
        {
            Console.WriteLine(Constants.ConsolePrint.Setup.SetStartingPositionAndHeading);
            return Console.ReadLine();
        }

        public void PrintStartingPositionHeading(int x, int y, char heading)
        {
            Console.Write(Constants.ConsolePrint.Setup.ConfirmStartingPositionHeading);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(x + "," + y + " " + heading + "\r\n\r\n");
            Console.ResetColor();
        }

        public String AskDimensionsOfRoom()
        {
            Console.WriteLine(Constants.ConsolePrint.Setup.SetDimensionsOfRoom);
            return Console.ReadLine();
        }

        public void PrintDimensionsOfRoom(int length, int height)
        {
            Console.Write(Constants.ConsolePrint.Setup.ConfirmDimensionsOfRoom);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(length + "x" + height + "\r\n\r\n");
            Console.ResetColor();
        }

        public String AskSimulationCommands()
        {
            Console.WriteLine(Constants.ConsolePrint.Setup.SetSimulationCommands);
            return Console.ReadLine();
        }

        public void PrintSimulationCommands(string commands)
        {
            Console.Write(Constants.ConsolePrint.Setup.ConfirmSimulationCommands);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(commands + "\r\n");
            Console.ResetColor();
        }

        public void PrintSimulationBegun()
        {
            Console.Write(Constants.ConsolePrint.Setup.ConfirmSimulationBegun);
        }

        public void PrintCurrentCarCoordinatesHeading(int step, char command, int x, int y, char heading)
        {
            Console.Write(step + ". " + Constants.ConsolePrint.Results.Success.Command);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(command);
            Console.ResetColor();
            Console.Write(", " + Constants.ConsolePrint.Results.Success.Step);
            Console.Write(Constants.ConsolePrint.Results.Success.Position);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(x + "," + y);
            Console.ResetColor();
            Console.Write(Constants.ConsolePrint.Results.Success.Heading);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(heading);
            Console.ResetColor();
        }

        public void PrintSuccessCarCoordinatesHeading(int x, int y, char heading)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(Constants.ConsolePrint.Results.Success.Test);
            Console.ResetColor();
            Console.Write(Constants.ConsolePrint.Results.Success.PositionFinal);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(x + "," + y);
            Console.ResetColor();
            Console.Write(Constants.ConsolePrint.Results.Success.Heading);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(heading + "\r\n");
            Console.ResetColor();
        }

        public void PrintFailedCarCoordinatesHeading(int x, int y)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(Constants.ConsolePrint.Results.Unsuccessful.Test);
            Console.ResetColor();
            Console.Write(Constants.ConsolePrint.Results.Unsuccessful.Position);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(x + "," + y);
            Console.ResetColor();
        }
    }
}
