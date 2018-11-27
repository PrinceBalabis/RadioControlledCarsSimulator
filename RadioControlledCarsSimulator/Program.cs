using RadioControlledCarsSimulator.Models;

namespace RadioControlledCarsSimulator
{
    class Program
    {

        static void Main(string[] args)
        {
            // Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.

            View view = new View();
            Controller controller = new Controller(view);
            controller.RunSimulation();
        }
    }
}
