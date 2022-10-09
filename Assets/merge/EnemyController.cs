using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] int _enemySpeed;
    [SerializeField] int _badScore = 200;
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
        StartCoroutine(DestroyInterval());
    }
    IEnumerator DestroyInterval()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }

    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GameManager._score -= _badScore;
        }
    }
}
