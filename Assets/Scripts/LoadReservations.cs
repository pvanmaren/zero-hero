using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LoadReservations : MonoBehaviour
{
    private string credentialPath;
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

    void Start()
    {
        // Path to the json file
        credentialPath = Application.dataPath + "/credentials/reservations.json";
        AllReservation();
    }

    void AllReservation()
    {
        string JSONstring = File.ReadAllText(credentialPath);
        Reservations reservations = JsonUtility.FromJson<Reservations>(JSONstring);

        // Loops through the json objects
        foreach (Reservation reservation in reservations.reservations)
        {
            /*previousId = reservation.id;*/
            print(reservation.startDateTime);
        }
    }

}
