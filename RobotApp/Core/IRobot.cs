using RobotApp.Models;
namespace RobotApp.Core;

public interface IRobot
{
    Position CurrentPosition { get; }
    Orientation CurrentOrientation { get; }
    void TurnLeft();
    void TurnRight();
    void MoveForward();
}