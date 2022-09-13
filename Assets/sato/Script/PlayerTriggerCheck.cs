using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTriggerCheck : MonoBehaviour
{
    /// <summary>
    /// ������Ƀv���C���[������A����false
    /// </summary>
    [HideInInspector] public bool isOn = false;

    private string playerTag = "Player";

    #region//�ڐG����

    /// <summary>
    /// �ڐG���肪player�̎�
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
    /// �ڐG����player����������
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
