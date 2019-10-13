using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualRepresent : MonoBehaviour
{
    [SerializeField]
    private GameController controller;

    void Start()
    {

    }

    // it'll be called by GameLogic when field is updated
    void UpdateRepresent()
    {
        // with field.getField() and field.getFieldSize() update represent
    }
}
