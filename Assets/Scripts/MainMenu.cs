using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    public void GoToRegister()
    {
        SceneManager.LoadScene(6);
    }

    public void GoToLogin()
    {
        SceneManager.LoadScene(5);
    }
}
