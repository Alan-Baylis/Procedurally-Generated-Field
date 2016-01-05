using UnityEngine;
using System.Collections;

public class MazeCellEdge : MonoBehaviour {
    
    public MazeCell cell, otherCell;
    public MazeDirection direction;
    
    private 

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    
    #region Public Methods
    /// <summary>
    /// Registers an edge to a cell.
    /// </summary>
    /// <param name="cell">Reference to a MazeCell instantiated.</param>
    /// <param name="otherCell">Neighbor MazeCell instantiated.</param>
    /// <param name="direction">Relative location of the edge.</param>
    public void Initialize(MazeCell cell, MazeCell otherCell, MazeDirection direction) {
        this.cell = cell;
        this.otherCell = otherCell;
        this.direction = direction;
        cell.SetEdge(direction, this);
        transform.parent = cell.transform;
        transform.localPosition = Vector3.zero;
    }
    #endregion
}
