using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using TMPro;

public class Login : MonoBehaviour
{
    public TMP_InputField nameField;
    public TMP_InputField passwordField;
    public Button submitButton;
    [SerializeField] private AppData appData;

    private string userData;

    public void CallLogin()
    {
        StartCoroutine(LoginUser());
    }

    IEnumerator LoginUser()
    {
        // Ensure the inputs are not empty
        if (string.IsNullOrEmpty(nameField.text) || string.IsNullOrEmpty(passwordField.text))
        {
            Debug.LogError("Username and password cannot be empty.");
            yield break;
        }

        List<IMultipartFormSection> formData = new List<IMultipartFormSection>();
        formData.Add(new MultipartFormDataSection("name", nameField.text));
        formData.Add(new MultipartFormDataSection("password", passwordField.text));

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/sqlconnect/login.php", formData))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                string responseText = www.downloadHandler.text;
                string[] responseTextSplitter = responseText.Split("{");
                string[] responseTextSplit = responseText.Split('"');
                print(responseTextSplitter.Length);
                if (responseTextSplitter.Length > 2) 
                {
                    userData = responseTextSplitter[^1];
                }
                foreach (string word in responseTextSplitter)
                {
                    print(word);
                }

                print("user data: " + userData);
                string responseStatus = responseTextSplit[1];
                string responseErrorMsg = responseTextSplit[3];


                if (responseStatus == "success")
                {
                    // Login successful
                    DBManager.username = nameField.text;
                    Debug.Log("Login successful!");
                    /*UnityEngine.SceneManagement.SceneManager.LoadScene(4);*/
                }
                else
                {
                    // Login failed
                    Debug.LogError("Login failed: " + responseErrorMsg);
                }
            }
            else
            {
                // Handle network errors
                Debug.LogError("Network error: " + www.error);
            }
        }
    }

    public void VerifyInputs()
    {
        // Enable the submit button if both fields have at least 8 characters
        submitButton.interactable = (nameField.text.Length >= 8 && passwordField.text.Length >= 8);
    }
}
