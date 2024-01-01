using TMPro;
using UnityEngine;

namespace Player
{
    public class PlayerStats : MonoBehaviour
    {
        [SerializeField] private TMP_Text localPointsTxt;
        public int localPoints;

        public TMP_Text LocalPointsTxt
        {
            get => localPointsTxt;
            set => localPointsTxt = value;
        }

        private void Update()
        {
            localPointsTxt.text = localPoints.ToString();
            Debug.Log(localPoints+ "Eklenen Puan");
        }
    }
}