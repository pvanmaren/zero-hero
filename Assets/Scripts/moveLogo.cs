using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class moveLogo : MonoBehaviour
{
    private Scene currentScene;
    private string sceneName;
    private float aValue;
    public Image logo;
    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;

        if (sceneName == "StartScreen")
        {
            aValue = 1;
        }
        else if (sceneName == "LoginScreen" || sceneName == "RegistrationScreen")
        {
            aValue = 0;

        }

    }

    void Update()
    {
        logo = logo.GetComponent<Image>();

        if (sceneName == "StartScreen")
        {
            aValue -= Time.deltaTime;
            logo.color = new Color(255, 255, 255, aValue);
            if (aValue < 0)
            {
                SceneManager.LoadScene("LoginScreen", LoadSceneMode.Single);
            }
        }
        else if (sceneName == "LoginScreen" || sceneName == "RegistrationScreen")
        {
            aValue += Time.deltaTime;
            logo.color = new Color(255, 255, 255, aValue);
        }
        
    }
}
