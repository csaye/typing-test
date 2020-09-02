using TMPro;
using UnityEngine;

namespace TypingTest
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class PBDisplay : MonoBehaviour
    {
        [Header("Attributes")]
        [SerializeField] private string scorePlayerPref = null;

        private TextMeshProUGUI textField;

        private void Start()
        {
            textField = GetComponent<TextMeshProUGUI>();

            textField.text = $"PB: {PlayerPrefs.GetInt(scorePlayerPref, 0)}";
        }

        public void UpdateDisplay(int score, bool higherBetter)
        {
            if (higherBetter && PlayerPrefs.GetInt(scorePlayerPref, 0) < score)
            {
                PlayerPrefs.SetInt(scorePlayerPref, score);
            }
            if (!higherBetter && PlayerPrefs.GetInt(scorePlayerPref, int.MaxValue) > score)
            {
                PlayerPrefs.SetInt(scorePlayerPref, score);
            }

            textField.text = $"PB: {PlayerPrefs.GetInt(scorePlayerPref, 0)}";
        }
    }
}
