using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlanReservation : MonoBehaviour
{
    private string credentialPath;
    private int previousId;
    public AppData appData;

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
        newReservation();
    }

    void newReservation()
    {
        string JSONstring = File.ReadAllText(credentialPath);
        Reservations reservations = JsonUtility.FromJson<Reservations>(JSONstring);

        // Loops through the json objects
        foreach (Reservation reservation in reservations.reservations)
        {
            previousId = reservation.id;
        }

        // Calculates new id 
        int newId = previousId + 1;

        // New Reservation
        Reservation newReservation = new Reservation
        {
            id = newId,
            pointA = "Tinwerf 14",
            pointB = "GLR",
            startDateTime = "21-08-2023 08:30",
            endDateTime = "22-08-2023 08:30",
            paused = true,
            user_id = appData.GetLoginId()
        };

        // Makes the array bigger by resizing it
        Array.Resize(ref reservations.reservations, reservations.reservations.Length + 1);
        // Places the new reservation
        reservations.reservations[^1] = newReservation;

        // Convert the updated list or array to JSON
        string updatedJsonData = JsonUtility.ToJson(reservations, true);

        // Write the updated JSON data back to the file
        File.WriteAllText(credentialPath, updatedJsonData);
    }
}
