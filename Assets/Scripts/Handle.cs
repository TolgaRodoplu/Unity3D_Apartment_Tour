using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handle : MonoBehaviour, IInteractable
{
    Transform parent;
    bool grabbed = false;
    float maxDistance = 1f;

    public void Interact(Transform interactor)
    {
        grabbed = true;
        parent = transform.parent;
        transform.parent = interactor;
    }

    private void Update()
    {
        if(grabbed)
        {
            if(Input.GetKeyUp(KeyCode.Mouse0) || Vector3.Distance(transform.position, parent.position) > maxDistance)
            {
                Rigidbody parentRb = parent.GetComponent<Rigidbody>();

                parentRb.velocity = Vector3.zero;
                parentRb.angularVelocity = Vector3.zero;

                transform.parent = this.parent;
                transform.localRotation = Quaternion.Euler(Vector3.zero);
                transform.localPosition = Vector3.zero;
                transform.localScale = Vector3.one;

                grabbed = false;
            }
        }
    }
}
