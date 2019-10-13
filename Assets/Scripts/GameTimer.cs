using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    [SerializeField]
    private GameController controller;

    [SerializeField]
    private float delay;

    // Update is called once per frame
    void Update()
    {
        // call logic.onGameTimer() with 'delay'
    }

    public void Stop()
    {

    }

    public void Reset()
    {

    }
}
