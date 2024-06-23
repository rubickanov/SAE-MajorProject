using System;
using UnityEngine;

namespace ALG.TimeCycle
{
    public class DayCycle : MonoBehaviour
    {
        [SerializeField]
        private bool freezeTime = false;
        [SerializeField]
        private int secondsInMinute = 5;
        [SerializeField, Range(1, 100)]
        private float timeMultiplier = 1.0f;
        [SerializeField]
        private TimeDataSO startTime;

        [SerializeField] private TimeDataSO timeData;
        private float timer;

        private void Start()
        {
            timeData.SetTime(startTime.Minutes, startTime.Hours, startTime.Day);
        }

        private void Update()
        {
            if (freezeTime) return;

            timer += Time.deltaTime * timeMultiplier;
            if (timer > secondsInMinute)
            {
                timeData.TickMinute();
                timer = 0;
            }
        }
    }
}