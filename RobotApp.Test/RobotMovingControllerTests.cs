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
        var (robot, controller) = InitializeRobot(grid, initialPosition, initialOrientation);

        controller.MoveRobot(commands.ToCharArray());

        Assert.Equal(1, robot.CurrentPosition.X);
        Assert.Equal(3, robot.CurrentPosition.Y);
        Assert.Equal(Orientation.North, robot.CurrentOrientation);
    }

    [Fact]
    public void Robot_Moves_To_CorrectFinalPositionAndOrientation_StartingAtStartOfGrid()
    {
        var grid = new Grid(5, 5);
        var initialPosition = new Position(0, 0);
        var initialOrientation = Orientation.East;
        var commands = "RFLFFLRF";
        var (robot, controller) = InitializeRobot(grid, initialPosition, initialOrientation);

        controller.MoveRobot(commands.ToCharArray());

        Assert.Equal(3, robot.CurrentPosition.X);
        Assert.Equal(1, robot.CurrentPosition.Y);
        Assert.Equal(Orientation.East, robot.CurrentOrientation);
    }

    [Fact]
    public void Robot_Throws_When_Exiting_Grid_After_Moving()
    {
        var grid = new Grid(5, 5);
        var initialPosition = new Position(0, 0);
        var initialOrientation = Orientation.North;
        var commands = "FLFFLRF";
        var (_, controller) = InitializeRobot(grid, initialPosition, initialOrientation);
        
        Assert.Throws<InvalidOperationException>(() => controller.MoveRobot(commands.ToCharArray()));
    }
    
    [Fact]
    public void Robot_Throws_When_Starting_Off_Grid()
    {
        var grid = new Grid(5, 5);
        var initialPosition = new Position(5, 0);
        var initialOrientation = Orientation.North;
        
        Assert.Throws<ArgumentException>(() => InitializeRobot(grid, initialPosition, initialOrientation));
    }
    
    [Fact]
    public void Robot_Throws_When_Invalid_Command()
    {
        var grid = new Grid(5, 5);
        var initialPosition = new Position(1, 2);
        var initialOrientation = Orientation.North;
        var commands = "TRFRFFRFRF";
        var (robot, controller) = InitializeRobot(grid, initialPosition, initialOrientation);
        
        Assert.Throws<ArgumentException>(() => controller.MoveRobot(commands.ToCharArray()));
    }

    private (IRobot robot, RobotMovingController controller) InitializeRobot(Grid grid, Position initialPosition, Orientation initialOrientation)
    {
        var robot = new Robot(grid, initialPosition, initialOrientation);
        var controller = new RobotMovingController(robot);
        return (robot, controller);
    }
}