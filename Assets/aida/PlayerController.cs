using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float _movepower = 5f;
    [SerializeField] float _jumppower =0;
    Vector2 _dir = new Vector2(0, 0);
    int _jumpCount = 0;
    Rigidbody2D _rb;
    //Animator _anim;

    void Start()
    {
        //_anim = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Move();
        jamp();
    }
    void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        _dir = new Vector2(h, 0);
        Vector2 _s = _dir.normalized * _movepower;
        _s.y = _rb.velocity.y;
        _rb.velocity = _s;
    }
    void jamp()
    {
        if (Input.GetButtonDown("Jump") && _jumpCount < 2)
        {
            _rb.velocity = Vector2.zero;
            _rb.AddForce(transform.up * _jumppower, ForceMode2D.Impulse);
            _jumpCount++;
            Debug.Log(_jumpCount);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            _jumpCount = 0;
        }
    }
}
