using TMPro;
using UnityEngine;

namespace TypingTest
{
    [RequireComponent(typeof(TMP_InputField))]
    public class TextInput : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private TextToWrite textToWrite = null;

        private const string incorrectCharStart = "<#FF0000>";
        private const string incorrectCharEnd = "</color>";

        private TMP_InputField inputField;

        private void Start()
        {
            inputField = GetComponent<TMP_InputField>();
        }

        public void UpdateText()
        {
            string inputText = InputText();

            for (int i = 0; i < inputText.Length; i++)
            {
                if (inputText[i] != textToWrite.text[i])
                {
                    MarkIncorrect(i);
                }
            }
        }

        private void MarkIncorrect(int index)
        {
            string newInputText = inputField.text;

            newInputText += incorrectCharEnd;

            inputField.text = newInputText;
        }

        private string InputText()
        {
            string inputText = inputField.text;
            
            inputText = inputText.Replace(incorrectCharStart, "");
            inputText = inputText.Replace(incorrectCharEnd, "");
            
            return inputText;
        }

        public int CharsTyped()
        {
            return InputText().Length;
        }
    }
}
