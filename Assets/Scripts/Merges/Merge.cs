using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Player;
using UnityEngine;

public class Merge : MonoBehaviour
{
    public void MergeWithItems(PlayerStats localItem, GameObject mergeItem)
    {
        var merge = mergeItem.GetComponent<MergeItem>();

        var size = localItem.transform.parent.localScale.x;
        

        if (localItem.localPoints != 0)
        {
            if (merge.points > localItem.localPoints)
            {
                Debug.Log("Yandın usta");
                ChangeSize(localItem.transform.parent.gameObject, 0f, 1f);
                PopUpManager.Instance.ShowPopUp(false);
            }
            else if (merge.points == localItem.localPoints || merge.points < localItem.localPoints)
            {
                localItem.localPoints += merge.points;
                ChangeSize(localItem.transform.parent.gameObject, size + .05f, 0.5f);
                Destroy(mergeItem);
            }
        }
        else
        {
            localItem.localPoints = merge.points;
            ChangeSize(localItem.transform.parent.gameObject, size + .1f, 0.5f);
            Destroy(mergeItem);
        }
    }

    private void ChangeSize(GameObject item, float size, float duration)
    {
        item.transform.DOScale(size,duration).SetEase(Ease.Linear);
    }
    
   
}