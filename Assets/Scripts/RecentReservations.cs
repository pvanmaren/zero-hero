using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;

public class RecentReservations : MonoBehaviour
{
    [SerializeField] private AppData appData;
    [SerializeField] private DeleteReservation deleteReservation;

    [SerializeField] private TMP_Text upcommingReservationDisplayDate;
    [SerializeField] private TMP_Text upcommingReservationDisplayTime;
    [SerializeField] private TMP_Text upcommingReservationDisplayPointA;
    [SerializeField] private TMP_Text upcommingReservationDisplayPointB;

    [SerializeField] private TMP_Text nextReservationDisplayDate;
    [SerializeField] private TMP_Text nextReservationDisplayTime;
    [SerializeField] private TMP_Text nextReservationDisplayPointA;
    [SerializeField] private TMP_Text nextReservationDisplayPointB;

    [SerializeField] private Button upcommingReservationDeleteButton;
    [SerializeField] private Button nextReservationDeleteButton;

    

    private void Start()
    {
        ViewReservations();
    }
    public void ViewReservations()
    {
        StartCoroutine(SeeReservations());
    }

    private IEnumerator SeeReservations()
    {
        WWWForm form = new WWWForm();
        form.AddField("userId", appData.GetLoginId());

        UnityWebRequest www = UnityWebRequest.Post("http://localhost/sqlconnect/recentReservations.php", form);

        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.Success)
        {
            string responseText = www.downloadHandler.text;
            string[] responseStatusErrorSplit = responseText.Split('"');
            string responseStatus = responseStatusErrorSplit[1];
            string responseErrorMsg = responseStatusErrorSplit[3];

            if (responseStatus == "success")
            {
                string[] dataSplitter = responseText.Split("{");

                string upcommingDataRaw = dataSplitter[2];
             
                string id = upcommingDataRaw.Split('"')[3];
                string upcommingPointA = upcommingDataRaw.Split('"')[7];
                string upcommingPointB = upcommingDataRaw.Split('"')[11];
                string upcommingDate = upcommingDataRaw.Split('"')[15].Split(" ")[0];
                string upcommingTime = upcommingDataRaw.Split('"')[15].Split(" ")[1];

                upcommingReservationDisplayDate.text = upcommingDate;
                upcommingReservationDisplayTime.text = upcommingTime;
                upcommingReservationDisplayPointA.text = upcommingPointA;
                upcommingReservationDisplayPointB.text = upcommingPointB;
                upcommingReservationDeleteButton.onClick.AddListener(() => deleteReservation.callDeletion(id));

                if (dataSplitter.Length > 3)
                {
                    string nextDataRaw = dataSplitter[3];
                    string nextId = nextDataRaw.Split('"')[3];
                    string nextPointA = nextDataRaw.Split('"')[7];
                    string nextPointB = nextDataRaw.Split('"')[11];
                    string nextDate = nextDataRaw.Split('"')[15].Split(" ")[0];
                    string nextTime = nextDataRaw.Split('"')[15].Split(" ")[1];

                    nextReservationDisplayDate.text = nextDate;
                    nextReservationDisplayTime.text = nextTime;
                    nextReservationDisplayPointA.text = nextPointA;
                    nextReservationDisplayPointB.text = nextPointB;
                    nextReservationDeleteButton.onClick.AddListener(() => deleteReservation.callDeletion(nextId));
                }

                
            }
            else
            {
                print(responseErrorMsg);
            }
        }
        else
        {
            Debug.Log("It failed. Error: " + www.error);
        }
    }
}
