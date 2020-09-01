using TMPro;
using UnityEngine;

namespace TypingTest
{
    [RequireComponent(typeof(TMP_InputField))]
    public class TextInput : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private ErrorText errorText = null;

        public string text
        {
            get
            {
                return inputField.text;
            }
        }

        public int validChars
        {
            get
            {
                return text.Length - errorText.errors;
            }
        }

        private TMP_InputField inputField;

        private void Start()
        {
            inputField = GetComponent<TMP_InputField>();
        }

        public void CheckScroll()
        {
            Debug.Log(inputField.caretPosition);
        }
    }
}
