using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarGames : MonoBehaviour
{
    CarControl m_Game;

    // Start is called before the first frame update
    void Start()
    {
        m_Game = new CarControl();
        m_Game.SetGame();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.DownArrow))
        {
            // Break
            m_Game.Break();
        }else if (Input.GetKey(KeyCode.UpArrow))
        {
            // Speed up
            m_Game.SpeedUp();
        } 

        if (Input.GetKey(KeyCode.B))
        {
            //Back
            m_Game.Back();
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            // Turn left
            m_Game.Turn("left");
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            // Turn right
            m_Game.Turn("right");
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            m_Game.SelectCar();
        }
        // Update car transform
        m_Game.UpdatePosition();
        
        

    }
}
