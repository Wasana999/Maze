using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [Header("Menu Panels")]
    [Tooltip("ضع هنا كائن القائمة الرئيسية ليتم إخفاؤه عند بدء اللعبة")]
    public GameObject mainMenuPanel;

    private void Start()
    {
        // إظهار الماوس وفك قفله فور تحميل القائمة لضمان إمكانية النقر
        ShowCursor();
    }

    private void OnEnable()
    {
        // إظهار الماوس أيضاً في حال تم تفعيل القائمة أثناء اللعب (Pause Menu)
        ShowCursor();
    }

    // دالة يتم ربطها بزر البدء (Play / Start)
    public void PlayGame()
    {
        Debug.Log("تم الضغط على زر بدء اللعبة بنجاح!");

        // قفل الماوس وإخفاؤه قبل بدء اللعب
        HideCursor();

        // خيار 1: إخفاء القائمة فقط إذا كنت في نفس المشهد
        if (mainMenuPanel != null)
        {
            mainMenuPanel.SetActive(false);
        }

        // خيار 2: الانتقال للمرحلة التالية (تأكد من إضافة المشاهد في Build Settings)
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // دالة لإغلاق القائمة أوالعودة للعب
    public void CloseMenu()
    {
        if (mainMenuPanel != null)
        {
            mainMenuPanel.SetActive(false);
        }
        
        HideCursor();
    }

    // دالة الخروج من اللعبة (ربطها مع زر Quit)
    public void QuitGame()
    {
        Debug.Log("تم إغلاق اللعبة!");
        Application.Quit();
    }

    // أدوات مساعدة للتحكم بالماوس
    private void ShowCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void HideCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}