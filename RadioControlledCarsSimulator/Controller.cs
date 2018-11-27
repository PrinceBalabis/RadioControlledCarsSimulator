using System;
using System.Collections.Generic;
using System.Linq;

namespace RadioControlledCarsSimulator.Models
{
    class Controller
    {
        private View view;

        public Controller(View view)
        {
            this.view = view;
        }

        public void RunSimulation()
        {
            // Print Welcome message on application launch
            view.PrintWelcomeMessage();

            // Create Room which is to be simulated
            Room room = CreateRoom();

            // Create Car which is to be simulated
            // In this case a Monster Truck should be simulated.
            Car monsterTruck = CreateCar(Constants.Car.Type.MonsterTruck, room);

            bool success = PerformSimulationCommands(room, monsterTruck);

            if (success)
            {
                // Print results after the successful simulation
                view.PrintSuccessCarCoordinatesHeading(monsterTruck.Coordinates.X, monsterTruck.Coordinates.Y, monsterTruck.Heading);

            }
            else
            {
                // Print results after the failed move
                view.PrintFailedCarCoordinatesHeading(monsterTruck.Coordinates.X, monsterTruck.Coordinates.Y);
            }

            // Print Goodbye message on application end
            view.PrintGoodbyeMessage();
            view.FreezeApplicationUntilKeyPress(); // Exit application when key is pressed
        }

        private bool PerformSimulationCommands(Room room, Car car)
        {
            while (true)
                try
                {
                    // Ask for simulation commands
                    String rawInputData = view.AskSimulationCommands();

                    // Confirm Simulation Commands
                    view.PrintSimulationCommands(rawInputData);

                    // State that simulation has begun
                    view.PrintSimulationBegun();

                    // Try to parse the inputted data
                    char[] commands = rawInputData.ToCharArray();

                    // Perform one move for each command(why the for-loop exists)
                    for (int i = 0; i < commands.Length; i++)
                    {
                        if (commands[i].Equals(Constants.Car.Command.Left) || commands[i].Equals(Constants.Car.Command.Right))
                        {
                            CalculateNewHeading(commands[i], car);
                        }
                        else
                        {
                            bool withinBoundariesOfRoom = CalculateNewPosition(commands[i], room, car);
                            if (!withinBoundariesOfRoom)
                                return false;
                        }

                        // Print current car status after the one successful move
                        view.PrintCurrentCarCoordinatesHeading(i + 1, commands[i], car.Coordinates.X, car.Coordinates.Y, car.Heading);
                    }
                    break;
                }
                catch (Exception e)
                {
                    //view.PrintErrorValidationMessage();
                    if (e.InnerException != null)
                        view.PrintErrorValidationInnerExceptionMessage(e.InnerException.ToString());
                    else
                        view.PrintErrorValidationInnerExceptionMessage(e.Message);
                }

            return true;
        }

        private bool CalculateNewPosition(char command, Room room, Car car)
        {
            List<MovementMap> movementMaps = new List<MovementMap>();

            // Use heading of car to determine what the results of each command will be
            switch (car.Heading)
            {
                case Constants.Car.Heading.North:
                    movementMaps.Add(new MovementMap { Command = Constants.Car.Command.Forward, X = 0, Y = Constants.Car.Movement.StepLength });
                    movementMaps.Add(new MovementMap { Command = Constants.Car.Command.Backwards, X = 0, Y = -Constants.Car.Movement.StepLength });
                    break;
                case Constants.Car.Heading.South:
                    movementMaps.Add(new MovementMap { Command = Constants.Car.Command.Forward, X = 0, Y = -Constants.Car.Movement.StepLength });
                    movementMaps.Add(new MovementMap { Command = Constants.Car.Command.Backwards, X = 0, Y = Constants.Car.Movement.StepLength });
                    break;
                case Constants.Car.Heading.East:
                    movementMaps.Add(new MovementMap { Command = Constants.Car.Command.Forward, X = Constants.Car.Movement.StepLength, Y = 0 });
                    movementMaps.Add(new MovementMap { Command = Constants.Car.Command.Backwards, X = -Constants.Car.Movement.StepLength, Y = 0 });
                    break;
                case Constants.Car.Heading.West:
                    movementMaps.Add(new MovementMap { Command = Constants.Car.Command.Forward, X = -Constants.Car.Movement.StepLength, Y = 0 });
                    movementMaps.Add(new MovementMap { Command = Constants.Car.Command.Backwards, X = Constants.Car.Movement.StepLength, Y = 0 });
                    break;
                default:
                    throw new Exception("An issue occured when performing logic with the Car Heading!");
            }

            // Save new data after movement to Car model
            MovementMap movementMap = movementMaps.FirstOrDefault(x => x.Command.Equals(command));
            car.Coordinates.X += movementMap.X;
            car.Coordinates.Y += movementMap.Y;

            // Check if its within the bounds of the room
            return IsInsideRoomBoundaries(car, room);
        }

