using System;
using System.Collections;
using UnityEngine;
using TMPro;

namespace ProjectCustomer.NotificationSystem
{
    public class Notification : MonoBehaviour
    {
        public TextMeshProUGUI text;
        public RectTransform rectTransform;
        public bool hasHitBottom = false;
        public bool goingUp = false;
        public bool coroutineStopped = false;
        public Canvas canvas;

        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
        }

        private void Update()
        {
            if (!hasHitBottom)
            {
                var rectTransformAnchoredPosition = rectTransform.anchoredPosition;
                rectTransformAnchoredPosition.y -= 1f;

                rectTransformAnchoredPosition.y = Mathf.Clamp(rectTransformAnchoredPosition.y, -60, 60);

                rectTransform.anchoredPosition = rectTransformAnchoredPosition;   
            } 
            
            if (rectTransform.anchoredPosition.y == -60 && !hasHitBottom)
            {
                hasHitBottom = true;
                StartCoroutine(GoUp());
            }

            if (goingUp)
            {
                if (!coroutineStopped)
                {
                    coroutineStopped = true;
                    StopCoroutine(GoUp());
                }
                var rectTransformAnchoredPosition = rectTransform.anchoredPosition;
                rectTransformAnchoredPosition.y += 1f;

                rectTransformAnchoredPosition.y = Mathf.Clamp(rectTransformAnchoredPosition.y, -60, 60);

                rectTransform.anchoredPosition = rectTransformAnchoredPosition;

                if (rectTransform.anchoredPosition.y == 60)
                {
                    Destroy(gameObject);
                    Destroy(canvas.gameObject);
                }
            }
            
        }
        IEnumerator GoUp()
        {
            Debug.Log("Starting wait for seconds");
            yield return new WaitForSeconds(2f);
            goingUp = true;
        }
    }
}