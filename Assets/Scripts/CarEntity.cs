using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarEntity : MonoBehaviour
{
    [SerializeField] SpriteRenderer[] m_Renderders = new SpriteRenderer[5];
    public GameObject wheelFrontRight;
    public GameObject wheelFrontLeft;
    public GameObject wheelBackRight;
    public GameObject wheelBackLeft;

    public float m_CarLength = 1;
    float m_FrontWheelAngle = 0;
    string m_CarName;
    const float WHEEL_ANGLE_LIMIT = 40f;
    public float turnAngularVelocity = 50f;

    public float CarLength { get { return m_CarLength; } }
    public float FrontWheelAngle { get { return m_FrontWheelAngle; } }

    float m_Velocity;

    public float Velocity { get { return m_Velocity; } }

    public float acceleration = 3f;
    public float deceleration = 10f;
    public float maxVelocity = 60f;

    float m_DeltaMovement;

    public float DeltaMovement { get { return m_DeltaMovement; } }

    public CarEntity(string carName, float carLength = 1, float frontWheelAngle = 0)
    {
        m_CarName = carName;
        m_CarLength = carLength;
        m_FrontWheelAngle = frontWheelAngle;
    }
    public void SpeedUp()
    {
        m_Velocity = Mathf.Min(maxVelocity, m_Velocity + Time.deltaTime * acceleration);

        m_DeltaMovement = m_Velocity * Time.fixedDeltaTime;
    }
    public void Break()
    {
        m_Velocity = Mathf.Max(0, m_Velocity - Time.deltaTime * deceleration);

        m_DeltaMovement = m_Velocity * Time.fixedDeltaTime;
    }
    public void Back()
    {
        m_Velocity = Mathf.Max(-2, m_Velocity - Time.deltaTime * deceleration);

        m_DeltaMovement = m_Velocity * Time.fixedDeltaTime;
    }
    public void Turn(string direction)
    {
        switch (direction)
        {
            case "left":
                m_FrontWheelAngle = Mathf.Clamp(
                m_FrontWheelAngle + Time.fixedDeltaTime * turnAngularVelocity,
                -WHEEL_ANGLE_LIMIT,
                WHEEL_ANGLE_LIMIT);

                UpdateWheels();
                break;
            case "right":
                m_FrontWheelAngle = Mathf.Clamp(
                m_FrontWheelAngle - Time.fixedDeltaTime * turnAngularVelocity,
                -WHEEL_ANGLE_LIMIT,
                WHEEL_ANGLE_LIMIT);

                // Clamp is a function that controls the maximum and minimum.

                UpdateWheels();
                break;
            default:
                Debug.Log("direction error!");
                break;
        }
    }
    public void UpdateWheels()
    {
        // Update wheels by m_FrontWheelAngle
        Vector3 localEulerAngles = new Vector3(0f, 0f, m_FrontWheelAngle);
        wheelFrontLeft.transform.localEulerAngles = localEulerAngles;
        wheelFrontRight.transform.localEulerAngles = localEulerAngles;
    }

    void ResetColor()
    {
        ChangeColor(Color.white);     
    }
    void ChangeColor (Color color)
    {
        foreach (SpriteRenderer r in m_Renderders)
        {
            r.color = color;
        }
    }
    void  OnCollisionEnter2D(Collision2D collision)
    {
        ChangeColor(Color.red);
    }
    void Stop()
    {
        m_Velocity = 0;
    }
    void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("crash!");
        Stop();
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        ResetColor();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        CheckPoint checkPoint = other.gameObject.GetComponent<CheckPoint>();
        if (checkPoint != null)
        {
            ChangeColor(Color.green);
            this.Invoke("ResetColor", 0.1f);
        }
    }
}
 