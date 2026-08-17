using UnityEngine;

public class PuzzleZone : MonoBehaviour
{
    [Header("Settings")]
    public string correctKeyTag = "CorrectKey"; // Tag المجسم الصحيح
    public Transform snapPosition; // المكان والدوران الدقيق للتثبيت
    public DoorController targetDoor;

    private bool isSolved = false;

    private void OnTriggerEnter(Collider other)
    {
        if (isSolved) return;

        if (other.CompareTag(correctKeyTag))
        {
            SolvePuzzle(other.gameObject);
        }
    }

    void SolvePuzzle(GameObject correctObject)
    {
        isSolved = true;

        // إفلات المجسم إذا كان اللاعب لا يزال حامله
        PlayerPickup playerPickup = FindObjectOfType<PlayerPickup>();
        if (playerPickup != null)
        {
            playerPickup.DropObject();
        }

        // تثبيت المجسم في المكان الصحيح وتعطيل تحريكه
        correctObject.transform.position = snapPosition.position;
        correctObject.transform.rotation = snapPosition.rotation;

        Rigidbody rb = correctObject.GetComponent<Rigidbody>();
        if (rb != null) rb.isKinematic = true;

        // تغيير الـ Tag حتى لا يمكن شيله مرة أخرى
        correctObject.tag = "Untagged";

        // فتح الباب
        if (targetDoor != null)
        {
            targetDoor.OpenDoor();
        }
    }
}