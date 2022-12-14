using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTriggerCheck : MonoBehaviour
{
    /// <summary>
    /// 判定内にプレイヤーがいる、初期false
    /// </summary>
    [HideInInspector] public bool isOn = false;

    private string playerTag = "Player";

    #region//接触判定

    /// <summary>
    /// 接触相手がplayerの時
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == playerTag)
        {
            isOn = true;
        }
    }

    /// <summary>
    /// 接触相手playerが抜けた時
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == playerTag)
        {
            isOn = false;
        }
    }
    #endregion
}
