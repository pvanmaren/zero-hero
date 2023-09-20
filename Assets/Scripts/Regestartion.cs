using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;

public class Regestartion : MonoBehaviour
{
    [SerializeField]private TMP_InputField nameField;
    [SerializeField] private TMP_InputField functionField;
    [SerializeField] private TMP_InputField emailField;
    [SerializeField] private TMP_InputField passwordField;
    [SerializeField] private Button submitButton;

    public void CallRegister()
    {
        print(nameField.text, functionField.text, emailField.text, passwordField.text);
        //StartCoroutine(GetRegister());
    }

    private IEnumerator GetRegister()
    {
        List<IMultipartFormSection> formData = new List<IMultipartFormSection>();
        formData.Add(new MultipartFormDataSection("name", nameField.text));
        formData.Add(new MultipartFormDataSection("function", functionField.text));
        formData.Add(new MultipartFormDataSection("email", emailField.text));
        formData.Add(new MultipartFormDataSection("password", passwordField.text));

        UnityWebRequest www = UnityWebRequest.Post("http://localhost/sqlconnect/register.php", formData);
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("User successfully created.");
            /*UnityEngine.SceneManagement.SceneManager.LoadScene(4);*/
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
