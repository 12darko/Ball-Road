using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Draw;
using Unity.Mathematics;
using UnityEngine;


public class Move : MonoBehaviour
{
    [SerializeField] private DrawLines drawLines;
    [SerializeField] private float rotSpeed;
    [SerializeField] private Transform ballModelHolder;
    [SerializeField] private Transform localBall;
    private void Update()
    {
        if (drawLines.Move)
        {
            ballModelHolder.LookAt(drawLines.WayPoints[drawLines.CurrentWayPoints].transform);
             drawLines.Rigidbody.isKinematic = true;
             transform.DOMove(drawLines.WayPoints[drawLines.CurrentWayPoints].transform.position, 0.01f).OnComplete(() => drawLines.Rigidbody.isKinematic = false)
                .SetEase(Ease.Linear);
             localBall.Rotate(rotSpeed * Time.deltaTime, 0 , 0);

              
            
            if (transform.position == drawLines.WayPoints[drawLines.CurrentWayPoints].transform.position)
                drawLines.CurrentWayPoints++;

            if (drawLines.CurrentWayPoints == drawLines.WayPoints.Count)
            {
                drawLines.Move = false;

                foreach (var item in drawLines.WayPoints)
                     Destroy(item);
                
                drawLines.WayPoints.Clear();
                drawLines.WayIndex = 1;
                drawLines.CurrentWayPoints = 0;
            }
        }
    }
}