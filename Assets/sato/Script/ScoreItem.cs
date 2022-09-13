using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreItem : ItemBase2D
{
    [SerializeField, Header("���Z�X�R�A")] int _addScore = 100;

    /// <summary>
    /// �X�R�A�擾���̉��Z
    /// </summary>
    public override void Activate()
    {
        GameManager._score += _addScore;
    }
}