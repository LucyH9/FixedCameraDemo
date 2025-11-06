using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float interactRange = 2f;
    public LayerMask interactLayer;
    public KeyCode interactKey = KeyCode.E;
    private Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        if (Input.GetKeyDown(interactKey))
        {
            Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            if (Physics.Raycast(ray, out RaycastHit hit, interactRange, interactLayer))
            {
                InteractableObject interactable = hit.collider.GetComponent<InteractableObject>();
                if (interactable != null)
                {
                    FindObjectOfType<ThoughtTextManager>().ShowThought(interactable.thoughtText);
                }
            }
        }
    }
}
