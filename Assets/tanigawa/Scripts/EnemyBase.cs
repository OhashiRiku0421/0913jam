using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    /// <summary> EnemyのRigidbody /// </summary>
    [HideInInspector] public Rigidbody2D _enemyRb;
    /// <summary> EnemyのAnimator /// </summary>
    public Animator _anim;
    /// <summary> Enemyの速度 /// </summary>
    public float _enemySpeed;
    /// <summary> 速度反転フラグ /// </summary>
    [Header("移動方向反転")] public bool _negative;
    /// <summary> 行動可能フラグ /// </summary>
    [HideInInspector] public bool _canMove;
    /// <summary> 消えるまでの時間 /// </summary>
    [Header("消えるまでの時間")] public　float _time = 10f;


    void Start()
    {
        _canMove = true;
    }

    public virtual void EnemyMove() 
    {
        Debug.Log("敵が動いています");
    }

    public virtual void EnemyScale() 
    {
        // キャラクターの大きさ。負数にすると反転される
        Vector2 scale = transform.localScale;
        if (_enemyRb.velocity.x > 1)      // 右方向に動いている
            scale.x = 1;
        else if (_enemyRb.velocity.x < -1) // 左方向に動いている
            scale.x = -1; // 反転
        // 更新
        transform.localScale = scale;
    }
}
