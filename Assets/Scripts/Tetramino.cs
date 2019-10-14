using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tetramino : MonoBehaviour
{
    [SerializeField]
    private GameController controller;

    private Color color;
    private Vector2Int pos;
    private Vector2Int[] parts;

    // Start is called before the first frame update
    void Start()
    {
        Reset();
    }

    // if tetramino is stucked it should reset
    void Reset()
    {

    }

    public void Move()
    {
        // move down, check for colision and stuck
        // if stuck, reset
    }

    public void RotateLeft()
    {
        Vlad;
    }

    public void RotateRight()
    {

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
