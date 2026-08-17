using UnityEngine;

public class LevelTwoManager : MonoBehaviour
{
    [Header("1. إعدادات الكتاب والأسطورة")]
    public GameObject bookUIPanel;          // واجهة قراءة الأسطورة (UI Panel)
    public KeyCode interactKey = KeyCode.E; // زر التفاعل

    [Header("2. إعدادات الأغراض والمجسم")]
    public string requiredItemID = "GoldFlower"; // اسم الغرض الصحيح للغز
    public Transform itemPlacementPoint;         // مكان وضع الغرض فوق المجسم
    public GameObject door;                      // كائن الباب المراد فتحه

    [Header("3. الأصوات (اختياري)")]
    public AudioSource audioSource;
    public AudioClip correctSound;
    public AudioClip wrongSound;

    // متغيرات التتبع والربط الداخلي
    private PickableInfo heldItem = null;        // الغرض المحمول حالياً
    private PickableInfo currentItemInRange = null;
    private bool isPlayerNearBook = false;
    private bool isPlayerNearStatue = false;
    private PickableInfo placedItemOnStatue = null; // الغرض الموضوع حالياً فوق المجسم

    void Update()
    {
        // عند الضغط على زر التفاعل (E)
        if (Input.GetKeyDown(interactKey))
        {
            // أ) إذا كان اللاعب عند الكتاب -> يفتح أو يغلق الكتاب
            if (isPlayerNearBook)
            {
                ToggleBookUI();
            }
            // ب) إذا كان عند المجسم ويحمل غرضاً -> يضع الغرض على المجسم
            else if (isPlayerNearStatue && heldItem != null)
            {
                TrySolveStatuePuzzle();
            }
            // ج) إذا كان عند غرض على الأرض ويده فاضية -> يلتقط الغرض
            else if (currentItemInRange != null && heldItem == null)
            {
                PickupItem(currentItemInRange);
            }
        }

        // إغلاق الكتاب بالضغط على ESC
        if (Input.GetKeyDown(KeyCode.Escape) && bookUIPanel != null && bookUIPanel.activeSelf)
        {
            bookUIPanel.SetActive(false);
        }
    }

    // --- نظام قراءة الكتاب ---
    void ToggleBookUI()
    {
        if (bookUIPanel != null)
        {
            bool isActive = bookUIPanel.activeSelf;
            bookUIPanel.SetActive(!isActive);
        }
    }

    // --- نظام التقاط الأغراض ---
    void PickupItem(PickableInfo item)
    {
        heldItem = item;
        heldItem.Pickup();
        currentItemInRange = null;
        Debug.Log("تم التقاط الغرض: " + heldItem.itemID);
    }

    // --- نظام حل اللغز عند المجسم ---
    void TrySolveStatuePuzzle()
    {
        // إذا كان هناك غرض سابق خاطئ موضوع على المجسم، أرجعه أو أطفئه
        if (placedItemOnStatue != null)
        {
            placedItemOnStatue.gameObject.SetActive(false);
        }

        // تثبيت الغرض الجديد على المجسم
        placedItemOnStatue = heldItem;
        placedItemOnStatue.PlaceAt(itemPlacementPoint);

        // تفريغ يد اللاعب
        heldItem = null;

        // التحقق من صحة الغرض
        if (placedItemOnStatue.itemID == requiredItemID)
        {
            Debug.Log("إجابة صحيحة! جاري فتح الباب...");
            if (audioSource && correctSound) audioSource.PlayOneShot(correctSound);

            if (door != null)
            {
                door.SetActive(false); // إخفاء أو فتح الباب
            }
        }
        else
        {
            Debug.Log("غرض خاطئ! يمكنك جلب غرض آخر وتجربته.");
            if (audioSource && wrongSound) audioSource.PlayOneShot(wrongSound);
        }
    }

    // --- كشف الاقتراب والابتعاد (Triggers) ---
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Book"))
        {
            isPlayerNearBook = true;
        }
        else if (other.CompareTag("Statue"))
        {
            isPlayerNearStatue = true;
        }
        else if (other.CompareTag("Item"))
        {
            currentItemInRange = other.GetComponent<PickableInfo>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Book"))
        {
            isPlayerNearBook = false;
            if (bookUIPanel != null) bookUIPanel.SetActive(false); // إغلاق الكتاب عند الابتعاد
        }
        else if (other.CompareTag("Statue"))
        {
            isPlayerNearStatue = false;
        }
        else if (other.CompareTag("Item"))
        {
            if (currentItemInRange != null && currentItemInRange.gameObject == other.gameObject)
            {
                currentItemInRange = null;
            }
        }
    }
}