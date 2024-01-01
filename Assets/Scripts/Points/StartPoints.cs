using System;
using UnityEngine;

namespace Points
{
    public class StartPoints : MonoBehaviour
    {
        [SerializeField] private Transform playerSpawnPos;

        private void Start()
        {
            playerSpawnPos.transform.position = transform.position;
        }
    }
}