using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TypewriterEffect : MonoBehaviour
{
    public TextMeshProUGUI textComponent;       // Reference to the Text component on the canvas

    [TextArea(3,20)]
    public string textToType;                   // The text to be typed

    public float typingSpeed = 0.08f;           // The speed of typing in seconds
    private Coroutine typingCoroutine;          // Reference to the typing coroutine

    void Start()
    {
        // Start typing coroutine when the script is first loaded
        typingCoroutine = StartCoroutine(TypeText());
    }

    IEnumerator TypeText()
    {
        textComponent.text = "";  // Clear existing text
        float typingSpeedThisCharacter = typingSpeed;
        // Loop through each character in the textToType

        for (int i = 0; i < textToType.Length; i++)
        {
            Debug.Log(i);
            bool isLetter = true;
            textComponent.text += textToType[i];  // Add the next character to the textComponent

            switch(textToType[i].ToString())
            {
                case " ":
                    typingSpeedThisCharacter *= 0.7f;
                    isLetter = false;
                    break;
                case ",":
                    typingSpeedThisCharacter *= 1.6f;
                    isLetter = false;
                    break;
                case ".":
                    typingSpeedThisCharacter = 0.8f;
                    isLetter = false;
                    break;
            }
            if (isLetter)
            {
                typingSpeedThisCharacter = typingSpeed;
            }
            yield return new WaitForSeconds(typingSpeedThisCharacter);  // Wait for typingSpeed seconds before typing the next character
        }

        // Typing is complete
        typingCoroutine = null;
    }

    // Call this function to stop typing prematurely
    public void StopTyping()
    {
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
            typingCoroutine = null;
        }
    }
}