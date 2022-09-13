using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float m_movepower = 5f;
    [SerializeField] float m_jumppower = 1f;
    [SerializeField] float m_maxspeed = 1f;
    [SerializeField] float m_breakCoeff = 0.9f;
    Rigidbody2D m_rb;
    float h;
    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        Vector2 dir = new Vector2(h, 0);
        m_rb.velocity = dir * m_movepower;

    }
    void FixedUpdate()
    {
        
        if (h == 0)
        {
            if (m_rb.velocity.x != 0)
            {
                Vector2 v = m_rb.velocity;
                v.x = v.x * m_breakCoeff;
                m_rb.velocity = v;
            }
        }
        else
        {
            if (h > 0 ? m_rb.velocity.x < m_maxspeed : -1 * m_rb.velocity.x < m_maxspeed)
            {
                m_rb.AddForce(Vector2.right * m_movepower * h, ForceMode2D.Force);
            }
        }
    }
}