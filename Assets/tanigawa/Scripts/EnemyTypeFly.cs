using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTypeFly: EnemyBase
{
    /// <summary> 移動タイプ１のフラグ /// </summary>
    [SerializeField][Header("平行移動")] bool _moveType1;
    /// <summary> 移動タイプ2のフラグ /// </summary>
    [SerializeField] [Header("垂直移動")] bool _moveType2;
    /// <summary> 移動タイプ3のフラグ /// </summary>
    [SerializeField][Header("ウェーブ")] bool _moveType3;
    /// <summary> 移動タイプ4のフラグ /// </summary>
    [SerializeField][Header("追従")] bool _moveType4;
    /// <summary> sinカーブの大きさ /// </summary>
    [SerializeField] [Header("大きさ")] float _pow = 0.05f;
    /// <summary> sinカーブの周期 /// </summary>
    [SerializeField][Header("周期")] float _T = 1.0f;
    /// <summary> playerオブジェクトを受け取る /// </summary>
    GameObject _playerObject; 
    /// <summary> プレイヤーの座標情報などを受け取る /// </summary>
    Transform _player_T;

    // Start is called before the first frame update
    void Start()
    {
        _enemyRb = GetComponent<Rigidbody2D>();
        _enemyRb.gravityScale = 0;

        _playerObject = GameObject.Find("Player");
        _player_T = _playerObject.transform;
    }

    void Update()
    {
        EnemyScale();
        EnemyMove();
    }

    /// <summary> EnemyMove()をオーバーライドする/// </summary>
    public override void EnemyMove()
    {
        if (_moveType1)
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

        else if (_moveType2)
        {
            if (_negative)
            {
                Vector2 v = new Vector2(0f, -_enemySpeed * Time.deltaTime);
                gameObject.transform.Translate(v);
            }
            else
            {
                Vector2 v = new Vector2(0f ,_enemySpeed * Time.deltaTime);
                gameObject.transform.Translate(v);
            }
        }

        else if (_moveType3)
        {
            //sinカーブで移動させる
            float f = 1.0f / _T; //振幅
            float sin = Mathf.Sin(2 * Mathf.PI * f * Time.time);

            Vector2 v = new Vector2(_enemySpeed * Time.deltaTime, _pow * sin);
            transform.Translate(v);
        }

        else if (_moveType4) 
        {
            //追従
            Vector2 e_pos = transform.position;  // 自分(敵キャラクタ)の世界座標
            Vector2 p_pos = _player_T.position;  // プレイヤーの世界座標

            // プレイヤーの方向に動くベクトル * 速度
            Vector2 force = (p_pos - e_pos) * _enemySpeed;
            // じわじわ追跡
            _enemyRb.AddForce(force, ForceMode2D.Force);
        }      
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && _canMove)
        {
            Destroy(other.gameObject);
            _canMove = false;
        }
    }
}
