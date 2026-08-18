using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{

    // أضف اسم المشهد الخاص باللعبة هنا أو رقم ترتيبه في الـ Build Settings
    [SerializeField] private string gameSceneName = "GameScene";

    // تُربط هذه الدالة بزر Play
    public void PlayGame()
    {
        SceneManager.LoadScene(gameSceneName);
    }

    // تُربط هذه الدالة بزر Exit
    public void QuitGame()
    {
        Debug.Log("Game Exited!"); // يظهر في الـ Console داخل المحرر
        Application.Quit();        // يعمل فقط بعد عمل Build للعبة
    }
}

