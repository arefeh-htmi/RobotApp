using RobotApp.Models;
using RobotApp.Services;
using RobotApp.Core;

namespace RobotApp;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            //TODO: the logic could get furthur broken down?
            Console.WriteLine("Enter grid dimensions width and height:");

            var gridDimensions = Console.ReadLine()?.Split(' ') ?? [];
            var canParseGridWidth = int.TryParse(gridDimensions[0], out int gridWidth);
            var canParseGridHeight = int.TryParse(gridDimensions[1], out int gridHeight);
            if (gridDimensions.Length != 2 || !canParseGridWidth || !canParseGridHeight)
            {
                Console.WriteLine("Invalid grid size...Exiting :)))");
                return;
            }

            Console.WriteLine("Enter robot's starting position and orientation(N, E, W, S):");
            var robotInitial = Console.ReadLine()?.Split(' ') ?? [];
            if (!int.TryParse(robotInitial[0], out int robotStartingX) ||
                !int.TryParse(robotInitial[1], out int robotStartingY) ||
                !Char.TryParse(robotInitial[2], out Char orientationChar))
            {
                Console.WriteLine("Invalid robot initial state. Exiting.");
                return;
            }

            var isValidOrientation = Enum.TryParse(orientationChar.ToString(), out Orientation orientation);
            if (!isValidOrientation)
            {
                throw new ArgumentException("Invalid orientation");
            }
            var grid = new Grid(gridWidth, gridHeight);
            var initialPosition = new Position(robotStartingX, robotStartingY);

            var robot = new Robot(grid, initialPosition, orientation);

            Console.WriteLine("Enter commands (L, R, F):");
            var commandString = Console.ReadLine()?.ToUpper();

            if (string.IsNullOrWhiteSpace(commandString))
            {
                Console.WriteLine("No commands provided. Exiting.");
                return;
            }
            
            var robotMovingController = new RobotMovingController(robot);
            robotMovingController.MoveRobot(commandString.ToCharArray());
            
            Console.WriteLine(
                $"Final Position: {robot.CurrentPosition}, Final Direction: {robot.CurrentOrientation}");
            
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Teh following Error occured: {ex.Message} ... Exiting");
            return;
        }
    }
}