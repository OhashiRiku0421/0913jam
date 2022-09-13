using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemBase2D : MonoBehaviour
{
    [Header("�v���C���[�̔���")] public PlayerTriggerCheck playerCheck;
    [Header("�擾����SE")] public AudioClip getSE;

    public abstract void Activate();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {

            if (getSE)
            {
                AudioSource.PlayClipAtPoint(getSE, Camera.main.transform.position);
            }

            Activate();
            Destroy(this.gameObject);
        }
    }
}
