using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTypeFly: EnemyBase
{
    /// <summary> �ړ��^�C�v�P�̃t���O /// </summary>
    [SerializeField][Header("���s�ړ�")] bool _moveType1;
    /// <summary> �ړ��^�C�v2�̃t���O /// </summary>
    [SerializeField] [Header("�����ړ�")] bool _moveType2;
    /// <summary> �ړ��^�C�v3�̃t���O /// </summary>
    [SerializeField][Header("�E�F�[�u")] bool _moveType3;
    /// <summary> �ړ��^�C�v4�̃t���O /// </summary>
    [SerializeField][Header("�Ǐ]")] bool _moveType4;
    /// <summary> sin�J�[�u�̑傫�� /// </summary>
    [SerializeField] [Header("�傫��")] float _pow = 0.05f;
    /// <summary> sin�J�[�u�̎��� /// </summary>
    [SerializeField][Header("����")] float _T = 1.0f;
    /// <summary> player�I�u�W�F�N�g���󂯎�� /// </summary>
    GameObject _playerObject; 
    /// <summary> �v���C���[�̍��W���Ȃǂ��󂯎�� /// </summary>
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

    /// <summary> EnemyMove()���I�[�o�[���C�h����/// </summary>
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
            //sin�J�[�u�ňړ�������
            float f = 1.0f / _T; //�U��
            float sin = Mathf.Sin(2 * Mathf.PI * f * Time.time);

            Vector2 v = new Vector2(_enemySpeed * Time.deltaTime, _pow * sin);
            transform.Translate(v);
        }

        else if (_moveType4) 
        {
            //�Ǐ]
            Vector2 e_pos = transform.position;  // ����(�G�L�����N�^)�̐��E���W
            Vector2 p_pos = _player_T.position;  // �v���C���[�̐��E���W

            // �v���C���[�̕����ɓ����x�N�g�� * ���x
            Vector2 force = (p_pos - e_pos) * _enemySpeed;
            // ���킶��ǐ�
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
