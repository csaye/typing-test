using TMPro;
using UnityEngine;

namespace TypingTest
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class TextToWrite : MonoBehaviour
    {
        public string text
        {
            get
            {
                return textField.text;
            }
            private set
            {
                textField.text = value;
            }
        }

        private string[] words = new string[1000];

        private TextMeshProUGUI textField;

        private const int totalLines = 8;
        private const int charsToLine = 30;

        private void Start()
        {
            textField = GetComponent<TextMeshProUGUI>();

            InitializeWords();
            PrintLines();
        }

        private void InitializeWords()
        {
            TextAsset wordsFile = (TextAsset)Resources.Load("Words");
            string wordsText = wordsFile.text;
            words = wordsText.Split('\n');
        }

        private string GetRandomWord()
        {
            int randomIndex = Random.Range(0, words.Length);
            return words[randomIndex];
        }

        private void PrintLines()
        {
            while (text.Length < charsToLine * totalLines)
            {
                PrintWord();
            }
        }

        private void PrintWord()
        {
            string word = GetRandomWord();

            if (text == "")
            {
                text += word;
            }
            else
            {
                text += $" {word}";
            }
        }
    }
}
