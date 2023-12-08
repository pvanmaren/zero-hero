using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class OpenKeyboard : MonoBehaviour
{
    public TMP_InputField inputField;

    private void Start()
    {
        // Get the TMP_InputField component attached to this GameObject
        inputField = GetComponent<TMP_InputField>();

        if (inputField == null)
        {
            Debug.LogError("EnableMobileKeyboard script is attached to a GameObject without TMP_InputField component.");
            enabled = false; // Disable the script if no TMP_InputField is found
        } 
    }

    public void Keyboard()
    {
        if (inputField != null && inputField.interactable)
        {
            // Open the mobile keyboard for the TMP_InputField
            TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default, false, false, false, false, "");
        }
    }
}
