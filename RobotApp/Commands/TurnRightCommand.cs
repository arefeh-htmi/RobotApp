using RobotApp.Services;

namespace RobotApp.Commands;

public class TurnRightCommand(IRobot robot) : ICommand
{
    public void Execute() => robot.TurnRight();
}

