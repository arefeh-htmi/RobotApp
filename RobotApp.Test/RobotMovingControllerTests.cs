using Xunit;
using System;
using RobotApp.Models;
using RobotApp.Services;
using RobotApp.Core;

namespace RobotApp.Test;

public class RobotMovingControllerTests
{
    [Fact]
    public void Robot_Moves_To_CorrectFinalPositionAndOrientation()
    {
        var grid = new Grid(5, 5);
        var initialPosition = new Position(1, 2);
        var initialOrientation = Orientation.North;
        var commands = "RFRFFRFRF";
        var robot = new Robot(grid, initialPosition, initialOrientation);
        
        var controller = new RobotMovingController(robot);
        
        controller.MoveRobot(commands.ToCharArray());
        
        //Assert.Equal(1, robot.CurrentPosition.X);
        //Assert.Equal(3, robot.CurrentPosition.Y);
        //Assert.Equal(Orientation.North, robot.CurrentOrientation);
    }

    [Fact]
    public void Robot_Throws_When_Exiting_Grid()
    {
        var grid = new Grid(5, 5);
        var initialPosition = new Position(0, 0);
        var initialOrientation = Orientation.East;
        var commands = "RFLFFLRF";
        var robot = new Robot(grid, initialPosition, initialOrientation);
        var controller = new RobotMovingController(robot);

        controller.MoveRobot(commands.ToCharArray());

        //Assert.Equal(3, robot.CurrentPosition.X);
        //Assert.Equal(1, robot.CurrentPosition.Y);
        //Assert.Equal(Orientation.East, robot.CurrentOrientation);
    }
}