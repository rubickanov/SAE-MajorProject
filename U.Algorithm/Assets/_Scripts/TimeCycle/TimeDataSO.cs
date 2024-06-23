using System;
using UnityEngine;

namespace ALG.TimeCycle
{
    [CreateAssetMenu(fileName = "TimeDataSO", menuName = "TimeCycle/TimeDataSO")]
    public class TimeDataSO : ScriptableObject
    {
        public int day;
        public int hours;
        public int minutes;
        public int seconds;

        public int Day => day;
        public int Hours => hours;
        public int Minutes => minutes;
        public float Seconds => seconds;

        public Action<int> OnSecondsUpdate;
        public Action<int> OnMinutesUpdate;
        public Action<int> OnHoursUpdate;
        public Action<int> OnDaysUpdate;

        public void TickSecond()
        {
            seconds++;
            if (seconds >= 60)
            {
                seconds = 0;
                TickMinute();
            }

            OnSecondsUpdate?.Invoke(seconds);
        }

        public void TickMinute()
        {
            minutes++;
            if (minutes >= 60)
            {
                minutes = 0;
                TickHour();
            }

            OnMinutesUpdate?.Invoke(minutes);
        }

        public void TickHour()
        {
            hours++;
            if (hours >= 24)
            {
                hours = 0;
                TickDay();
            }

            OnHoursUpdate?.Invoke(hours);
        }

        public void TickDay()
        {
            day++;
            OnDaysUpdate?.Invoke(day);
        }

        public void SetTime(int minutes, int hours, int day)
        {
            this.minutes = minutes;
            this.hours = hours;
            this.day = day;
        }
    }
}