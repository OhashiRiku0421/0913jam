using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    /// <summary> スポナーのTransform /// </summary>
    //[SerializeField] Transform _Spawner;
    /// <summary> Enemyのプレハブが入るリスト /// </summary>
    [SerializeField] List<GameObject> _enemyPrefab;
    /// <summary> スポーン間隔のための変数 /// </summary>
    [SerializeField][Header("スポーン間隔")] float _spawninterval = 5f;
    /// <summary> 経過時間のための変数 /// </summary>
    float _passedtime = 0;

    void Update()
    {
        //スポーン間隔ごとにEnemyオブジェクトをスポーンする
        _passedtime += Time.deltaTime;
        if (_passedtime > _spawninterval)
        {
            Spawn();
            _passedtime = 0;
        }
    }
    /// <summary>Enemyオブジェクトをスポーンさせる処理 /// </summary>
    void Spawn()
    {
        int enemyindex = Random.Range(0, _enemyPrefab.Count - 1);//乱数生成
        GameObject instance = Instantiate(_enemyPrefab[enemyindex]);
        instance.transform.position = transform.position;
    }
}
