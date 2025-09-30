using RobotApp.Services;

namespace RobotApp.Commands;

public class MoveForwardCommand(IRobot robot) : ICommand
{
    public void Execute() => robot.MoveForward();
}