using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Spike : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            collision.collider.transform.DOScale(0, 0.5f).OnComplete(() =>   PopUpManager.Instance.ShowPopUp(false));
          
        }
    }
}
