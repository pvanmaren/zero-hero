using System.Collections;
using UnityEngine; 
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;

public class Server : MonoBehaviour
{
    [SerializeField] TMP_InputField email;
    [SerializeField] TMP_InputField password;
    [SerializeField] TMP_Text errormsg;

    [SerializeField] Button loginButton;

    [SerializeField] string url;

    WWWForm form;

    public void OnLoginButtonClicked()
    {
        StartCoroutine(Login ());
    }

    IEnumerator Login ()
    {
        form = new WWWForm();

        form.AddField("email", email.text);
        form.AddField("password", password.text);

        using (UnityWebRequest www = UnityWebRequest.Post(url, form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                //TODO::het checken van een return voor errors zodat ik weet of de gebruiker ingelogd is
                Debug.Log("Logged in");
                Debug.Log(www.error);
            }
        }
    }
}
