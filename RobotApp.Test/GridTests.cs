
using RobotApp.Models;
using RobotApp.Core;
using RobotApp.Services;
using Xunit;
using System;
namespace RobotApp.Test;

public class GridTests
{
    [Fact]
    public void IsWithinBounds_ValidPosition_ReturnsTrue()
    {
        var grid = new Grid(5, 5);
        var position = new Position(2, 3);

        var result = grid.IsPointWithinGridBounds(position);

        Assert.True(result);
    }

    [Fact]
    public void IsWithinBounds_InvalidPosition_ReturnsFalse()
    {
        var grid = new Grid(5, 5);
        var position = new Position(5, 6); 
        
        var result = grid.IsPointWithinGridBounds(position);
        
        Assert.False(result);
    }

    [Fact]
    public void Grid_NegativeDimensions_ThrowsException()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new Grid(-1, 5));
    }
}