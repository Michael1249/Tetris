using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameTimer timer;
    public GameField field;
    public Tetramino tetramino;
    public VisualRepresent represent;

    // Start is called before the first frame update
    void Start()
    {
        ResetGame();
    }

    public void ResetGame()
    {
        // ...
        timer.Reset();
    }

    public void Pause()
    {

    }

    public void onGameTimer()
    {
        // update game descrete step (move tetramino down, remove full lines, call represent to update)
    }
}
