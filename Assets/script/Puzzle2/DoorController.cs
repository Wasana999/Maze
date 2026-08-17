using UnityEngine;

public class DoorController : MonoBehaviour
{
    [Header("Door Movement")]
    public Vector3 openOffset = new Vector3(0, 4f, 0); // المسافة التي يرتفع لها الباب
    public float openSpeed = 2f;

    private bool isOpen = false;
    private Vector3 targetPosition;

    void Start()
    {
        targetPosition = transform.position;
    }

    void Update()
    {
        if (isOpen)
        {
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * openSpeed);
        }
    }

    public void OpenDoor()
    {
        isOpen = true;
        targetPosition = transform.position + openOffset;
    }
}