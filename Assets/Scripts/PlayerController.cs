using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform playerCamera = null;
    [SerializeField] private float mouseSensitivity = 3.5f;
    [SerializeField] private float walkSpeed = 6.0f;
    private float xRotation = 0.0f;


    CharacterController controller = null;


    // Start is called before the first frame update
    void Start()
    {

        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {

        MouseLook();
        Move();
    }

    private void MouseLook()
    {
        Vector2 mouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        xRotation -= mouseDelta.y * mouseSensitivity;

        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        playerCamera.localEulerAngles = Vector3.right * xRotation;

        transform.Rotate(Vector3.up * mouseDelta.x * mouseSensitivity);
    }

    private void Move()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        input.Normalize();

        Vector3 dir = (transform.forward * input.y + transform.right * input.x) * walkSpeed;

        controller.Move(dir * Time.deltaTime);
    }
}
