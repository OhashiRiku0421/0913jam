using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopGenerater : MonoBehaviour
{
    public GameObject _enemyPrefab; // �G�v���n�u
    [SerializeField] Transform _popTransform; // �o���ʒu
    private Rigidbody2D _rb;
    private float _interval; // ���|�b�v�b��
    [SerializeField] float _time = 0f; // �o�ߎ���

    bool isFirst = false;


    void Start()
    {
        _rb = FindObjectOfType<Rigidbody2D>();
        _interval = 4f;
    }


    void Update()
    {
        _time += Time.deltaTime;

        if (_time >= _interval)
        {

            float vx = Random.Range(-5f, 5f);
            float vy = Random.Range(-5f, 5f);
            Vector3 force = new Vector3(vx, vy, 0);

            if (!isFirst)
            {
                isFirst = true;

                // �C���X�^���X�𐶐�����Unity���ŏo���ʒu��ݒ肷��
                GameObject enemy = Instantiate(_enemyPrefab);
                enemy.transform.position = new Vector3(_popTransform.position.x, _popTransform.position.y, 0);

            }

            _time = 0f; //���Ԃ��Čv��
            isFirst = false;
        }
    }
}
