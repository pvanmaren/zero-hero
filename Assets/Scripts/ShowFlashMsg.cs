using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ShowFlashMsg : MonoBehaviour
{
    [SerializeField] private AppData appData;
    [SerializeField] private TMP_Text errorMsg;
    public void FlashMsg()
    {
        if (appData.GetFlashMsg().Split(",")[0] != "empty")
        {
            string flashMsgStatus = appData.GetFlashMsg().Split(",")[0];
            string flashMsg = appData.GetFlashMsg().Split(",")[1];
            if (flashMsgStatus == "success")
            {
                errorMsg.color = Color.green;
                errorMsg.text = flashMsg;
                appData.SetFlashMsg("empty", "");
            }
            else
            {
                errorMsg.color = Color.red;
                errorMsg.text = flashMsg;
                appData.SetFlashMsg("empty", "");
            }
        }
        else
        {
            errorMsg.color = Color.black;
            errorMsg.text = "";
        }
    }
}
