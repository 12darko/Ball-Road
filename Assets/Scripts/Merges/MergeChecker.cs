using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

public class MergeChecker : MonoBehaviour
{
    [SerializeField] private Merge merge;
    
    private void OnCollisionEnter(Collision collision)
    {
        var coll = collision.collider.GetComponentInParent<MergeItem>();
        
        if (coll)
        {
             merge.MergeWithItems(transform.GetComponentInChildren<PlayerStats>(), coll.gameObject);
        }
    }
}
