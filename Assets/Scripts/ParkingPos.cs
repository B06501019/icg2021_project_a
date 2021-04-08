using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkingPos : MonoBehaviour
{
    public GameObject center;
    bool check = true;
    
    void OnTriggerStay2D(Collider2D other)
    {
        if (center.GetComponent<CheckLine>().IsPassing && check)
        {
            Debug.Log("nice job.");
            check = false;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("you're out");
        check = true;
    }
}
