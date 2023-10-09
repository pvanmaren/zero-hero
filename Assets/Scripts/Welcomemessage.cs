using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Welcomemessage : MonoBehaviour
{
    [SerializeField] private TMP_Text nameDisplay;
    [SerializeField] private UpdateReservation updateReservation;
    [SerializeField] private AppData appData;
    [SerializeField] private ShowFlashMsg flashMsg;

    
   
    void Start()
    {
        flashMsg.FlashMsg();
        nameDisplay.text = appData.GetUserFullName();
        updateReservation.GetReservationData();
    }
}
