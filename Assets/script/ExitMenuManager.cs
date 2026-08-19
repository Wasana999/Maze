using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitMenuManager : MonoBehaviour
{
    [Header("UI & Player References")]
    public GameObject exitMenuCanvas; // الكانفس أو القائمة المراد إخفاؤها
    public Transform playerTransform; // مجسم اللاعب
    public Transform spawnPoint;      // المكان الذي يدسبن فيه اللاعب
     public GameObject tab; 
    [Header("Scene Names")]
    public string mainMenuSceneName = "MainMenuScene";

    // 1. زر إعادة اللعب (في نفس السين)
    public void PlayAgain()
    {
        // 1. إخفاء القائمة
        if (exitMenuCanvas != null)
        {
            exitMenuCanvas.SetActive(false);
        }

        // 2. نقل اللاعب إلى مكان الدسبونة (Spawn Point)
        if (playerTransform != null && spawnPoint != null)
        {
            // إذا كنت تستخدم CharacterController، يجب تعطيله مؤقتاً قبل النقل حتى يتغير الموقع بنجاح
            CharacterController cc = playerTransform.GetComponent<CharacterController>();
            if (cc != null)
            {
                cc.enabled = false;
            }

            playerTransform.position = spawnPoint.position;
            playerTransform.rotation = spawnPoint.rotation;

            if (cc != null)
            {
                cc.enabled = true;
            }
        }

        // 3. قفل المؤشر (Cursor) وإخفاؤه للعودة بالتحكم للاعب
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // 4. إرجاع الوقت لو كنت عملت Pause
        Time.timeScale = 1f;
    }

    // 2. زر العودة للقائمة الرئيسية
    public void ReturnToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(mainMenuSceneName);
    }

    // 3. زر الخروج من اللعبة
    public void QuitGame()
    {
        Debug.Log("Exiting Game...");
        Application.Quit();
    }


}