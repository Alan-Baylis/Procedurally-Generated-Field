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
        FirstGenerationStep(activeCells); // Perform the first step of the generation
        while (DoesContainCoordinates(coordinates) && !DoesCellExist(coordinates)) {
            yield return new WaitForSeconds(delayTime);
            NextGenerationStep(activeCells); // Do the next generation steps
        }
    }
    
    /// <summary>
    /// Checks if a pair of coordinates are in bound.
    /// </summary>
    /// <returns>True if coordinates are in bound, false if not.</returns>
    public bool DoesContainCoordinates(IntVector2 coordinate) {
        return coordinate.x >= 0 && coordinate.x < fieldDimension.x && coordinate.z >= 0 && coordinate.z < fieldDimension.z; 
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
        MazeCell newCell = Instantiate(cell) as MazeCell;         // Create a cell object and snap it to some position
        cells[coordinates.x, coordinates.z] = newCell;
        newCell.coordinates = coordinates;
        newCell.name = "Maze Cell: " + coordinates.x + " " + coordinates.z;
        newCell.transform.parent = transform;
        newCell.transform.localPosition = new Vector3(coordinates.x - fieldDimension.x * 0.5f + 0.5f, 0f, coordinates.z - fieldDimension.z * 0.5f + 0.5f);
        return newCell;
    }
    
    private void FirstGenerationStep(List<MazeCell> activeCells) {
        activeCells.Add(CreateCell(GetRandomCoordinates)); // Creates the first cell in the Maze and adds it to an active list
    }
    
    private void NextGenerationStep (List<MazeCell> activeCells) {
        int index = activeCells.Count - 1; // Set the index at the end of the list
        Debug.Log(index);
        MazeCell currentCell = activeCells[index];
        MazeDirection direction = MazeDirections.getRandomValue;
        IntVector2 coordinates = currentCell.coordinates + direction.IntToVector2();
        if (DoesContainCoordinates(coordinates) && !DoesCellExist(coordinates)) {
            activeCells.Add(CreateCell(coordinates));
        }
        else {
            activeCells.RemoveAt(index);
        }
    }
}
