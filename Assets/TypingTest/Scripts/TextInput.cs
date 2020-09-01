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

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.LeftShift)) UpdateText();
        }

        public void UpdateText()
        {
            string inputText = InputText();

            for (int i = 0; i < inputText.Length; i++)
            {
                if (inputText[i] != textToWrite.text[i] && !IsMarkedIncorrect(i))
                {
                    MarkIncorrect(i);
                }
            }
        }

        private bool IsMarkedIncorrect(int index)
        {
            int rawIndex = InputTextToRaw(index);
            string rawInputText = inputField.text;

            try
            {
                if (rawInputText.Substring(rawIndex + 1, rawIndex + 1 + incorrectCharEnd.Length) == incorrectCharEnd)
                {
                    if (rawInputText.Substring(rawIndex - 1 - incorrectCharStart.Length, rawIndex - 1) == incorrectCharStart)
                    {
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }

            return false;
        }

        private void MarkIncorrect(int index)
        {
            int rawIndex = InputTextToRaw(index);

            string rawInputText = inputField.text;

            rawInputText = rawInputText.Insert(index + 1, incorrectCharEnd);
            rawInputText = rawInputText.Insert(index, incorrectCharStart);

            inputField.text = rawInputText;
        }

        private int InputTextToRaw(int index)
        {
            int rawIndex = index;
            string rawInputText = inputField.text;

            bool checkingModifiers = true;
            
            while (checkingModifiers)
            {
                if (rawInputText.Substring(0, index).Contains(incorrectCharStart))
                {
                    rawInputText = RemoveString(incorrectCharStart, rawInputText);
                    rawIndex += incorrectCharStart.Length;
                }
                else if (rawInputText.Substring(0, index).Contains(incorrectCharEnd))
                {
                    rawInputText = RemoveString(incorrectCharEnd, rawInputText);
                    rawIndex += incorrectCharEnd.Length;
                }
                else
                {
                    checkingModifiers = false;
                }
            }

            return rawIndex;
        }

        private string RemoveString(string toRemove, string baseString)
        {
            if (!baseString.Contains(toRemove)) return baseString;

            string newString = baseString;

            int removeIndex = newString.IndexOf(toRemove);

            for (int i = 0; i < toRemove.Length; i++)
            {
                newString.Remove(removeIndex);
            }

            return newString;
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
