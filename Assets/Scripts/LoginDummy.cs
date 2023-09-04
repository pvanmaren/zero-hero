using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LoginDummy : MonoBehaviour
{
    public AppData appData;
    [SerializeField] private TMP_InputField emailInput;
    [SerializeField] private TMP_InputField passwordInput;
    [SerializeField] private Button loginButton;
    [SerializeField] private GameObject displayErrorContainer;
    [SerializeField] private TMP_Text errorMsg;

    private string credentialPath;
    public bool loggedIn;

    [System.Serializable]
    //Object van een enkele user
    private class User
    {
        public int id;
        public string email;
        public string password;
        public string name;
        public string location;
        public string function;
    }

    [System.Serializable]
    //Objects van alle users
    private class Users
    {
        //array van users
        public User[] users;
    }

    // Start is called before the first frame update
    void Start()
    {
        emailInput.contentType = TMP_InputField.ContentType.Standard;
        passwordInput.contentType = TMP_InputField.ContentType.Password;
        if (appData.GetErrorMsg() != "")
        {
            displayErrorContainer.SetActive(true);
            errorMsg.text = appData.GetErrorMsg();
            appData.SetErrorMsg("");
        } else
        {
            displayErrorContainer.SetActive(false);
        }

        print(appData.GetErrorMsg());

        credentialPath = Application.dataPath + "/credentials/users.json";
        //Kijkt of er op de knop gedrukt is
        loginButton.onClick.AddListener(Login);
    }
    void Login()
    {
        displayErrorContainer.SetActive(false);
        loggedIn = false;
        string JSONstring = File.ReadAllText(credentialPath);
        Users users = JsonUtility.FromJson<Users>(JSONstring);
        foreach(User user in users.users)
        {
            if (emailInput.text == user.email && passwordInput.text == user.password)
            {
                Debug.Log("Logged in");
                loggedIn = true;
                appData.SetLoginId(user.id);
            }
        }
        if (loggedIn)
        {
            appData.SetOpenMenu(false);
            SceneManager.LoadScene("HomeScreen", LoadSceneMode.Single);
            
        }
        else
        {
           Debug.LogError("Failed login");

           displayErrorContainer.SetActive(true);
           errorMsg.text = "Failed login";
        }
    }
}
