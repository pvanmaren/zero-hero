using System.IO;
using UnityEngine;
using TMPro;

public class LoadPersonalInfo : MonoBehaviour
{
    public AppData appData;
    private string JSONpath;
    [SerializeField] private TMP_Text fullName;
    [SerializeField] private TMP_Text location;
    [SerializeField] private TMP_Text function;
    [SerializeField] private TMP_Text totalRides;

    [System.Serializable]
    //Object van een enkele user
    private class User
    {
        public int id;
        public string email;
        public string password;
        public string name;
        public string location;
        public string function;
        public int totalKm;
        public int totalRides;
    }
    [System.Serializable]
    private class Users
    {
        //array van users
        public User[] users;
    }

    public void ShowPersonalInfo()
    {
        int userId = appData.GetLoginId() - 1;
        print(userId);
        JSONpath = Application.dataPath + "/credentials/users.json";
        string JSONstring = File.ReadAllText(JSONpath);
        Users users = JsonUtility.FromJson<Users>(JSONstring);
        User user = users.users[userId];

        fullName.text = user.name;
        location.text = user.location;
        function.text = user.function;
        totalRides.text = user.totalRides.ToString();

    }



    
}
