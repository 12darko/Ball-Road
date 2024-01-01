using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;

public class DrawLine : MonoBehaviour
{
    [SerializeField] private float yOffset;
    [SerializeField] private Camera localCam = null;
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private float minDistance = 0.05f;
    [SerializeField] private List<Vector3> linePoints = new List<Vector3>();

    private Rigidbody _rb;
    private Vector3 _mousePos;
    private Vector3 _pos;
    private Vector3 _previousPosition;
    private float _distance = 0;
    private bool _touchStartedOnPlayer;

    #region Props

    
    [FormerlySerializedAs("_isDrawEnded")] [SerializeField]
    private bool isDrawEnded = false;

    public bool IsDrawEnded => isDrawEnded;

    public List<Vector3> LinePoints
    {
        get => linePoints;
        set => linePoints = value;
    }


    #endregion

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _touchStartedOnPlayer = false;
    }

    private void OnMouseDown()
    {
         _touchStartedOnPlayer = true;
     }


    private void Update()
    {
        if (Input.GetMouseButton(0) && _touchStartedOnPlayer)
        {
            var worldFromMousePos =
                localCam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, localCam.nearClipPlane));
            var direction = worldFromMousePos - localCam.transform.position;
            RaycastHit hit;

            isDrawEnded = false;
            if (Physics.Raycast(localCam.transform.position, direction, out hit, 100f))
            {
                Debug.DrawLine(localCam.transform.position, direction, Color.cyan, hit.point.z);
                if (hit.collider.CompareTag("Obstacle"))
                {
                    Utils.ResetLine.Reset(lineRenderer);
                    //Utils.ResetLine.ResetList(linePoints);
                    DOTween.KillAll();
                }
                else
                {
                    _pos = new Vector3(hit.point.x, hit.point.y + yOffset, hit.point.z);
                    _distance = Vector3.Distance(_pos, _previousPosition);
                    if (_distance >= minDistance)
                    {
                        _previousPosition = _pos;
                        linePoints.Add(_pos);
                        lineRenderer.positionCount = linePoints.Count;
                        lineRenderer.SetPositions(linePoints.ToArray());
                    }
                }
            }
        }
        else
        {
            isDrawEnded = true;
        }

        
        

        /*
         
          if (Input.GetMouseButton(0))
        {
            var worldFromMousePos =
                localCam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, localCam.nearClipPlane));
            var direction = worldFromMousePos - localCam.transform.position;
            RaycastHit hit;

            isDrawEnded = false;
            if (Physics.Raycast(localCam.transform.position, direction, out hit, 100f))
            {
                Debug.DrawLine(localCam.transform.position, direction, Color.cyan, hit.point.z);
                if (hit.collider.CompareTag("Obstacle"))
                {
                    Utils.ResetLine.Reset(lineRenderer);
                    Utils.ResetLine.ResetList(linePoints);
                    DOTween.KillAll();
                }
                else
                {
                    _pos = new Vector3(hit.point.x, hit.point.y, hit.point.z);
                    _distance = Vector3.Distance(_pos, _previousPosition);
                    if (_distance >= minDistance)
                    {
                        _previousPosition = _pos;
                        linePoints.Add(_pos);
                        lineRenderer.positionCount = linePoints.Count;
                        lineRenderer.SetPositions(linePoints.ToArray());
                    }
                }
            }
        }
        else
        {
            isDrawEnded = true;
        }

         
         
         
         Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
          if (Physics.Raycast(ray, out RaycastHit hit, 55f))
          {
              if (hit.collider.CompareTag("Obstacle"))
              {
                  Debug.Log("Obstacle a değdin");
                  Utils.ResetLine.Reset(lineRenderer);
                  Utils.ResetLine.ResetList(linePoints);
                  DOTween.KillAll();
              } else
              {
                  if (Input.GetMouseButtonDown(0))
                  {
                      isDrawEnded = false;
  
                      _mousePos = Input.mousePosition;
                      _mousePos.z = 10f;
                       _pos = localCam.ScreenToWorldPoint(_mousePos);
                       _previousPosition = _pos;
                      linePoints.Add(_pos);
                  }
                  else
                  {
                      isDrawEnded = true;
                      if (Input.GetMouseButton(0))
                      {
                          isDrawEnded = false;
                          
                          _mousePos = Input.mousePosition;
                          _mousePos.z = 10f;
                           _pos = localCam.ScreenToWorldPoint(_mousePos);
                           _distance = Vector3.Distance(_pos, _previousPosition);
                          if (_distance >= minDistance)
                          {
                              _previousPosition = _pos;
                              linePoints.Add(_pos);
                              lineRenderer.positionCount = linePoints.Count;
                              lineRenderer.SetPositions(linePoints.ToArray());
                             
                          }
                      }
                      else
                      {
                          isDrawEnded = true;
                      }
                  }
              }
          }*/
    }


    private Vector3 GetMousePosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        return ray.origin + ray.direction * 15;
    }
}