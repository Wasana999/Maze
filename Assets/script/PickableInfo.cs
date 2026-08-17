using UnityEngine;

public class PickableInfo : MonoBehaviour
{
    [Header("بيانات الغرض")]
    public string itemID = "GoldFlower"; // اكتب هنا اسم الغرض (مثل: GoldFlower أو Stone أو Key)

    // إخفاء الغرض من الأرض عند الالتقاط
    public void Pickup()
    {
        gameObject.SetActive(false);
    }

    // إظهار الغرض ووضعه فوق المجسم
    public void PlaceAt(Transform placementPoint)
    {
        transform.position = placementPoint.position;
        transform.rotation = placementPoint.rotation;
        gameObject.SetActive(true);
    }
}