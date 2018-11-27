

namespace RadioControlledCarsSimulator
{
    public static class Constants
    {
        public static class Car
        {
            public static class Movement
            {
                public const int StepLength = 1;
            }

            public static class Type
            {
                public const string MonsterTruck = "MonsterTruck";
            }

            public static class Command
            {
                public const char Forward = 'F';
                public const char Backwards = 'B';
                public const char Left = 'L';
                public const char Right = 'R';
            }

            public static class Heading
            {
                public const char North = 'N';
                public const char South = 'S';
                public const char West = 'W';
                public const char East = 'E';
            }
        }

        public static class ConsolePrint
        {
            public static class WelcomeGoodbyeMessages
            {
                public const string WelcomeMessage = "**********************************************************\r\n\tWelcome to Radio Controlled Cars Simulator \r\n\t\tMade by Prince\r\n**********************************************************\r\n";
                public const string GoodbyeMessage = "\r\nThanks for using the simulator!\r\nPress any key to close the application...";
            }

            public static class Error
            {
                public const string AskForValidate = "\r\nPlease validate the entered data and try again...";
                public const string CaughtException = "\r\nSomething went wrong. The Entered data is either incorrectly formatted or other issue has occured. \r\nPlease review the entered data and try again. \r\n";
            }

            public static class Setup
            {
                public const string SetDimensionsOfRoom = "Please enter the dimensions of the room(in meters) and press enter to apply:\r\n\tEnter two integers separated with a space. \r\n\tExample: Enter \"4 4\" to make the room 4x4 meters(without quotes)";
                public const string ConfirmDimensionsOfRoom = "You have set the dimension of the room to (meter): ";
                public const string SetStartingPositionAndHeading = "Please enter the starting position and heading of the RC car: \r\n\tEnter two integers and one letter separated with spaces. The letter can be N, S, W or E. \r\n\tExample: Enter \"2 3 N\" to set the position to 2,3 and heading N";
                public const string ConfirmStartingPositionHeading = "You have set the starting position to coordinates and heading: ";
                public const string SetSimulationCommands = "In order to simulate a test, please write a series of commands which the test will execute. Write the commands listed below in series without any spaces." +
                    "\r\n\tCommands: \r\n\t\"F\" for Forward \r\n\t\"B\" for Backwards \r\n\t\"L\" for Left \r\n\t\"R\" for Right. \r\n\tExample: Enter \"FRFLLB\" to go Forward, Right, Front, Left, Left and finally Backwards.";
                public const string ConfirmSimulationVariables = "Simulation-variables: ";
                public const string ConfirmSimulationCommands = "Car actions for the simulation: ";
                public const string ConfirmSimulationBegun = "Simulation is starting...\r\n";
            }

            public static class Results
            {
                public static class Success
                {
                    public const string Command = "Command: ";
                    public const string Step = "Successful step! ";
                    public const string Position = "The position of the car is ";
                    public const string PositionFinal = "The final position of the car is ";
                    public const string Heading = " and heading ";
                    public const string Test = "Successful test! ";
                }

                public static class Unsuccessful
                {
                    public const string Position = "Car tried to move to a position which is out of bounds of the room: ";
                    public const string Test = "Unsuccessful test. ";
                }
            }
        }
    }
}
