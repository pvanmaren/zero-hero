using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;

public class ReservationHistory : MonoBehaviour
{
    [SerializeField] private AppData appData;
    [SerializeField] private GameObject historyPrefab;

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

    // Start is called before the first frame update
    void Start()
    {
        // Path to the json file
        credentialPath = Application.dataPath + "/credentials/reservations.json";
        userId = appData.GetLoginId();
        string JSONstring = File.ReadAllText(credentialPath);
        Reservations reservations = JsonUtility.FromJson<Reservations>(JSONstring);
        // Loops through the json objects
        foreach (Reservation reservation in reservations.reservations)
        {
            if(reservation.user_id == userId)
            {
                GameObject currentPrefab = Instantiate(historyPrefab, transform.position, Quaternion.identity);
                // Find all TMP_Text components in the instantiated prefab
                TMP_Text[] textComponents = currentPrefab.GetComponentsInChildren<TMP_Text>();
                Debug.Log("Number of TMP_Text components: " + textComponents.Length);

                /*print(reservation.ToString());*/

            }
        }
    }

}
