using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;

public class ReservationsInsert : MonoBehaviour
{
    public void CallReserve(int userId, string pointA, string pointB, string startDateTime, string endDateTime)
    {
        StartCoroutine(SetReservation(userId, pointA, pointB, startDateTime, endDateTime));
    }

    private IEnumerator SetReservation(int userId, string pointA, string pointB, string startDateTime, string endDateTime)
    {
        WWWForm form = new WWWForm();
        form.AddField("userId", userId);
        form.AddField("pointA", pointA);
        form.AddField("pointB", pointB);
        form.AddField("startDateTime", startDateTime);
        form.AddField("endDateTime", endDateTime);

        UnityWebRequest www = UnityWebRequest.Post("http://localhost/sqlconnect/insertReservations.php", form);

        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.Success)
        {
            string responseText = www.downloadHandler.text;
            print(responseText);
            Debug.Log("Successfull reservation");
        }
        else
        {
            Debug.Log("It failed. Error: " + www.error);
        }
    }

}