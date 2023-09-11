using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NavigateMenu : MonoBehaviour
{
    public AppData appData;
    [SerializeField] private Button profileButton;
    [SerializeField] private Button reservationButton;
    [SerializeField] private Button personalInfoButton;
    [SerializeField] private Button routeHistoryButton;
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject profileButtonGO;
    [SerializeField] private GameObject reservationButtonGO;
    [SerializeField] private GameObject centerButtonGO;
    [SerializeField] private GameObject personalInfoScreen;
    [SerializeField] private GameObject routeHistoryScreen;

    private void Start()
    {
        if (appData.GetLoginId() == 0)
        {
            appData.SetErrorMsg("Niet ingelogd");
            SceneManager.LoadScene("LoginScreen", LoadSceneMode.Single);
        }
        profileButton.onClick.AddListener(OpenMenu);
        reservationButton.onClick.AddListener(OpenReservations);
        personalInfoButton.onClick.AddListener(OpenPersonalInfo);
        routeHistoryButton.onClick.AddListener(OpenRouteHistory);
    }
    public void OpenMenu()
    {
        profileButtonGO.SetActive(false);
        reservationButtonGO.SetActive(false);
        centerButtonGO.SetActive(false);
        personalInfoScreen.SetActive(false);
        routeHistoryScreen.SetActive(false);
        //Toont het menu
        menu.SetActive(true);
        appData.SetOpenMenu(true);
    }
    public void OpenReservations()
    {
        SceneManager.LoadScene("ReservationScreen", LoadSceneMode.Single);

    }
    public void CloseMenu()
    {
        menu.SetActive(false);
        personalInfoScreen.SetActive(false);
        routeHistoryScreen.SetActive(false);
        //Toont de MainUI
        profileButtonGO.SetActive(true);
        reservationButtonGO.SetActive(true);
        centerButtonGO.SetActive(true);
        appData.SetOpenMenu(false);
    }
    private void OpenPersonalInfo()
    {
        menu.SetActive(false);
        profileButtonGO.SetActive(false);
        reservationButtonGO.SetActive(false);
        centerButtonGO.SetActive(false);
        //Toont de personal info screen
        personalInfoScreen.SetActive(true);
    }
    private void OpenRouteHistory()
    {
        menu.SetActive(false);
        profileButtonGO.SetActive(false);
        reservationButtonGO.SetActive(false);
        centerButtonGO.SetActive(false);
        personalInfoScreen.SetActive(false);
        //Toont de ride info screen
        routeHistoryScreen.SetActive(true);
    }
}
