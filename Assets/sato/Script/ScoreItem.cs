using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreItem : ItemBase2D
{
    [SerializeField, Header("���Z�X�R�A")] int _addScore = 100;
    [SerializeField] GameManager _gameM;
    float time = 0f;
    float killTime = 8f;

    private Rigidbody2D _rb;

    private void Awake()
    {
        _gameM = GameObject.Find("ga").GetComponent<GameManager>();
        _rb = FindObjectOfType<Rigidbody2D>();
    }
    private void Start()
    {
        float vx = Random.Range(-10f, 10f);
        float vy = Random.Range(-10f, 10f);
        Vector3 force = new Vector3(vx, vy, 0);
        _rb.AddForce(force, (ForceMode2D)ForceMode.Impulse);
    }

    private void Update()
    {
        time += Time.deltaTime;

        if (time > killTime)
        {
            Destroy(this.gameObject);
        }
    }

    /// <summary>
    /// �X�R�A�擾���̉��Z
    /// </summary>
    public override void Activate()
    {
        _gameM.ScoreText(_addScore);
    }
}
