using UnityEngine;
using System.Collections;

public class Maze : MonoBehaviour {
    
    public IntVector2 fieldDimension;
    public MazeCell cell;
    public float delayTime = 0.01f;
    private MazeCell[,] cells;
    
    // Coroutine generates the field progressively.
    public IEnumerator Generate() {
        cells = new MazeCell[fieldDimension.x, fieldDimension.z];
        for (int i = 0; i < fieldDimension.x; i++) {
            for (int j = 0; j < fieldDimension.z; j++) {
                yield return new WaitForSeconds(delayTime);
                CreateCell(new IntVector2(i, j));
            }
        }
    }
    
    private void CreateCell(IntVector2 coordinates) {
        // Create a cell object and snap it to some position
        MazeCell newCell = Instantiate(cell) as MazeCell;
        cells[coordinates.x, coordinates.z] = newCell;
        newCell.name = "Maze Cell: " + coordinates.x + " " + coordinates.z;
        newCell.transform.parent = transform;
        newCell.transform.localPosition = new Vector3(coordinates.x - fieldDimension.x * 0.5f + 0.5f, 0f, coordinates.z - fieldDimension.z * 0.5f + 0.5f);
    }
}
