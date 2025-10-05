using Xunit;
using System;
using RobotApp.Models;
using RobotApp.Services;
using RobotApp.Core;

namespace RobotApp.Test;

public class RobotTests
{
    [Fact]
    public void InitialPosition_IsCorrectlySet()
    {
        var grid = new Grid(5, 5);
        var initialPos = new Position(1, 2);
        var initialOrientation = Orientation.North;
        var robot = new Robot(grid, initialPos, initialOrientation);

        Assert.Equal(1, robot.CurrentPosition.X);
        Assert.Equal(2, robot.CurrentPosition.Y);
        Assert.Equal(Orientation.North, robot.CurrentOrientation);
    }

    [Theory]
    [InlineData(Orientation.North, Orientation.West)]
    [InlineData(Orientation.East, Orientation.North)]
    [InlineData(Orientation.South, Orientation.East)]
    [InlineData(Orientation.West, Orientation.South)]
    public void TurnLeft_ChangesOrientationCorrectly(Orientation initialOrientation, Orientation expectedOrientation)
    {
        var grid = new Grid(5, 5);
        var initialPos = new Position(1, 2);
        var robot = new Robot(grid, initialPos, initialOrientation);
        robot.TurnLeft();

        Assert.Equal(expectedOrientation, robot.CurrentOrientation);
    }

    [Theory]
    [InlineData(Orientation.North, Orientation.East)]
    [InlineData(Orientation.East, Orientation.South)]
    [InlineData(Orientation.South, Orientation.West)]
    [InlineData(Orientation.West, Orientation.North)]
    public void TurnRight_ChangesOrientationCorrectly(Orientation initialOrientation, Orientation expectedOrientation)
    {
        var grid = new Grid(5, 5);
        var initialPos = new Position(1, 2);
        var robot = new Robot(grid, initialPos, initialOrientation);
        robot.TurnRight();

        Assert.Equal(expectedOrientation, robot.CurrentOrientation);
    }

    [Fact]
    public void MovingOffGrid_Exists()
    {
        var grid = new Grid(3, 3);
        var initialPos = new Position(0, 0);
        var robot = new Robot(grid, initialPos, Orientation.North);
        Assert.Throws<InvalidOperationException>(() => robot.MoveForward());
    }
}