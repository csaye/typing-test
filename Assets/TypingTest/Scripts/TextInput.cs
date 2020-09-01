using TMPro;
using UnityEngine;

namespace TypingTest
{
    [RequireComponent(typeof(TMP_InputField))]
    public class TextInput : MonoBehaviour
    {
        private TMP_InputField inputField;

        private void Start()
        {
            inputField = GetComponent<TMP_InputField>();

            Debug.Log(inputField.text);
        }

        public int CharsTyped()
        {
            return 0;
            // string typedString = inputField.text;

            // while (typedString.Contains('<'))
        }
    }
}
