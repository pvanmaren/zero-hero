using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;

public class Regestartion : MonoBehaviour
{
    [SerializeField] private TMP_InputField nameField;
    [SerializeField] private TMP_InputField functionField;
    [SerializeField] private TMP_InputField emailField;
    [SerializeField] private TMP_InputField passwordField;
    [SerializeField] private Button submitButton;

    public void Start()
    {
        emailField.contentType = TMP_InputField.ContentType.EmailAddress;
        passwordField.contentType = TMP_InputField.ContentType.Password;
    }

    public void OpenLogin()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("LoginScreen");

    }

    public void CallRegister()
    {
        string output = nameField.text + ", " + functionField.text + ", " + emailField.text + ", " + passwordField.text;
        print(output);
        StartCoroutine(GetRegister());
    }

    private IEnumerator GetRegister()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", nameField.text);
        form.AddField("function", functionField.text);
        form.AddField("email", emailField.text);
        form.AddField("password", passwordField.text);

        UnityWebRequest www = UnityWebRequest.Post("http://localhost/sqlconnect/register.php", form);

        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("User successfully created.");
            OpenLogin();
        }
        else
        {
            Debug.Log("It failed. Error: " + www.error);
        }
    }

    public void verifyInputs()
    {
        submitButton.interactable = true;
    }
}