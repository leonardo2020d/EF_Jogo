using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IInteractable
{
    public void Interact();
}
public class Interactor : MonoBehaviour
{

    public Transform interactorSource;
    public float interactorRange;
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            Ray ray = new Ray(interactorSource.position, interactorSource.forward);
            if (Physics.Raycast(ray, out RaycastHit hitInfo, interactorRange))
            {
                if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
                {
                    print("A");
                    interactObj.Interact();

                }

            }
        }
    }

}
