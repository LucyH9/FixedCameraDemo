using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionController : MonoBehaviour
{
    [SerializeField] Transform hitBox;
    bool isBusy;

    void Update()
    {
        if (isBusy) return;

        if (Input.GetKeyDown(KeyCode.E)) 
        {
            var collisions = Physics.OverlapBox(hitBox.position, hitBox.localScale * 0.05f, transform.rotation, ~0, QueryTriggerInteraction.Collide);

            foreach(var collision in collisions) 
            {
                IInteractable interactedObject;
                if (collision.TryGetComponent<IInteractable>(out interactedObject) == true) 
                {

                    interactedObject.OnPlayerInteraction(OnInteractionFinished);
                    OnInteractionStarted();
                    break;

                }
            }

        }
    }

    public void OnInteractionStarted()
    {
        Time.timeScale = 0;
        isBusy = true;
    }
    public void OnInteractionFinished() 
    {
        Time.timeScale = 1f;
        isBusy = false;
    }

    float boxShowTimer = 0f;

}
