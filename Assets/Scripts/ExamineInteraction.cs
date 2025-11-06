using System;
using System.Collections.Generic;
using UnityEngine;

public class ExamineInteraction : MonoBehaviour, IInteractable
{
    [SerializeField] List<string> examineDialogue;

    // Option A: Assign in inspector (safer)
    [SerializeField] TextPrinter subtitlePrinter;

    void Awake()
    {
        // If subtitlePrinter is not assigned manually, try to find it
        if (subtitlePrinter == null)
        {
            var printerObj = GameObject.FindGameObjectWithTag("Subtitle Printer");
            if (printerObj != null)
            {
                subtitlePrinter = printerObj.GetComponent<TextPrinter>();
                if (subtitlePrinter == null)
                    Debug.LogError("TextPrinter component missing on Subtitle Printer object!");
            }
            else
            {
                Debug.LogError("No GameObject found with tag 'Subtitle Printer'");
            }
        }
    }

    public void OnPlayerInteraction(Action onInteractionEnded)
    {
        // Null checks to prevent crashes
        if (subtitlePrinter == null)
        {
            Debug.LogError("Cannot interact: subtitlePrinter is null!");
            onInteractionEnded?.Invoke();
            return;
        }

        if (examineDialogue == null || examineDialogue.Count == 0)
        {
            Debug.LogWarning("Examine dialogue is empty!");
            onInteractionEnded?.Invoke();
            return;
        }

        subtitlePrinter.Print(examineDialogue, onInteractionEnded);
    }
}
