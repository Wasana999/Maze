using UnityEngine;

public class DropZone : MonoBehaviour
{
    [SerializeField] private string requiredCandleID = "Candle_01"; // معرّف الشمعة المطلوبة لهذا المكان
    [SerializeField] private GameObject candleModelOnDrop; // المجسم الأصلي المطفأ اللي بيظهر في المكان الصح

    [SerializeField] private GameObject Door;
    private bool isSolved = false;

    private void OnTriggerEnter(Collider other)
    {
        if (isSolved) return;

        if (other.CompareTag("Player"))
        {
            // التحقق هل اللاعب يملك شمعة وهل هي الشمعة الصحيحة
            if (PlayerInventory.Instance.HasCandle)
            {
                if (PlayerInventory.Instance.CurrentCandleID == requiredCandleID)
                {
                    OnCorrectPlacement();
                }
                else
                {
                    Debug.Log("هذه ليست الشمعة الصحيحة لهذا المكان!");
                }
            }
        }
    }

    private void OnCorrectPlacement()
    {
        isSolved = true;

        // إفراغ الشمعة من حقيبة اللاعب وتحديث الـ UI
        PlayerInventory.Instance.ClearCandle();

        // إظهار المجسم في المكان الصحيح
        if (candleModelOnDrop != null)
            candleModelOnDrop.SetActive(true);
        Door.SetActive(false);

        Debug.Log("تم وضع الشمعة في مكانها الصحيح بنجاح!");

        // --- اكتب كودك التكميلي هنا (فتح باب، تشغيل إضاءة، إلخ) ---
    }
}