using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    /// <summary> �X�|�i�[��Transform /// </summary>
    //[SerializeField] Transform _Spawner;
    /// <summary> Enemy�̃v���n�u�����郊�X�g /// </summary>
    [SerializeField] List<GameObject> _enemyPrefab;
    /// <summary> �X�|�[���Ԋu�̂��߂̕ϐ� /// </summary>
    [SerializeField][Header("�X�|�[���Ԋu")] float _spawninterval = 5f;
    /// <summary> �o�ߎ��Ԃ̂��߂̕ϐ� /// </summary>
    float _passedtime = 0;

    void Update()
    {
        //�X�|�[���Ԋu���Ƃ�Enemy�I�u�W�F�N�g���X�|�[������
        _passedtime += Time.deltaTime;
        if (_passedtime > _spawninterval)
        {
            Spawn();
            _passedtime = 0;
        }
    }
    /// <summary>Enemy�I�u�W�F�N�g���X�|�[�������鏈�� /// </summary>
    void Spawn()
    {
        int enemyindex = Random.Range(0, _enemyPrefab.Count - 1);//��������
        GameObject instance = Instantiate(_enemyPrefab[enemyindex]);
        instance.transform.position = transform.position;
    }
}
