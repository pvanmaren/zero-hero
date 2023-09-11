using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking; // Import UnityWebRequest
using System.Collections.Generic;
using TMPro;

public class Regestartion : MonoBehaviour
{
    public TMP_InputField nameField;
    public TMP_InputField passwordField;

    public Button submitButton;

    public void CallRegister()
    {
        StartCoroutine(GetRegister());
    }

    private IEnumerator GetRegister()
    {
        List<IMultipartFormSection> formData = new List<IMultipartFormSection>();
        formData.Add(new MultipartFormDataSection("name", nameField.text));
        formData.Add(new MultipartFormDataSection("password", passwordField.text));

        UnityWebRequest www = UnityWebRequest.Post("http://localhost/sqlconnect/register.php", formData);
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("User successfully created.");
            UnityEngine.SceneManagement.SceneManager.LoadScene(4);
        }
        else
        {
            Debug.Log("It failed. Error: " + www.error);
        }
    }

    public void verifyInputs()
    {
        submitButton.interactable = (nameField.text.Length >= 8 && passwordField.text.Length >= 8);
    }
}
