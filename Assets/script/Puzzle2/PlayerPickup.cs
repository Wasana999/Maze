using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    [Header("Settings")]
    public Transform holdPoint; // Transform فارغ أمام الكاميرا لتحديد مكان حمل المجسم
    public float pickupDistance = 3f;
    public KeyCode interactKey = KeyCode.E;

    private GameObject heldObject;
    private Rigidbody heldRb;

    void Update()
    {
        if (Input.GetKeyDown(interactKey))
        {
            if (heldObject == null)
            {
                TryPickup();
            }
            else
            {
                DropObject();
            }
        }

        if (heldObject != null)
        {
            // تحريك المجسم بسلاسة لمكان الحمل
            heldObject.transform.position = holdPoint.position;
            heldObject.transform.rotation = holdPoint.rotation;
        }
    }

    void TryPickup()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, pickupDistance))
        {
            // نتحقق أن المجسم قابل للشيل وله Rigidbody
            if (hit.collider.CompareTag("Pickupable") && hit.rigidbody != null)
            {
                heldObject = hit.collider.gameObject;
                heldRb = hit.rigidbody;

                heldRb.isKinematic = true; // تعطيل الفيزياء أثناء الحمل
                heldObject.transform.SetParent(holdPoint);
            }
        }
    }

    public void DropObject()
    {
        if (heldObject == null) return;

        heldObject.transform.SetParent(null);
        heldRb.isKinematic = false; // إعادة الفيزياء عند الإسقاط
        heldObject = null;
        heldRb = null;
    }
}