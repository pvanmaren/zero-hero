using UnityEngine;
[CreateAssetMenu(fileName ="AppData", menuName ="Appdata/UserData")]
public class AppData : ScriptableObject 
{
    public int loginId = 0;
    public string errorMsg = "";
    public bool openMenu = false;
    public int viewReservation;

    //login
    public int GetLoginId()
    {
        return loginId;
    }

    public void SetLoginId(int loginIdInt)
    {
        loginId = loginIdInt;

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


}
