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

    private int LogNum = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (field == null)
        {
            InitField();
        }
    }

    void InitField()
    {
        field = new Cell[field_size.x, field_size.y];

        for (int i = 0; i < field_size.x; i++)
        {
            for (int j = 0; j < field_size.y; j++)
            {
                field[i, j] = new Cell();
                field[i, j].state = ((i + j) % 2) == 0;
               
        field[i, j].color = Color.red; // for example
            }
        }
        controller.represent.UpdateRepresent();
    }

    // it'll call before tetramino move
    // clear tetramino's cells from field
    public void clearCells(Vector2Int[] cells)
    {
        for (int i = 0; i < cells.Length; i++)
        {
            field[cells[i].x, cells[i].y].state = false;
        }
    }

    // it'll call after tetramino move
    // add tetramino's cells from field
    // call represent update
    public void addCells(Vector2Int[] cells)
    {
        for (int i = 0; i < cells.Length; i++)
        {
            field[cells[i].x, cells[i].y].state = true;
        }
    }

    // check tetramino is colide with field
    public bool isTetraminoColide(Vector2Int[] tetraminoAbsoluteCells)
    {
        for (int i = 0; i < tetraminoAbsoluteCells.Length; i++)
        {
            if (tetraminoAbsoluteCells[i].x < 0 
                || tetraminoAbsoluteCells[i].y < 0 
                || tetraminoAbsoluteCells[i].x >= field_size.x 
                || tetraminoAbsoluteCells[i].y >= field_size.y)
            {
                return true;
            }
        }
        
        return false;
    }

    //check if tetramino is stucked and can't move down
    public bool isTetraminoStuck(Vector2Int[] tetraminoAbsoluteCells)
    {
        for (int i = 0; i < tetraminoAbsoluteCells.Length; i++)
        {
            if (field[tetraminoAbsoluteCells[i].x, tetraminoAbsoluteCells[i].y].state)
            {
                return true;
            }
        }
        
        return false;
    }

    public void RemoveFullLines()
    {

        for (int i = 0; i < field_size.x; i++)
        {
            // Check line
            var flag = true;

            for (int j = 0; j < field_size.y; j++)
            {
                if (field[i, j].state == false)
                {
                    flag = false;
                }
            }

            if (flag)
            {
                // Delete Line
                for (int j = 0; j < field_size.y; j++)
                {
                    field[i, j].state = false;
                }
                // Drop all that is above
                DropCells(i);
            }
        }
    }

   
    private void DropCells(int deletedRow)
    {
        if (deletedRow == 0) return;

        for (int i = deletedRow - 1; i >= 0; i--)
        {
            for (int j = 0; j < field_size.y; j++)
            {
                field[i + 1, j].state = field[i, j].state;
                if (i == 0)
                {
                    field[i, j].state = false;
                }
            }
        }
    }

    public Vector2Int getFieldSize()
    {
        return field_size;
    }

    public Cell[,] getField()
    {
        return field;
    }

    /* Methods for tests by logging*/

    private void PrintFieldInLog()
    {
        if (LogNum == 0)
            Debug.Log("Field size: " + field_size.x + "/" + field_size.y);

        Debug.Log("Log № " + LogNum);
        LogNum++;

        string[] lines = new string[field_size.y];

        for (int i = 0; i < field_size.x; i++)
        {
            string line = "";
            for (int j = 0; j < field_size.y; j++)
            {
                line = line + field[i, j].state + " ";
            }
            lines[i] = line;
        }

        for (int i = 0; i < lines.Length; i++)
        {
            Debug.Log(lines[i]);
        }
    }

    private void InitFieldForTest()
    {
        for (int i = 0; i < field_size.x; i++)
        {
            for (int j = 0; j < field_size.y; j++)
            {
                field[i, j] = new Cell();
                if (i == 1 || i == 3)
                {
                    field[i, j].state = true;
                }
                if (j <= i)
                {
                    field[i, j].state = true;
                }
            }
        }
    }
}
