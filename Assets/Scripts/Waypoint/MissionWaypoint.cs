using System;
using UnityEngine;
using UnityEngine.UI;

namespace ProjectCustomer.Waypoint
{
    public class MissionWaypoint : MonoBehaviour
    {
        #region Fields

        public RawImage marker;
        public Transform target;

        #endregion

        #region Update

        private void Update()
        {
            var minX = marker.GetPixelAdjustedRect().width / 2;
            var maxX = Screen.width - minX;

            var minY = marker.GetPixelAdjustedRect().height / 2;
            var maxY = Screen.height - minY;
            
            var position = Camera.main.WorldToScreenPoint(target.position);

            if (Vector3.Dot((target.position - transform.position), transform.forward) < 0)
            {
                position.x = position.x < Screen.width / 2 ? maxX : minX;
            }

            position.x = Mathf.Clamp(position.x, minX, maxX);
            position.y = Mathf.Clamp(position.y, minY, maxY);

            marker.transform.position = position;
        }

        #endregion
    }
}
