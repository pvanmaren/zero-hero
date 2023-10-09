using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Login : MonoBehaviour
{
    [SerializeField] private TMP_Text errorMsg;
    [SerializeField] private TMP_InputField nameField;
    [SerializeField] private TMP_InputField passwordField;
    [SerializeField] private Button submitButton;
    [SerializeField] private AppData appData;
    private string userData;
    public void Start()
    {
        nameField.contentType = TMP_InputField.ContentType.EmailAddress;
        passwordField.contentType = TMP_InputField.ContentType.Password;

        if (appData.GetFlashMsg() != ", ")
        {
            string flashMsgStatus = appData.GetFlashMsg().Split(",")[0];
            string flashMsg = appData.GetFlashMsg().Split(",")[1];
            if (flashMsgStatus == "success")
            {
                errorMsg.color = Color.green;
                errorMsg.text = flashMsg;
                appData.SetFlashMsg("empty", "");
            }
            else
            {
                errorMsg.color = Color.black;
                errorMsg.text = "Welkom";
                appData.SetFlashMsg("empty", "");
            }
        }
    }

    public void OpenRegistration()
    {
        SceneManager.LoadScene("RegistrationScreen");
    }

    public void CallLogin()
    {
        StartCoroutine(LoginUser());
    }

    IEnumerator LoginUser()
    {
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
                if (responseTextSplitter.Length > 2) 
                {
                    userData = responseTextSplitter[^1];
                }

                string responseStatus = responseTextSplit[1];
                string responseErrorMsg = responseTextSplit[3];

                if (responseStatus == "success")
                {
                    int userId = int.Parse(userData.Split(",")[0].Split(":")[1]);
                    string fullName = userData.Split(",")[5].Split('"')[3];
                    string function = userData.Split(",")[4].Split('"')[3];

                    //saves the users data localy
                    appData.SetLoginId(userId);
                    appData.SetUserFullName(fullName);
                    appData.SetUserFunction(function);

                    // Login successful
                    /*DBManager.username = nameField.text;*/
                    Debug.Log("Login successful!");
                    UnityEngine.SceneManagement.SceneManager.LoadScene("HomeScreen");
                }
                else
                {
                    // Login failed
                    Debug.LogError("Login failed: " + responseErrorMsg);
                    errorMsg.color = Color.red;
                    errorMsg.text = responseErrorMsg;
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
        submitButton.interactable = true;
    }
    
}
