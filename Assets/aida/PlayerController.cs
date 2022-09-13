using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float m_movepower = 5f;
    [SerializeField] float m_jumppower = 1000f;
    [SerializeField] float m_maxspeed = 1f;
    [SerializeField] float m_breakCoeff = 0.9f;
    Rigidbody2D m_rb;
    float h;
    float v;
    [SerializeField] int _jumpcount = 0;

    Animator _anim;
    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
        m_rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        Vector2 dir = new Vector2(h, 0);
        m_rb.velocity = dir * m_movepower;
        if(Input.GetButtonDown("Jump") && _jumpcount < 2)
        {
            _anim.SetBool("isJump", true);
            _jumpcount++;
            m_rb.AddForce(Vector2.up * m_jumppower * 100);
            Debug.Log(_jumpcount);
        }
    }
    void FixedUpdate()
    {
        
        if (h == 0)
        {
            if (m_rb.velocity.x != 0)
            {
                _anim.SetBool("isRun", false);
                Vector2 v = m_rb.velocity;
                v.x = v.x * m_breakCoeff;
                m_rb.velocity = v;
            }
        }
        else
        {
            if (h > 0 ? m_rb.velocity.x < m_maxspeed : -1 * m_rb.velocity.x < m_maxspeed)
            {
                _anim.SetBool("isRun", true);
                m_rb.AddForce(Vector2.right * m_movepower * h, ForceMode2D.Force);
                //m_rb.velocity = new Vector2(m_movepower, m_rb.velocity.y);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            _anim.SetBool("isJump", false);
            _jumpcount = 0;
        }
    }
}
