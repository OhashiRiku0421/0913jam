using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    /// <summary> Enemy��Rigidbody /// </summary>
    [HideInInspector] public Rigidbody2D _enemyRb;
    /// <summary> Enemy��Animator /// </summary>
    public Animator _anim;
    /// <summary> Enemy�̑��x /// </summary>
    public float _enemySpeed;
    /// <summary> ���x���]�t���O /// </summary>
    [Header("�ړ��������]")] public bool _negative;
    /// <summary> �s���\�t���O /// </summary>
    [HideInInspector] public bool _canMove;
    /// <summary> ������܂ł̎��� /// </summary>
    [Header("������܂ł̎���")] public�@float _time = 10f;


    void Start()
    {
        _canMove = true;
    }

    public virtual void EnemyMove() 
    {
        Debug.Log("�G�������Ă��܂�");
    }

    public virtual void EnemyScale() 
    {
        // �L�����N�^�[�̑傫���B�����ɂ���Ɣ��]�����
        Vector2 scale = transform.localScale;
        if (_enemyRb.velocity.x > 1)      // �E�����ɓ����Ă���
            scale.x = 1;
        else if (_enemyRb.velocity.x < -1) // �������ɓ����Ă���
            scale.x = -1; // ���]
        // �X�V
        transform.localScale = scale;
    }
}
