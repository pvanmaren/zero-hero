using System.IO;
using UnityEngine;
using TMPro;

public class LoadPersonalInfo : MonoBehaviour
{
    public AppData appData;
    [SerializeField] private TMP_Text fullName;
    [SerializeField] private TMP_Text location;
    [SerializeField] private TMP_Text function;
    [SerializeField] private TMP_Text totalRides;
    public void ShowPersonalInfo()
    {
        fullName.text = appData.GetUserFullName();
        function.text = appData.GetUserFunction();
        totalRides.text = "0";// Here comes the amount of reservations
    }
}
