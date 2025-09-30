using RobotApp.Models;

namespace RobotApp.Core;
public class Robot : IRobot
{
    private readonly Grid _grid;
    private Position _currentPosition;
    private Orientation _currentOrientation;

    public Robot(Grid grid, Position initialPosition, Orientation initialOrientation)
    {
        if (!grid.IsPointWithinGridBounds(initialPosition))
        {
            throw new ArgumentException("Initial position is outside the grid bounds.");
        }
        _grid = grid;
        _currentPosition = initialPosition;
        _currentOrientation = initialOrientation;
    }

    public Position CurrentPosition => _currentPosition;
    public Orientation CurrentOrientation => _currentOrientation;

    public void TurnLeft()
    {
        _currentOrientation = _currentOrientation switch
        {
            Orientation.North => Orientation.West,
            Orientation.West => Orientation.South,
            Orientation.South => Orientation.East,
            Orientation.East => Orientation.North,
            _ => _currentOrientation
        };
    }

    public void TurnRight()
    {
        _currentOrientation = _currentOrientation switch
        {
            Orientation.North => Orientation.East,
            Orientation.East => Orientation.South,
            Orientation.South => Orientation.West,
            Orientation.West => Orientation.North,
            _ => _currentOrientation
        };
    }

    public void MoveForward()
    {
        var newPosition = _currentOrientation switch
        {
            Orientation.North => _currentPosition with { Y = _currentPosition.Y + 1 },
            Orientation.South => _currentPosition with { Y = _currentPosition.Y - 1 },
            Orientation.East => _currentPosition with { X = _currentPosition.X + 1 },
            Orientation.West => _currentPosition with { X = _currentPosition.X - 1 },
            _ => _currentPosition
        };

        if (!_grid.IsPointWithinGridBounds(newPosition))
        {
            throw new InvalidOperationException($"Attempted to move outside grid bounds at {newPosition}.");
        }

        _currentPosition = newPosition;
    }
}