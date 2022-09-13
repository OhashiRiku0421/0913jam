using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UniRx;

public class ScoreManager : MonoBehaviour
{
    //[Header("ÉXÉRÉA")] public static int _score = 0;
    public static int _sumScore = 0;
    Text _scoreText;
    private readonly ReactiveProperty<int> _score = new IntReactiveProperty();
    void Start()
    {
    }

    void Update()
    {
        
    }
}
