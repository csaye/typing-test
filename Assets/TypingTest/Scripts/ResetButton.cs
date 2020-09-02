using UnityEngine;
using UnityEngine.SceneManagement;

namespace TypingTest
{
    public class ResetButton : MonoBehaviour
    {
        public void Reset()
        {
            SceneManager.LoadScene("TypingTest");
        }
    }
}
