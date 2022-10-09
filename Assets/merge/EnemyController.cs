using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] int _enemySpeed;
    SpriteRenderer _sprite;
    Rigidbody2D _rb;
    void Start()
    {
        _sprite = GetComponent<SpriteRenderer>();
        _rb = GetComponent<Rigidbody2D>();
        if(_sprite.flipX)
        {
            _rb.AddForce(transform.right * _enemySpeed, ForceMode2D.Impulse);
        }
        else
        {
            _rb.AddForce(-transform.right * _enemySpeed, ForceMode2D.Impulse);
        }
    }

    void Update()
    {
        
    }
}
