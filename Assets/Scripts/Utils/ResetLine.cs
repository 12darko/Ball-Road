using System.Collections.Generic;
using UnityEngine;

namespace Utils
{
    public static class ResetLine
    {
        public static void Reset(LineRenderer lr)
        {
            lr.positionCount = 0;
        }
        public static void ResetList(List<GameObject>  list)
        {
            foreach (var item in list)
                Object.Destroy(item);
                
            list.Clear();
        }
    }
}