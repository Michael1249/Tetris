using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameField : MonoBehaviour
{
    [SerializeField]
    private GameController controller;

    [SerializeField]
    private Vector2Int field_size;

    private Cell[,] field;

    // Start is called before the first frame update
    void Start()
    {
        field = new Cell[field_size.x, field_size.y];
    }

    // it'll call before tetramino move
    public void clearCells()
    {
        // clear tetramino's cells from field
    }

    // it'll call after tetramino move
    public void addCells()
    {
        // add tetramino's cells from field
        // call represent update
    }

    public bool isTetraminoColide()
    {
        // check tetramino is colide with field
        return false;
    }

    public bool isTetraminoStuck()
    {
        //check if tetramino is stucked and can't move down
        return false;
    }

    public void RemoveFullLines()
    {
        // remove all full lines 
    }

    public Vector2Int getFieldSize()
    {
        return field_size;
    }

    public Cell[,] getField()
    {
        return field;
    }
}
