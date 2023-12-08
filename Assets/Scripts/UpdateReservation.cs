using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class UpdateReservation : MonoBehaviour
{
    [SerializeField] private AppData appData;
    private string[] allReservations = new string[0];
    public void GetReservationData()
    {
        StartCoroutine(GetReservations());
    }

    IEnumerator GetReservations()
    {
        using (UnityWebRequest www = UnityWebRequest.Get("http://localhost/sqlconnect/selectReservations.php"))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                string responseText = www.downloadHandler.text;
                string[] responseStatusErrorSplit = responseText.Split('"');
                string responseStatus = responseStatusErrorSplit[1];
                string responseErrorMsg = responseStatusErrorSplit[3];

                if (responseStatus == "success")
                {
                    string[] AllRawStartTimeData = responseText.Split('"');
                    
                    foreach (string word in AllRawStartTimeData)
                    {
                        //Checks for empty spaces 
                        if (word.Length > 0)
                        {
                            //Gets first value 
                            string firstLetter = word[0].ToString();
                            if (int.TryParse(firstLetter, out int reservationInt))
                            {
                                string[] newReservations = new string[allReservations.Length + 1];
                                Array.Copy(allReservations, newReservations, allReservations.Length);
                                newReservations[allReservations.Length] = word;
                                allReservations = newReservations;
                            }
                        }
                    }

                    appData.SetAllReservation(allReservations);
                }
                else
                {
                    // Login failed
                    Debug.LogError("error: " + responseErrorMsg);
                }
            }
            else
            {
                // Handle network errors
                Debug.LogError("Network error: " + www.error);
            }
        }
    }
}
