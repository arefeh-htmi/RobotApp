using RobotApp.Core;

namespace RobotApp.Commands;

public class MoveForwardCommand(IRobot robot) : ICommand
{
    public void Execute() => robot.MoveForward();
}