using System;
using UnityEngine;

namespace ALG.TimeCycle
{
    [Serializable]
    public struct TimeData
    {
        public int Day;
        public int Hours;
        public int Minutes;
        public float Seconds;
    }

    public class DayCycle : MonoBehaviour
    {
        [SerializeField]
        private bool freezeTime = false;
        [SerializeField]
        private int secondsInMunite = 5;
        [SerializeField, Range(1, 100)]
        private float timeMultiplier = 1.0f;
        [SerializeField]
        private TimeData startTime;

        private TimeData timeData;

        public Action<int> OnMinutesUpdate;
        public Action<int> OnHoursUpdate;
        public Action<int> OnDaysUpdate;

        private void Update()
        {
            TickSecond();
        }

        private void TickSecond()
        {
            if (freezeTime) return;
            timeData.Seconds += Time.deltaTime * timeMultiplier;
            if (timeData.Seconds >= secondsInMunite)
            {
                timeData.Seconds = 0;
                TickMinute();
            }
        }

        private void TickMinute()
        {
            timeData.Minutes++;
            if (timeData.Minutes >= 60)
            {
                timeData.Minutes = 0;
                TickHour();
            }

            OnMinutesUpdate?.Invoke(timeData.Minutes);
        }

        private void TickHour()
        {
            timeData.Hours++;
            if (timeData.Hours >= 24)
            {
                timeData.Hours = 0;
                TickDay();
            }

            OnHoursUpdate?.Invoke(timeData.Hours);
        }

        private void TickDay()
        {
            timeData.Day++;
            OnDaysUpdate?.Invoke(timeData.Day);
        }

        public TimeData GetTimeData()
        {
            return timeData;
        }
    }
}