using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Logout : MonoBehaviour
{
    public AppData appData;
    [SerializeField] private Button logoutButton;
    // Start is called before the first frame update
    void Start()
    {
        logoutButton.onClick.AddListener(LogoutUser);
    }

    private void LogoutUser()
    {
        appData.SetLoginId(0);
        SceneManager.LoadScene("LoginScreen", LoadSceneMode.Single);
    }

   
}
