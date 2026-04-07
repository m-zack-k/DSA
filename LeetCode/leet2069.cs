using System;
using System.Collections.Generic;

public class Robot
{
    private bool hasMoved = false;
    private int currentPathIndex = 0;

    // Stores the (x, y) coordinates of the grid's perimeter
    private List<int[]> perimeterCoordinates = new List<int[]>();

    // Stores the direction the robot is facing at each coordinate
    private List<int> facingDirections = new List<int>();

    // Maps the integer direction code to its string representation
    private Dictionary<int, string> directionLabels = new Dictionary<int, string>();

    public Robot(int gridWidth, int gridHeight)
    {
        directionLabels[0] = "East";
        directionLabels[1] = "North";
        directionLabels[2] = "West";
        directionLabels[3] = "South";

        // Bottom edge (moving East)
        for (int x = 0; x < gridWidth; ++x)
        {
            perimeterCoordinates.Add(new int[] { x, 0 });
            facingDirections.Add(0);
        }

        // Right edge (moving North)
        for (int y = 1; y < gridHeight; ++y)
        {
            perimeterCoordinates.Add(new int[] { gridWidth - 1, y });
            facingDirections.Add(1);
        }

        // Top edge (moving West)
        for (int x = gridWidth - 2; x >= 0; --x)
        {
            perimeterCoordinates.Add(new int[] { x, gridHeight - 1 });
            facingDirections.Add(2);
        }

        // Left edge (moving South)
        for (int y = gridHeight - 2; y > 0; --y)
        {
            perimeterCoordinates.Add(new int[] { 0, y });
            facingDirections.Add(3);
        }

        // If the robot completes a full loop and lands back on the start (0,0),
        // it will be facing South (having just travelled down the left edge).
        facingDirections[0] = 3;
    }

    public void Step(int stepsToMove)
    {
        hasMoved = true;
        currentPathIndex = (currentPathIndex + stepsToMove) % perimeterCoordinates.Count;
    }

    public int[] GetPos()
    {
        return perimeterCoordinates[currentPathIndex];
    }

    public string GetDir()
    {
        if (!hasMoved)
        {
            return "East"; // The robot initially faces East before any movement
        }
        return directionLabels[facingDirections[currentPathIndex]];
    }
}