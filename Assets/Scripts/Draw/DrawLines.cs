using System;
using System.Collections.Generic;
using UnityEngine;

namespace Draw
{
    [RequireComponent(typeof(Rigidbody), typeof(LineRenderer))]
    public class DrawLines : MonoBehaviour
    {
        [SerializeField] private float timeForNextRay;
        [SerializeField] private List<GameObject> wayPoints;
        
        private Rigidbody _rigidbody;
        private LineRenderer _lr;
        private float _timer = 0;
        private int _currentWayPoints = 0;
        private int _wayIndex;
        private bool _move;
        private bool _touchStartedOnPlayer;

        #region Props

        public List<GameObject> WayPoints => wayPoints;

        public int CurrentWayPoints
        {
            get => _currentWayPoints;
            set => _currentWayPoints = value;
        }

        public bool Move
        {
            get => _move;
            set => _move = value;
            
            
        }

        public int WayIndex
        {
            get => _wayIndex;
            set => _wayIndex = value;
        }

        public LineRenderer Lr
        {
            get => _lr;
            set => _lr = value;
        }

        public Rigidbody Rigidbody
        {
            get => _rigidbody;
            set => _rigidbody = value;
        }

        #endregion


        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _lr = GetComponent<LineRenderer>();
            _lr.enabled = false;
            _wayIndex = 1;
            _move = false;
            _touchStartedOnPlayer = false;
        }


        private void OnMouseDown()
        {
            _lr.enabled = true;
            _touchStartedOnPlayer = true;
            _lr.positionCount = 1;
            _lr.SetPosition(0, transform.position);
        }


        private void Update()
        {
            _timer += Time.deltaTime;
            if (Input.GetMouseButton(0) && _timer > timeForNextRay && _touchStartedOnPlayer)
            {
                var worldFromMousePos =
                    Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 100));
                var direction = worldFromMousePos - Camera.main.transform.position;
                RaycastHit hit;
                if (Physics.Raycast(Camera.main.transform.position, direction, out hit, 100f))
                {
                    if (hit.collider.CompareTag("Obstacle"))
                    {
                        Utils.ResetLine.Reset(_lr);
                        Utils.ResetLine.ResetList(wayPoints);
                        _lr.enabled = false;
                        wayPoints.Clear();
                        _touchStartedOnPlayer = false;
                         _timer = 0;
                        _wayIndex = 0;
                    }
                    else
                    {
                        Debug.DrawLine(Camera.main.transform.position, direction, Color.red, 1f);
                        var mewWayPoint = new GameObject("WayPoint");
                        mewWayPoint.transform.position = new Vector3(hit.point.x, transform.position.y, hit.point.z);
                        wayPoints.Add(mewWayPoint);
                        _lr.enabled = true;
                        _lr.positionCount = _wayIndex + 1;
                        _lr.SetPosition(_wayIndex, mewWayPoint.transform.position);
                        _timer = 0;
                        _wayIndex++; 
                        
                    }
                }
            }

            if (Input.GetMouseButtonUp(0))
            {
                _touchStartedOnPlayer = false;
                _move = true;
            }
 
        }
    }
}