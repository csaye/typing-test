using System.Collections;
using TMPro;
using UnityEngine;

namespace TypingTest
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class Timer : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private TextInput textInput = null;

        public int seconds {get; private set;}

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
            while (!textInput.finished)
            {
                if (textInput.finished) break;
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
