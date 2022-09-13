using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTypeWalk : EnemyBase
{
    void Start()
    {
        _enemyRb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        EnemyScale();
        EnemyMove();
    }

    /// <summary> EnemyMove()をオーバーライドする/// </summary>
    public override void EnemyMove()
    {
        if (_negative)
        {
            Vector2 v = new Vector2(-_enemySpeed * Time.deltaTime, 0f);
            gameObject.transform.Translate(v);
        }
        else
        {
            Vector2 v = new Vector2(_enemySpeed * Time.deltaTime, 0f);
            gameObject.transform.Translate(v);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player" && _canMove)
        {
            Destroy(other.gameObject);
            _canMove = false;
        }
    }
}
