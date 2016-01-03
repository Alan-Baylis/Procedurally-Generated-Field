using UnityEngine;
using System.Collections;

public class Maze : MonoBehaviour {
    
    public int sizeX, sizeZ;
    public MazeCell cell;
    public float delayTime = 0.01f;
    private MazeCell[,] cells;
    
    public IEnumerator Generate() {
        cells = new MazeCell[sizeX, sizeZ];
        for (int i = 0; i < sizeX; i++) {
            for (int j = 0; j < sizeZ; j++) {
                yield return new WaitForSeconds(delayTime);
                CreateCell(i, j);
            }
        }
    }
    
    private void CreateCell(int x, int z) {
        // Create a cell prefab and snap it to some position
        cells[x, z] = Instantiate(cell) as MazeCell;
        cells[x, z].name = "Maze Cell: " + x + " " + z;
        cells[x, z].transform.parent = transform;
        cells[x, z].transform.localPosition = new Vector3(x - sizeX * 0.5f + 0.5f, 0f, z - sizeZ * 0.5f + 0.5f);
    }
}
