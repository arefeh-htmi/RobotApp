using RobotApp.Core;
namespace RobotApp.Commands;

public class TurnRightCommand(IRobot robot) : ICommand
{
    public void Execute() => robot.TurnRight();
}

