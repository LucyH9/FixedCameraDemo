/*
@Author: Lucy Herrera
@Description: This script manages the text box that should pop up when the player character interacts with an object.
 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Imort TMPro library
using TMPro;


public class ThoughtTextManager : MonoBehaviour
{
    //Initialize game objets
    public GameObject thoughtPanel;
    public TextMeshProUGUI thoughtTextBox;
    private bool isShowing = false;

    public void ShowThought(string message)
    {
        thoughtPanel.SetActive(true);
        thoughtTextBox.text = message;
        isShowing = true;
        //Pause game code below TBD
    }

    public void HideThought()
    {
        thoughtPanel.SetActive(false);
        isShowing = false;
    }

    private void Update()
    {
        if (isShowing && Input.GetKeyDown(KeyCode.Space))
        {
            HideThought();
        }
    }

}
