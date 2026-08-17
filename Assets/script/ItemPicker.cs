using UnityEngine;

public class ItemPicker : MonoBehaviour
{
    private GameObject heldItem = null;
    private Camera playerCamera;

    void Start()
    {
        playerCamera = GetComponent<Camera>();
        if (playerCamera == null)
        {
            playerCamera = Camera.main;
        }
        Debug.Log("✅ ItemPicker جاهز!");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (heldItem == null)
                TryPickUpItem();
            else
                TryPlaceItem();
        }
    }

    void TryPickUpItem()
    {
        Ray ray = playerCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 3f))
        {
            Debug.Log("🔍 نظرت إلى: " + hit.collider.name);

            if (hit.collider.CompareTag("Item"))
            {
                heldItem = hit.collider.gameObject;
                heldItem.SetActive(false);
                Debug.Log("✅ التقطت: " + heldItem.GetComponent<Item>().itemName);
            }
        }
    }

    void TryPlaceItem()
    {
        Ray ray = playerCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 3f))
        {
            Debug.Log("🔍 نظرت إلى: " + hit.collider.name);

            DeliverySpot spot = hit.collider.GetComponent<DeliverySpot>();
            if (spot != null)
            {
                Debug.Log("✅ وجدت DeliverySpot!");
                spot.AttemptPlaceItem(heldItem);

                // 🔥 نفضي اليد عشان نقدر نلتقط غرض جديد
                heldItem = null;
            }
            else
            {
                Debug.Log("❌ هذا ليس DeliverySpot");
            }
        }
    }
}