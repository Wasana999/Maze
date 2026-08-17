using UnityEngine;

public class DoorController : MonoBehaviour
{
    [Header("إعدادات رفع الباب")]
    public float raiseHeight = 5f; // مقدار الارتفاع للأعلى (5 أمتار)
    public float speed = 2f;       // سرعة الارتفاع

    private bool isOpening = false;
    private Vector3 targetPosition;

    void Start()
    {
        // تحديد النقطة العلوية التي سيرتفع إليها الباب
        targetPosition = transform.position + new Vector3(0, raiseHeight, 0);
    }

    void Update()
    {
        // رفع الباب بسلاسة للأعلى عند حل اللغز
        if (isOpening)
        {
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * speed);
        }
    }

    // دالة استدعاء فتح الباب
    public void OpenDoor()
    {
        isOpening = true;
    }
}