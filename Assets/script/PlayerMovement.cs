using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float mouseSensitivity = 0.15f;
    public Transform cameraTransform;

    private Rigidbody rb;
    private Vector3 movement;

    private float cameraPitch = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // الحركة
        float x = 0f;
        float z = 0f;

        if (Keyboard.current.wKey.isPressed) z = 1f;
        if (Keyboard.current.sKey.isPressed) z = -1f;
        if (Keyboard.current.aKey.isPressed) x = -1f;
        if (Keyboard.current.dKey.isPressed) x = 1f;

        movement = new Vector3(x, 0f, z).normalized;


        // الماوس
        Vector2 mouse = Mouse.current.delta.ReadValue();

        float mouseX = mouse.x * mouseSensitivity;
        float mouseY = mouse.y * mouseSensitivity;


        // يمين ويسار - اللاعب نفسه
        transform.Rotate(0f, mouseX, 0f);


        // فوق وتحت - الكاميرا
        cameraPitch -= mouseY;

        cameraPitch = Mathf.Clamp(cameraPitch, -80f, 80f);

        cameraTransform.localRotation =
            Quaternion.Euler(cameraPitch, 0f, 0f);
    }

    void FixedUpdate()
    {
        Vector3 moveDirection =
            transform.forward * movement.z +
            transform.right * movement.x;

        rb.MovePosition(
            rb.position +
            moveDirection * speed * Time.fixedDeltaTime
        );
    }
}