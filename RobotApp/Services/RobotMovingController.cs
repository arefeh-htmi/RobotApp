using RobotApp.Commands;
using RobotApp.Models;
using RobotApp.Core;

namespace RobotApp.Services;

interface IRobotMovingController
{
    public void MoveRobot(Char[] commandsList);
}

public class RobotMovingController : IRobotMovingController
{
    private readonly IRobot _robot;

    //Keeps a mapping between commands and teh directions that user entered. TODO:Maybe move this :)
    private readonly Dictionary<char, Func<ICommand>> _directionToCommandMap;

    public RobotMovingController(IRobot robot)
    {
        _robot = robot;
        _directionToCommandMap = new Dictionary<char, Func<ICommand>>
        {
            { (char)Direction.Left, () => new TurnLeftCommand(_robot) },
            { (char)Direction.Right, () => new TurnRightCommand(_robot) },
            { (char)Direction.Forward, () => new MoveForwardCommand(_robot) }
        };
    }

    public void MoveRobot(Char[] commandsList)
    {
        foreach (char commandChar in commandsList)
        {
            var commandIsValid = _directionToCommandMap.TryGetValue(commandChar, out var commandFunction);
            if (commandIsValid && commandFunction != null)
            {
                ICommand command = commandFunction.Invoke();
                command.Execute();
            }
            else
            {
                Console.WriteLine($"Unknown command was entered: '{commandChar}'.");
            }
        }
    }
}