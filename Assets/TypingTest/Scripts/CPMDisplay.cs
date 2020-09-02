using TMPro;
using UnityEngine;

namespace TypingTest
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class CPMDisplay : MonoBehaviour
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
            int cpm = Mathf.FloorToInt(textInput.validChars / fractionMinuteElapsed);
            textField.text = $"CPM: {cpm.ToString()}";
        }
    }
}
