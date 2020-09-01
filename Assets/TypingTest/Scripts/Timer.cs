using System.Collections;
using TMPro;
using UnityEngine;

namespace TypingTest
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class Timer : MonoBehaviour
    {
        public int elapsedSeconds
        {
            get
            {
                return 60 - seconds;
            }
        }

        private TextMeshProUGUI textField;

        private Coroutine countdown;

        private int seconds;

        private void Start()
        {
            textField = GetComponent<TextMeshProUGUI>();

            StartCountdown();
        }

        private void StartCountdown()
        {
            seconds = 60;

            if (countdown != null)
            {
                StopCoroutine(countdown);
            }

            countdown = StartCoroutine(Countdown());
        }

        private void StopCountdown()
        {
            seconds = 0;

            if (countdown != null)
            {
                StopCoroutine(countdown);
            }
        }

        private IEnumerator Countdown()
        {
            for (int i = 60; i > 0; i--)
            {
                seconds = i;
                UpdateTextField();
                yield return new WaitForSeconds(1);
            }
        }

        private void UpdateTextField()
        {
            textField.text = seconds.ToString();
        }
    }
}
