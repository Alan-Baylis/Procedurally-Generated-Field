using UnityEngine;
using System.Collections;

public class MazeCell : MonoBehaviour {
    
    public IntVector2 coordinates;
    
    private MazeCellEdge[] cellEdges;
    
    private void Awake() {
        cellEdges = new MazeCellEdge[MazeDirections.count];
    }

    #region Public Methods    
    /// <summary>
    /// Sets a reference to an edge via the direction.
    /// </summary>
    /// <param name="direction">Direction of an edge.</param>
    /// <param name="edge">MazeCellEdge associated with the direction.</param>
    public void SetEdge(MazeDirection direction, MazeCellEdge edge) {
        cellEdges[(int)direction] = edge;
    }
    
    /// <summary>
    /// Gets an edge of a cell associated with a direction.
    /// </summary>
    /// <param name="direction">Relative direction of an edge on a cell.</param>
    /// <returns>
    public MazeCellEdge GetEdge(MazeDirection direction) {
        return cellEdges[(int)direction];
    }
    
    #endregion
}
