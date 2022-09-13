using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopGenerater : MonoBehaviour
{
    public GameObject _enemyPrefab; // 敵プレハブ
    [SerializeField] Transform _popTransform; // 出現位置
    private Rigidbody2D _rb;
    private float _interval; // リポップ秒数
    [SerializeField] float _time = 0f; // 経過時間

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

                // インスタンスを生成してUnity側で出現位置を設定する
                GameObject enemy = Instantiate(_enemyPrefab);
                enemy.transform.position = new Vector3(_popTransform.position.x, _popTransform.position.y, 0);

            }

            _time = 0f; //時間を再計測
            isFirst = false;
        }
    }
}
