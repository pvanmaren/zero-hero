using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class OpenRideDropdown : MonoBehaviour
{
    [SerializeField] private GameObject dropdownMenu;
    [SerializeField] private GameObject dropdownButtonOn;
    [SerializeField] private GameObject dropdownButtonOff;


    public void OpenDropdown()
    {
        dropdownButtonOn.SetActive(false);

        dropdownButtonOff.SetActive(true);
        dropdownMenu.SetActive(true);
    }
    public void CloseDropdown()
    {
        dropdownButtonOff.SetActive(false);
        dropdownMenu.SetActive(false);
        dropdownButtonOn.SetActive(true);
    }
}
