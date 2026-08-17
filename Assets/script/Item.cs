using UnityEngine;

public class Item : MonoBehaviour
{
    public string itemName; // اكتب اسم الغرض هنا في Inspector

    [HideInInspector]
    public Vector3 originalPosition; // الموقع الأصلي (يُحفظ تلقائيًا)

    [HideInInspector]
    public Quaternion originalRotation; // الدوران الأصلي (يُحفظ تلقائيًا)

    void Start()
    {
        // حفظ الموقع والدوران الأصليين عند بداية اللعبة
        originalPosition = transform.position;
        originalRotation = transform.rotation;
    }
}