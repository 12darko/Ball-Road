using System;
using UnityEngine;

namespace Player
{
    public class Rotate : MonoBehaviour
    {
        [SerializeField] public float rotateSpeed;
        private void Update()
        {
            //transform.Rotate(0, rotateSpeed * Time.deltaTime, rotateSpeed * Time.deltaTime);
        }
    }
}