using RobotApp.Models;
namespace RobotApp.Core;

public class Grid
{
    private int Width { get; }
    private int Height { get; }

    public Grid(int width, int height)
    {
        //TODO: MINI Validate??
        Width = width;
        Height = height;
    }

    public bool IsPointWithinGridBounds(Position position)
    {
        return position.X >= 0 && position.X < Width &&
               position.Y >= 0 && position.Y < Height;
    }
}