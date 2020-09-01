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
        }

        private string[] words = new string[1000];

        private TextMeshProUGUI textField;

        private const int initialTextLines = 8;
        private const int charsToLine = 30;

        private void Start()
        {
            textField = GetComponent<TextMeshProUGUI>();

            InitializeWords();

            for (int i = 0; i < initialTextLines; i++)
            {
                PrintLine();
            }
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

        private void PrintLine()
        {
            int charsAdded = 0;

            while (charsAdded < charsToLine)
            {
                charsAdded += PrintWord();
            }
        }

        private int PrintWord()
        {
            string newWord = $"{GetRandomWord()} ";
            textField.text += newWord;
            return newWord.Length;
        }
    }
}
