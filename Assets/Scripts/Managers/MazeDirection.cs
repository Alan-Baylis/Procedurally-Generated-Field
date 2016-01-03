using UnityEngine;
using System.Collections;

public enum MazeDirection { North, East, South, West }

public static class MazeDirections {
    
    public const int count = 4; // Defines how many directions there are
    public static MazeDirection getRandomValue { get { return (MazeDirection)Random.Range(0, count); } } // Returns a random set of integers
    
    public static IntVector2 IntToVector2(MazeDirection direction) {
        return directionVectors[(int)direction];
    }
    
    private static IntVector2[] directionVectors = { // Directional Vector reference
        new IntVector2(0, 1), // North
        new IntVector2(1, 0), // East
        new IntVector2(0, -1), // South
        new IntVector2(-1, 0) // WEst
    };
    
}
