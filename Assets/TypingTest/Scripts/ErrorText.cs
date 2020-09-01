using System.Text;
using TMPro;
using UnityEngine;

namespace TypingTest
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class ErrorText : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private TextInput textInput = null;
        [SerializeField] private TextToWrite textToWrite = null;

        public int errors {get; private set;} = 0;

        private TextMeshProUGUI textField;

        private void Start()
        {
            textField = GetComponent<TextMeshProUGUI>();
        }

        public void UpdateText()
        {
            StringBuilder sb = new StringBuilder();
            errors = 0;

            for (int i = 0; i < textInput.text.Length; i++)
            {
                if (textInput.text[i] == textToWrite.text[i])
                {
                    sb.Append(textInput.text[i]);
                }
                else
                {
                    sb.Append($"<#FF0000>{textInput.text[i]}</color>");
                    errors++;
                }
            }

            textField.text = sb.ToString();
        }
    }
}
