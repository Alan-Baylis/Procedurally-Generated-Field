using UnityEngine;
using System.Collections;

public class Maze : MonoBehaviour {
    
    public IntVector2 fieldDimension;
    public MazeCell cell;
    public float delayTime = 0.01f;
    private MazeCell[,] cells;
    
    /// <summary>
    /// Returns a struct of two random coordinates.
    /// </summary>
    public IntVector2 GetRandomCoordinates {
        get { return new IntVector2(Random.Range(0, fieldDimension.x), Random.Range(0, fieldDimension.z)); }
    }
    
    #region Public Methods
    /// <summary>
    /// Coroutine generates the field progressively.
    /// <summary>
    public IEnumerator Generate() {
        cells = new MazeCell[fieldDimension.x, fieldDimension.z];
        IntVector2 coordinates = GetRandomCoordinates;
        while (DoesContainCoordinates(coordinates)) {
            yield return new WaitForSeconds(delayTime);
            CreateCell(coordinates);
            coordinates.z += 1;
        }
    }
    
    /// <summary>
    /// Checks if a pair of coordinates are in bound.
    /// </summary>
    /// <returns>True if coordinates are in bound, false if not.</returns>
    public bool DoesContainCoordinates(IntVector2 coordinates) {
        return coordinates.x >= 0 && coordinates.x < fieldDimension.x && coordinates.z >= 0 && coordinates.z < fieldDimension.z; 
    }
    #endregion
    
    private void CreateCell(IntVector2 coordinates) {
        // Create a cell object and snap it to some position
        MazeCell newCell = Instantiate(cell) as MazeCell;
        cells[coordinates.x, coordinates.z] = newCell;
        newCell.name = "Maze Cell: " + coordinates.x + " " + coordinates.z;
        newCell.transform.parent = transform;
        newCell.transform.localPosition = new Vector3(coordinates.x - fieldDimension.x * 0.5f + 0.5f, 0f, coordinates.z - fieldDimension.z * 0.5f + 0.5f);
    }    
}
