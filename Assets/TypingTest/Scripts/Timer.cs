using System.Collections;
using TMPro;
using UnityEngine;

namespace TypingTest
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class Timer : MonoBehaviour
    {
        public int seconds {get; private set;}

        public bool finished {get; set;} = false;

        private TextMeshProUGUI textField;

        private Coroutine countCoroutine;

        private bool countStarted;

        private void Start()
        {
            textField = GetComponent<TextMeshProUGUI>();
        }

        public void TryStartCount()
        {
            if (countStarted) return;
            countStarted = true;
            StartCount();
        }

        private void StartCount()
        {
            if (countCoroutine != null)
            {
                StopCoroutine(countCoroutine);
            }

            countCoroutine = StartCoroutine(Count());
        }

        private void StopCount()
        {
            seconds = 0;

            if (countCoroutine != null)
            {
                StopCoroutine(countCoroutine);
            }
        }

        private IEnumerator Count()
        {
            while (!finished)
            {
                if (finished) break;
                seconds++;
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
