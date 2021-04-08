using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OperatorEntity : MonoBehaviour
{
    SpriteRenderer m_TargerRenderer;
    float m_WheelSteeringAngle = 0;
    const float WHEEL_LIMIT = 180f;
    public float turnAngularVelocity = 150f;

    void Start()
    {
        m_TargerRenderer = this.GetComponent<SpriteRenderer>();
    }

    public void Press()
    {
        m_TargerRenderer.color = Color.white;
        this.Invoke("ResetColor", 1f);
    }

    void ResetColor()
    {
        m_TargerRenderer.color = Color.gray;
    }
    
    public void Rotation(string direction)
    {
        switch (direction)
        {
            case "left":
                m_WheelSteeringAngle = 
                    m_WheelSteeringAngle + Time.deltaTime * turnAngularVelocity;


                UpdateRotation();

                break;
            case "right":
                m_WheelSteeringAngle = 
                    m_WheelSteeringAngle - Time.deltaTime * turnAngularVelocity;

                UpdateRotation();
                break;
            default:
                Debug.Log("direction error!");
                break;
        }
    }
    public void UpdateRotation()
    {
        Vector3 localEulerAngles = new Vector3(0f, 0f, m_WheelSteeringAngle);
        this.transform.localEulerAngles = localEulerAngles;
    }

}