using RobotApp.Services;

namespace RobotApp.Commands;

public class TurnLeftCommand(IRobot robot) : ICommand
{
    public void Execute() => robot.TurnLeft();
}