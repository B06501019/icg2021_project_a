using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckLine : MonoBehaviour
{
    bool isPassing = false;

    public bool IsPassing { get { return isPassing; } }

    void OnTriggerEnter2D(Collider2D other)
    {
        PassingLine();
    }

    void OnTriggerExit2D(Collider2D other)
    {
        PassedLine();
    }

    public void PassingLine()
    {
        isPassing = true;
    }

    public void PassedLine()
    {
        isPassing = false;
    }
}
