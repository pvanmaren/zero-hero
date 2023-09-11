using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;

public class ReservationHistory : MonoBehaviour
{
    [SerializeField] private AppData appData;
    /*    [SerializeField] private GameObject currentReservation;
        [SerializeField] private GameObject prevReservation;*/

    [SerializeField] private TMP_Text currentReservationDisplayDate;
    [SerializeField] private TMP_Text currentReservationDisplayTime;
    [SerializeField] private TMP_Text currentReservationDisplayPointA;
    [SerializeField] private TMP_Text currentReservationDisplayPointB;

    [SerializeField] private TMP_Text nextReservationDisplayDate;
    [SerializeField] private TMP_Text nextReservationDisplayTime;
    [SerializeField] private TMP_Text nextReservationDisplayPointA;
    [SerializeField] private TMP_Text nextReservationDisplayPointB;

    private List<int> userReservations = new List<int>();

    private string credentialPath;
    private int userId;

    [System.Serializable]
    private class Reservation
    {
        public int id;
        public string pointA;
        public string pointB;
        public string startDateTime;
        public string endDateTime;
        public bool paused;
        public int user_id;
    }

    [System.Serializable]
    private class Reservations
    {
        public Reservation[] reservations;
    }

    private Reservations allReservation;

    // Start is called before the first frame update
    void Start()
    {
        // Path to the json file
        credentialPath = Application.dataPath + "/credentials/reservations.json";
        userId = appData.GetLoginId();
        string JSONstring = File.ReadAllText(credentialPath);
        Reservations reservations = JsonUtility.FromJson<Reservations>(JSONstring);

        allReservation = reservations;
        foreach(Reservation reservation in allReservation.reservations)
        {
           if (reservation.user_id == userId)
            {
                userReservations.Add(reservation.id);
            }
        }
        CurrentReservation();
    }

    private void CurrentReservation()
    {
        DateTime currentDateTime = DateTime.Now;
        string currentDateTimeString = currentDateTime.ToString();
        string currentDate = currentDateTimeString.Split(" ")[0].Replace("/", "-");
        print(currentDate);
        foreach (int userReservation in userReservations)
        {
            foreach (Reservation reservation in allReservation.reservations)
            {
                if (userReservation == reservation.id)
                {
                    string reservationDate = reservation.startDateTime.Split(" ")[0];
                    string reservationTime = reservation.startDateTime.Split(" ")[1] + " - " + reservation.endDateTime.Split(" ")[2];

                    string reservationDay = reservationDate.Split("-")[0];
                    string reservationMonth = reservationDate.Split("-")[1];

                    if (currentDate == reservationDate)
                    {
                        currentReservationDisplayDate.text = reservationDate;
                        currentReservationDisplayTime.text = reservationTime;
                        currentReservationDisplayPointA.text = reservation.pointA;
                        currentReservationDisplayPointB.text = reservation.pointB;
                        break;
                    }
                    else if (currentDate.Split("-")[1] == reservationMonth)
                    {
                        print(reservationDay);

                        if (int.Parse(currentDate.Split("-")[0]) < int.Parse(reservationDay))
                        {
                            print(reservationDate);
                            currentReservationDisplayDate.text = reservationDate;
                            currentReservationDisplayTime.text = reservationTime;
                            currentReservationDisplayPointA.text = reservation.pointA;
                            currentReservationDisplayPointB.text = reservation.pointB;
                            break;
                        }
                    }
                }
            }
        }
    }
}
