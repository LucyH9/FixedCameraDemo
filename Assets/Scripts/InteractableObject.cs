using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public string thoughtText;
    public KeyCode interactKey = KeyCode.E;
    public bool requiresPress = true;
}
