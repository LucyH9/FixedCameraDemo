using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using System;

public class TextPrinter : MonoBehaviour
{
    [SerializeField] [Range(0, 0.4f)] float normalTextSpeed;
    [SerializeField] [Range(0, 0.2f)] float skipTextSpeed;
    float currentTextSpeed;

    TMP_Text textMesh;


    public void Print(List<string> sentences, Action onFinishedPrinting) //Check fast action parameter later
    {
        if (textMesh == null)
        {
            Debug.LogError("TextMeshPro component is not assigned!");
            return;
        }

        StartCoroutine(PrintDialogue(sentences, onFinishedPrinting));
    }

    IEnumerator PrintDialogue(List<string> sentences, Action onFinishedPrinting)
    {
        foreach (var sentence in sentences)
        {
            RepositionSentence(sentence);
            textMesh.text = string.Empty;
            yield return new WaitForSecondsRealtime(0.1f);

            foreach (var letter in sentence) 
            {
                HandleTextSpeed();
                textMesh.text += letter;
                if (letter == ' ') continue;
                yield return new WaitForSecondsRealtime(currentTextSpeed);
            }
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E));
        }

        textMesh.text = string.Empty;
        onFinishedPrinting?.Invoke();
    }

    void RepositionSentence(string sentence) 
    {
        textMesh.text = sentence;
        textMesh.ForceMeshUpdate();
        var firstChar = textMesh.textInfo.lineInfo[0].firstVisibleCharacterIndex;
        var lastChar = textMesh.textInfo.lineInfo[0].lastVisibleCharacterIndex;
        var firstCharPos = textMesh.textInfo.characterInfo[firstChar].topLeft;
        var lastCharPos = textMesh.textInfo.characterInfo[lastChar].topRight;
        textMesh.rectTransform.anchoredPosition = new Vector2(
        0 - (firstCharPos.x + lastCharPos.x) / 2,
        textMesh.rectTransform.anchoredPosition.y
        );
        textMesh.text = string.Empty;
    }
    void HandleTextSpeed() 
    {
        if (Input.GetKey(KeyCode.E)) 
        {
            currentTextSpeed = skipTextSpeed;
        }
        else 
        {
            currentTextSpeed = normalTextSpeed;
        }
    }

    //Check start method
    void Start()
    {
        textMesh = GetComponent<TMP_Text>();
    }

}
