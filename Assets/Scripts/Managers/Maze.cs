using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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
        List<MazeCell> activeCells = new List<MazeCell>(); // Keeps an active list of cells
        cells = new MazeCell[fieldDimension.x, fieldDimension.z];
        IntVector2 coordinates = GetRandomCoordinates;
        while (DoesContainCoordinates(coordinates) && !DoesCellExist(coordinates)) {
            yield return new WaitForSeconds(delayTime);
            CreateCell(coordinates);
            coordinates += MazeDirections.getRandomValue.IntToVector2();
        }
    }
    
    /// <summary>
    /// Checks if a pair of coordinates are in bound.
    /// </summary>
    /// <returns>True if coordinates are in bound, false if not.</returns>
    public bool DoesContainCoordinates(IntVector2 coordinates) {
        return coordinates.x >= 0 && coordinates.x < fieldDimension.x && coordinates.z >= 0 && coordinates.z < fieldDimension.z; 
    }
    
    /// <summary>
    /// Checks if a cell exist in the coordinate space.
    /// </summary>
    /// <param name="coordinates">Set of coordinates</param>
    /// <returns>True if the cell exists</returns>
    public bool DoesCellExist(IntVector2 coordinates) {
        if (cells[coordinates.x, coordinates.z] != null) {
            return true;
        }
        return false;
    }
    #endregion
    
    private MazeCell CreateCell(IntVector2 coordinates) {
        // Create a cell object and snap it to some position
        MazeCell newCell = Instantiate(cell) as MazeCell;
        cells[coordinates.x, coordinates.z] = newCell;
        newCell.name = "Maze Cell: " + coordinates.x + " " + coordinates.z;
        newCell.transform.parent = transform;
        newCell.transform.localPosition = new Vector3(coordinates.x - fieldDimension.x * 0.5f + 0.5f, 0f, coordinates.z - fieldDimension.z * 0.5f + 0.5f);
        return newCell;
    }
    
    private void FirstGenerationStep(List<MazeCell> activeCells) {
        // Creates the first cell in the Maze and adds it to an active list
        activeCells.Add(CreateCell(GetRandomCoordinates));
    }
}
