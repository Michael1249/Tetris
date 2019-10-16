using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Tetramino : MonoBehaviour
{
    [SerializeField]
    private GameController controller;

    private Color color;
    private Vector2Int pos;
    private Vector2Int[] parts = new Vector2Int[4];

    private Vector2Int[,] tetramino = new Vector2Int[7, 4];

    Vector2Int fieldSize;

    // Start is called before the first frame update
    void Start()
    {
        fieldSize = controller.field.getFieldSize();

        // I 
        tetramino[0, 0] = new Vector2Int(0, 0);
        tetramino[0, 1] = new Vector2Int(0, 1);
        tetramino[0, 2] = new Vector2Int(0, 2);
        tetramino[0, 3] = new Vector2Int(0, 3);

        // S
        tetramino[1, 0] = new Vector2Int(1, 0);
        tetramino[1, 1] = new Vector2Int(2, 0);
        tetramino[1, 2] = new Vector2Int(0, 1);
        tetramino[1, 3] = new Vector2Int(1, 1);

        // L 
        tetramino[2, 0] = new Vector2Int(0, 0);
        tetramino[2, 1] = new Vector2Int(0, 1);
        tetramino[2, 2] = new Vector2Int(0, 2);
        tetramino[2, 3] = new Vector2Int(1, 2);

        // T 
        tetramino[3, 0] = new Vector2Int(1, 0);
        tetramino[3, 1] = new Vector2Int(0, 1);
        tetramino[3, 2] = new Vector2Int(1, 1);
        tetramino[3, 3] = new Vector2Int(2, 1);

        // J
        tetramino[4, 0] = new Vector2Int(1, 0);
        tetramino[4, 1] = new Vector2Int(1, 1);
        tetramino[4, 2] = new Vector2Int(1, 2);
        tetramino[4, 3] = new Vector2Int(0, 2);

        // Z 
        tetramino[5, 0] = new Vector2Int(0, 0);
        tetramino[5, 1] = new Vector2Int(1, 0);
        tetramino[5, 2] = new Vector2Int(1, 1);
        tetramino[5, 3] = new Vector2Int(2, 1);

        // O
        tetramino[5, 0] = new Vector2Int(0, 0);
        tetramino[5, 1] = new Vector2Int(1, 0);
        tetramino[5, 2] = new Vector2Int(0, 1);
        tetramino[5, 3] = new Vector2Int(1, 1);

        Reset();
    }

    private void setParts(int n)
    {
        for (int i = 0; i < 4; i++)
        {
            parts[i] = tetramino[n, i];
        }
    }

    // if tetramino is stucked it should reset
    void Reset()
    {
        setParts(UnityEngine.Random.Range(0, 7));
        pos = new Vector2Int(fieldSize.x / 2, 0);
        controller.field.addCells(getAbsolutePos());
    }

    private Vector2Int[] getAbsolutePos()
    {
        Vector2Int[] absolutePos = new Vector2Int[4];
        for (int i = 0; i < 4; i++)
        {
            absolutePos[i] = new Vector2Int(pos.x + parts[i].x, pos.y + parts[i].y);
        }

        return absolutePos;
    }

    public void Move()
    {
        // move down, check for colision and stuck
        // if stuck, reset

        if (controller.field.isTetraminoStuck(getAbsolutePos()))
            Reset();
        else
        {
            controller.field.clearCells(getAbsolutePos());
            pos.y++;
            controller.field.addCells(getAbsolutePos());
        }
    }

    public void moveRight()
    {
        if(!controller.field.isTetraminoColide(getAbsolutePos()))
        {
            controller.field.clearCells(getAbsolutePos());
            pos.x++;
            controller.field.addCells(getAbsolutePos());
        }
    }

    public void moveLeft()
    {
        if(!controller.field.isTetraminoColide(getAbsolutePos()))
        {
            controller.field.clearCells(getAbsolutePos());
            pos.x--;
            controller.field.addCells(getAbsolutePos());
        }
    }

    public void RotateLeft()
    {
        int angle = (int)(-90 * Math.PI / 180);
        for (int i = 0; i < parts.Length; i++)
        {
            double x0 = maxXPart()/2 + 1, y0 = maxYPart() / 2 + 1;

            parts[i].x = Decimal.ToInt32(Math.Floor(Convert.ToDecimal(x0 + (parts[i].x - x0) * Math.Cos(angle) - (parts[i].y - y0) * Math.Sin(angle))));
            parts[i].y = Decimal.ToInt32(Math.Floor(Convert.ToDecimal(y0 + (parts[i].x - x0) * Math.Sin(angle) + (parts[i].y - y0) * Math.Cos(angle))));
        }
    }

    public void RotateRight()
    {
        int angle = (int)(90 * Math.PI / 180);
        for (int i = 0; i < parts.Length; i++)
        {
            double x0 = maxXPart()/2 + 1, y0 = maxYPart() / 2 + 1;

            parts[i].x = Decimal.ToInt32(Math.Floor(Convert.ToDecimal(x0 + (parts[i].x - x0) * Math.Cos(angle) - (parts[i].y - y0) * Math.Sin(angle))));
            parts[i].y = Decimal.ToInt32(Math.Floor(Convert.ToDecimal(y0 + (parts[i].x - x0) * Math.Sin(angle) + (parts[i].y - y0) * Math.Cos(angle))));
        }
            //double x0, y0;
            //x0 = 1;
            //y0 = 1.5;

            //parts[i].x = Math.Floor(x0 + (parts[i].x - x0) * Math.Cos(90 * 3.14 / 180) - (parts[i].y - y0) * Math.Sin(90 * 3.14 / 180));
            //parts[i].y = Math.Floor(y0 + (parts[i].x - x0) * Math.Sin(90 * 3.14 / 180) + (parts[i].y - y0) * Math.Cos(90 * 3.14 / 180));
    }

    private int maxXPart()
    {
        int max = parts[0].x;
        for(int i = 1; i < parts.Length; i++)
            if(parts[i].x > max) max = parts[i].x;

        return max;
    }

    private int maxYPart()
    {
        int max = parts[0].y;
        for (int i = 1; i < parts.Length; i++)
            if (parts[i].y > max) max = parts[i].y;

        return max;
    }

    public Color getColor()
    {
        return color;
    }

    public Vector2Int getPos()
    {
        return pos;
    }

    public Vector2Int[] getParts()
    {
        return parts;
    }
}
