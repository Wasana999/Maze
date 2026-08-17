using UnityEngine;

public class DeliverySpot : MonoBehaviour
{
    [Header("الغرض الصحيح")]
    public string correctItemName = "Candellvl2";

    [Header("الباب")]
    public GameObject doorToOpen; // اسحب الباب doorlv2 هنا
    public float doorOpenHeight = 5f;
    public float doorSpeed = 2f;

    private bool isCompleted = false;
    private bool isMoving = false;
    private Vector3 startPosition;
    private Vector3 targetPosition;

    void Start()
    {
        if (doorToOpen != null)
        {
            startPosition = doorToOpen.transform.position;
            targetPosition = startPosition + Vector3.up * doorOpenHeight;
            Debug.Log("✅ الباب مربوط: " + doorToOpen.name);
        }
        else
        {
            Debug.Log("❌ الباب غير مربوط! اسحب الباب doorlv2 إلى حقل Door To Open");
        }

        Debug.Log("✅ DeliverySpot جاهز! الغرض المطلوب: " + correctItemName);
    }

    void Update()
    {
        if (isMoving && doorToOpen != null)
        {
            doorToOpen.transform.position = Vector3.Lerp(
                doorToOpen.transform.position,
                targetPosition,
                Time.deltaTime * doorSpeed
            );

            if (Vector3.Distance(doorToOpen.transform.position, targetPosition) < 0.01f)
            {
                doorToOpen.transform.position = targetPosition;
                isMoving = false;
                Debug.Log("✅ الباب وصل للأعلى!");
            }
        }
    }

    public void AttemptPlaceItem(GameObject itemToPlace)
    {
        Debug.Log("📦 محاولة وضع غرض: " + itemToPlace.name);

        if (isCompleted)
        {
            Debug.Log("⛔ اللغز مكتمل بالفعل!");
            return;
        }

        if (itemToPlace == null)
        {
            Debug.Log("❌ لا يوجد غرض لوضعه!");
            return;
        }

        Item itemScript = itemToPlace.GetComponent<Item>();
        if (itemScript == null)
        {
            Debug.Log("❌ الغرض ليس له سكريبت Item!");
            return;
        }

        Debug.Log($"📌 اسم الغرض في الـ Item: {itemScript.itemName}");
        Debug.Log($"🎯 الاسم المطلوب: {correctItemName}");

        if (string.Equals(itemScript.itemName, correctItemName, System.StringComparison.OrdinalIgnoreCase))
        {
            Debug.Log("✅✅✅ تم وضع الغرض الصحيح! الباب سيفتح!");
            isCompleted = true;

            itemToPlace.transform.position = this.transform.position + Vector3.up * 0.5f;
            itemToPlace.SetActive(true);

            Rigidbody rb = itemToPlace.GetComponent<Rigidbody>();
            if (rb != null) rb.isKinematic = true;

            OpenDoor();
        }
        else
        {
            Debug.Log($"❌ خطأ! أنت وضعت {itemScript.itemName}، المطلوب {correctItemName}");
        }
    }

    void OpenDoor()
    {
        if (doorToOpen != null)
        {
            isMoving = true;
            Debug.Log("🚪 الباب " + doorToOpen.name + " بدأ يتحرك للأعلى!");
        }
        else
        {
            Debug.Log("❌ الباب غير مربوط! اسحب الباب doorlv2 إلى حقل Door To Open");
        }
    }
}