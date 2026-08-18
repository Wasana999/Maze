using System;
using UnityEngine;

public class Door : MonoBehaviour
{
    public float openHeight = 4f;
    public float speed = 2f;

    private Vector3 openPosition;
    private bool isOpening = false;
    [SerializeField] private GameObject doorText;

    void Start()
    {
        openPosition = transform.position + Vector3.up * openHeight;
        doorText.SetActive(false);
    }

    void Update()
    {
        if (isOpening)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                openPosition,
                speed * Time.deltaTime
               
            );
            doorText.SetActive(true);
        }
    }

    public void OpenDoor()
    {
        isOpening = true;
    }
}
