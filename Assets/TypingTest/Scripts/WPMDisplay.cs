using TMPro;
using UnityEngine;

namespace TypingTest
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class WPMDisplay : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Timer timer = null;
        [SerializeField] private TextInput textInput = null;

        private TextMeshProUGUI textField;

        private void Start()
        {
            textField = GetComponent<TextMeshProUGUI>();
        }

        public void UpdateDisplay()
        {
            float fractionMinuteElapsed = (timer.seconds / 60.0f);
            if (fractionMinuteElapsed == 0) fractionMinuteElapsed = 1;
            int wpm = Mathf.FloorToInt((textInput.validChars / fractionMinuteElapsed) / 5);
            textField.text = $"WPM: {wpm.ToString()}";
        }
    }
}