        private void CalculateNewHeading(char command, Car car)
        {
            switch (car.Heading)
            {
                case Constants.Car.Heading.North:
                    if (command.Equals(Constants.Car.Command.Left))
                        car.Heading = Constants.Car.Heading.West;
                    else
                        car.Heading = Constants.Car.Heading.East;
                    break;
                case Constants.Car.Heading.South:
                    if (command.Equals(Constants.Car.Command.Left))
                        car.Heading = Constants.Car.Heading.East;
                    else
                        car.Heading = Constants.Car.Heading.West;
                    break;
                case Constants.Car.Heading.West:
                    if (command.Equals(Constants.Car.Command.Left))
                        car.Heading = Constants.Car.Heading.South;
                    else
                        car.Heading = Constants.Car.Heading.North;
                    break;
                case Constants.Car.Heading.East:
                    if (command.Equals(Constants.Car.Command.Left))
                        car.Heading = Constants.Car.Heading.North;
                    else
                        car.Heading = Constants.Car.Heading.South;
                    break;
                default:
                    throw new Exception("An issue occured when calculating new Car Heading!");
            }
        }

        private bool IsInsideRoomBoundaries(Car car, Room room)
        {
            if (car.Coordinates.X > room.Dimension.Width || car.Coordinates.Y > room.Dimension.Height
                    || car.Coordinates.X < 0 || car.Coordinates.Y < 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private Car CreateCar(String type, Room room)
        {
            while (true)
                try
                {
                    // Ask for starting position and heading of the car
                    String rawInputData = view.AskStartingPositionHeading();

                    //Try to parse the inputted data
                    String[] rawRequestedData = rawInputData.Split(' ');

                    // Additional validations which exception-handling does not cover
                    if (rawRequestedData.Length > 3)
                        throw new Exception("There are more than three characters!");

                    char heading = Char.ToUpperInvariant(Convert.ToChar(rawRequestedData[2]));

                    if (Char.IsDigit(heading))
                        throw new Exception("Heading is not a letter!");

                    if (heading.Equals(Constants.Car.Heading.North)
                        || heading.Equals(Constants.Car.Heading.South)
                         || heading.Equals(Constants.Car.Heading.West)
                          || heading.Equals(Constants.Car.Heading.East))
                    {
                        // Create Car
                        Car car = new Car
                        {
                            Type = type,
                            Coordinates = new Coordinates { X = Convert.ToInt32(rawRequestedData[0]), Y = Convert.ToInt32(rawRequestedData[1]) },
                            Heading = heading
                        };

                        if (!IsInsideRoomBoundaries(car, room))
                            throw new Exception("You can't set coordinates which are outside the room boundaries!");

                        // Confirm dimensions of Car
                        view.PrintStartingPositionHeading(car.Coordinates.X, car.Coordinates.Y, car.Heading);

                        return car;
                    }
                    else
                    {
                        throw new Exception("Please enter a heading.");
                    }
                }
                catch (Exception e)
                {
                    //view.PrintErrorValidationMessage();
                    if (e.InnerException != null)
                        view.PrintErrorValidationInnerExceptionMessage(e.InnerException.ToString());
                    else
                        view.PrintErrorValidationInnerExceptionMessage(e.Message);
                }
        }

        private Room CreateRoom()
        {
            while (true)
                try
                {
                    // Ask for dimensions of room
                    string rawInputData = view.AskDimensionsOfRoom();

                    //Try to parse inputted data
                    int[] rawRequestedData = Array.ConvertAll<string, int>(rawInputData.Split(' '), int.Parse);

                    // Additional validations which exception-handling does not cover
                    if (rawRequestedData.Length > 2)
                        throw new Exception("There are more than two integers!");

                    // Create Room
                    Room room = new Room
                    {
                        Dimension = new Dimension { Width = rawRequestedData[0], Height = rawRequestedData[1] }
                    };

                    // Confirm dimensions of room
                    view.PrintDimensionsOfRoom(room.Dimension.Width, room.Dimension.Height);

                    return room;
                }
                catch (Exception e)
                {
                    //view.PrintErrorValidationMessage();
                    if (e.InnerException != null)
                        view.PrintErrorValidationInnerExceptionMessage(e.InnerException.ToString());
                    else
                        view.PrintErrorValidationInnerExceptionMessage(e.Message);
                }
        }

    }
}
