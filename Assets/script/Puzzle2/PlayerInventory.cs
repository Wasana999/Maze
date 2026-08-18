using UnityEngine;
using TMPro; // استخدم TextMeshPro للـ UI

public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory Instance { get; private set; }

    [Header("UI Reference")]
    [SerializeField] private TextMeshProUGUI uiStatusText; // نص الـ UI للتنبيه

    public bool HasCandle { get; private set; } = false;
    public string CurrentCandleID { get; private set; } = "";

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void PickUpCandle(string id)
    {
        HasCandle = true;
        CurrentCandleID = id;

        // تحديث الـ UI
        if (uiStatusText != null)
            uiStatusText.text = "الحقيبة: معاي شمعة 🕯️";
    }

    public void ClearCandle()
    {
        HasCandle = false;
        CurrentCandleID = "";

        if (uiStatusText != null)
            uiStatusText.text = "الحقيبة: فارغة";
    }
}