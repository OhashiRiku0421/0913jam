using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopGenerater : MonoBehaviour
{
    public GameObject _enemyPrefab; // 敵プレハブ
    [SerializeField] Transform _popTransform; // 出現位置
    private float _interval; // リポップ秒数
    float _time = 0f; // 経過時間

    bool isFirst = false;


    void Start()
    {
        _interval = 4f;
    }


    void Update()
    {
        _time += Time.deltaTime;

        if (_time >= _interval)
        {
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
