using UnityEngine;
using System.Collections;

public class MazeDirection {
    
    public const int count = 4; // Defines how many directions there are
    public static int GetRandomValue {
        get { return (Random.Range(0, count)); }
    }
}
