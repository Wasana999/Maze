using UnityEngine;

public class won : MonoBehaviour
{
public GameObject win;

    private bool playerNear = false;

    void Update()
    {
        if (playerNear && Input.GetKeyDown(KeyCode.E))
        {
                        win.SetActive(true); 
                        Cursor.lockState = CursorLockMode.None; // تحرير الماوس من منتصف الشاشة
        Cursor.visible = true;

                   }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNear = true;
            Debug.Log("Press E");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNear = false;
        }
    }
}


