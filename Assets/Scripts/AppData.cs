using UnityEngine;
[CreateAssetMenu(fileName ="AppData", menuName ="Appdata/UserData")]
public class AppData : ScriptableObject 
{
    public int loginId = 0;
    public string userFullName = "";
    public string userFunction = "";
    public string errorMsg = "";
    public bool openMenu = false;
    public int viewReservation;
    public string[] allReservations;
    public int totalReservations;

    //login
    public int GetLoginId()
    {
        return loginId;
    }

    public void SetLoginId(int loginIdInt)
    {
        loginId = loginIdInt;
    }
    
    public int GetTotalReservations()
    {
        return totalReservations;
    }

    public void SetTotalReservations(int reservationInt)
    {
        totalReservations = reservationInt;
    }

    //users full name
    public string GetUserFullName()
    {
        return userFullName;
    }

    public void SetUserFullName(string fullname)
    {
        userFullName = fullname;

    }
    //users function
    public string GetUserFunction()
    {
        return userFunction;
    }

    public void SetUserFunction(string fnct)
    {
        userFunction = fnct;

    }

    //error message
    public string GetErrorMsg()
    {
        return errorMsg;
    }

    public void SetErrorMsg(string errorString)
    {
        errorMsg = errorString;

    }
    
    //open menu
    public bool GetOpenMenu()
    {
        return openMenu;
    }

    public void SetOpenMenu(bool menuIsOpen)
    {
        openMenu = menuIsOpen;

    }
    //open menu
    public int GetViewReservation()
    {
        return viewReservation;
    }

    public void SetViewReservation(int reservation)
    {
        viewReservation = reservation;

    }

    //array for all reservations
    public string[] GetAllReservation()
    {
        return allReservations;
    }

    public void SetAllReservation(string[] reservation)
    {
        allReservations = reservation;

    }

    public void ClearAllReservation()
    {
        allReservations = new string[0];

    }


}
