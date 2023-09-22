using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Welcomemessage : MonoBehaviour
{
    [SerializeField] private TMP_Text nameDisplay;
    [SerializeField] private AppData appData;
    void Start()
    {
        nameDisplay.text = appData.GetUserFullName();
    }
}
