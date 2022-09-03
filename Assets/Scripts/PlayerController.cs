using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    bool active = true;

    [SerializeField] Transform playerCamera = null;
    [SerializeField] float mouseSensitivity = 3.5f;
    [SerializeField] float walkSpeed = 6.0f;
    [SerializeField] float gravity = -13.0f;
    [SerializeField] [Range(0.0f, 0.5f)] float moveSmoothTime = 0.3f;
    [SerializeField] [Range(0.0f, 0.5f)] float mouseSmoothTime = 0.03f;
    [SerializeField] [Range(1.0f, 2.0f)] float interractDistance = 1.5f;
    float xRotation = 0.0f;
    float velocityY = 0.0f;
    CharacterController controller = null;

    Vector2 currentDir = Vector2.zero;
    Vector2 currentDirVelocity = Vector2.zero;

    Vector2 currentMouseDelta = Vector2.zero;
    Vector2 currentMouseDeltaVelocity = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        EventSystem.instance.colorMode += Deactivate;
        EventSystem.instance.roamMode += Activate;

        controller = GetComponent<CharacterController>();

        Activate();
    }

    // Update is called once per frame
    void Update()
    {
        if(active)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
                InterractWithObject();

            MouseLook();
            Move();
        }
        

    }

    private void InterractWithObject()
    {
        int layerMask = 1 << 8;
        layerMask = ~layerMask;

        var ray = new Ray(playerCamera.position, playerCamera.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interractDistance, layerMask))
        {
            IInteractable interactable = hit.transform.GetComponent<IInteractable>();

            if(interactable != null)
                interactable.Interact(this.transform);
        }
        Debug.DrawRay(ray.origin, ray.direction, Color.green);
    }
    private void MouseLook()
    {
        Vector2 targetMouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        currentMouseDelta = Vector2.SmoothDamp(currentMouseDelta, targetMouseDelta, ref currentMouseDeltaVelocity, mouseSmoothTime);

        xRotation -= currentMouseDelta.y * mouseSensitivity;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        playerCamera.localEulerAngles = Vector3.right * xRotation;

        transform.Rotate(Vector3.up * currentMouseDelta.x * mouseSensitivity);
    }

    private void Move()
    {
        Vector2 targetDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        targetDir.Normalize();

        currentDir = Vector2.SmoothDamp(currentDir, targetDir, ref currentDirVelocity, moveSmoothTime);

        if (controller.isGrounded)
        {
            velocityY = 0.0f;
        }
            

        velocityY += gravity * Time.deltaTime;

        Vector3 dir = (transform.forward * currentDir.y + transform.right * currentDir.x) * walkSpeed + Vector3.up * velocityY;

        controller.Move(dir * Time.deltaTime);
    }

    private void Activate()
    {
        active = true;
        Cursor.lockState = CursorLockMode.Locked;

    }
    private void Deactivate(object sender, Vector3 rgb)
    {
        active = false;
        Cursor.lockState = CursorLockMode.Confined;
    }
}
