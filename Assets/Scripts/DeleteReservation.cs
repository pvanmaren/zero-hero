using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class DeleteReservation : MonoBehaviour
{
    [SerializeField] private AppData appData;

    public void callDeletion(string id){
        StartCoroutine(DeleteMyReservation(id));    
    }

    private IEnumerator DeleteMyReservation(string id)
    {
        WWWForm form = new WWWForm();
        form.AddField("id", id);

        UnityWebRequest www = UnityWebRequest.Post("http://localhost/sqlconnect/deleteReservation.php", form);

        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.Success)
        {
            string responseText = www.downloadHandler.text;
            string[] responseStatusErrorSplit = responseText.Split('"');
            string responseStatus = responseStatusErrorSplit[1];
            string responseErrorMsg = responseStatusErrorSplit[3];

            if (responseStatus == "success")
            {
                appData.SetFlashMsg(responseStatus, "Reservering verwijderd");
                SceneManager.LoadScene("HomeScreen");

            } 


        }
        else
        {
            Debug.Log("It failed. Error: " + www.error);
        }
    }
}
