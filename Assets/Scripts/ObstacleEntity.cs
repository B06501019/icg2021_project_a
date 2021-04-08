using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleEntity : MonoBehaviour
{
    SpriteRenderer m_TargerRenderer;
    // Start is called before the first frame update
    void Start()
    {
        m_TargerRenderer = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D collision)
    {
        m_TargerRenderer.color = Color.red;
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        m_TargerRenderer.color = Color.white;
    }
}
