using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
   [SerializeField] private PlayerStats playerStats;

   [SerializeField] private TMP_Text scoreText;

   private void Update()
   {
      scoreText.text = playerStats.localPoints.ToString();
   }
}
