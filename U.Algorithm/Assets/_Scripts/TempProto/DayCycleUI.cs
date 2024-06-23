using ALG.TimeCycle;
using TMPro;
using UnityEngine;

namespace ALG.TempProto
{
    public class DayCycleUI : MonoBehaviour
    {
        [SerializeField] private TimeDataSO timeData;
        [SerializeField] private TextMeshProUGUI dayText;
        [SerializeField] private TextMeshProUGUI hoursText;
        [SerializeField] private TextMeshProUGUI minutesText;

        private void Start()
        {
            timeData.OnMinutesUpdate += UpdateMinutes;
            timeData.OnDaysUpdate += UpdateDays;
            timeData.OnHoursUpdate += UpdateHours;

            
            UpdateMinutes(timeData.Minutes);
            UpdateDays(timeData.Day);
            UpdateHours(timeData.Hours);
        }

        private void UpdateDays(int days)
        {
            dayText.text = $"Day: {days}";
        }

        private void UpdateHours(int hours)
        {
            hoursText.text = hours < 10 ? $"Hours: 0{hours}" : $"Hours: {hours}";
        }

        private void UpdateMinutes(int minutes)
        {
            minutesText.text = minutes < 10 ? $"Minutes: 0{minutes}" : $"Minutes: {minutes}";
        }
    }
}