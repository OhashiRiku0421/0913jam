using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTriggerCheck : MonoBehaviour
{
    /// <summary>
    /// ”»’è“à‚ÉƒvƒŒƒCƒ„[‚ª‚¢‚éA‰Šúfalse
    /// </summary>
    [HideInInspector] public bool isOn = false;

    private string playerTag = "Player";

    #region//ÚG”»’è

    /// <summary>
    /// ÚG‘Šè‚ªplayer‚Ì
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
    /// ÚG‘Šèplayer‚ª”²‚¯‚½
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
