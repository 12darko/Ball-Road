using System;
using DG.Tweening;
using Draw;
using Player;
using UnityEngine;

namespace Points
{
    public class FinishPoints : MonoBehaviour
    {
        [SerializeField] private Transform blackHoleTransform;
        private void OnTriggerEnter(Collider other)
        {
            Debug.Log(other.tag);
            if (other.CompareTag("Player"))
            {
                Utils.ResetLine.Reset(other.GetComponentInParent<DrawLines>().Lr);
                Utils.ResetLine.ResetList(other.GetComponentInParent<DrawLines>().WayPoints);
                other.GetComponentInParent<Rotate>().rotateSpeed = 0;
                other.GetComponentInParent<DrawLines>().GetComponentInChildren<PlayerStats>().LocalPointsTxt.gameObject.SetActive(false);
                other.attachedRigidbody.isKinematic = true;
                other.transform.position = blackHoleTransform.transform.position;
                other.transform.DOScale(0, 1f).OnComplete(() =>
                {
                    PopUpManager.Instance.ShowPopUp(true);
                   
                });
            }
        }
    }
}