using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float m_movepower = 5f;
    [SerializeField] float m_jumppower = 1000f;
    [SerializeField] float m_maxspeed = 1f;
    [SerializeField] float m_breakCoeff = 0.9f;
    Vector2 dir = new Vector2(0, 0);
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
        dir = new Vector2(h, 0);
        Move();
        jamp();
    }
    void Move()
    {
        Vector2 _s = dir.normalized * m_movepower;
        _s.y = m_rb.velocity.y;
        m_rb.velocity = _s;
    }
    void FixedUpdate()
    {
        
        
        //if (h == 0)
        //{
        //    if (m_rb.velocity.x != 0)
        //    {
        //        _anim.SetBool("isRun", false);
        //        Vector2 v = m_rb.velocity;
        //        v.x = v.x * m_breakCoeff;
        //        m_rb.velocity = v;
        //    }
        //}
        //else
        //{
        //    if (h > 0 ? m_rb.velocity.x < m_maxspeed : -1 * m_rb.velocity.x < m_maxspeed)
        //    {
        //        _anim.SetBool("isRun", true);
        //        m_rb.AddForce(Vector2.right * m_movepower * h, ForceMode2D.Force);
        //        //m_rb.velocity = new Vector2(m_movepower, m_rb.velocity.y);
        //    }
        //}
    }

    void jamp()
    {
        if (Input.GetButtonDown("Jump") && _jumpcount < 2)
        {
            m_rb.velocity = Vector2.zero;
            m_rb.AddForce(transform.up * m_jumppower, ForceMode2D.Impulse);
            _jumpcount++;
            Debug.Log(_jumpcount);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            _jumpcount = 0;
        }
    }
}
