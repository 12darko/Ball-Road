using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MergeItem : MonoBehaviour
{
    [SerializeField] private TMP_Text pointText;
    public int points;

    private void Start()
    {
        pointText.text = points.ToString();
    }
}
