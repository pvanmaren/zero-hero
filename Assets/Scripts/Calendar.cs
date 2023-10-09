using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Globalization;
using TMPro;

public class Calendar : MonoBehaviour
{
    [SerializeField] private ReservationsInsert reservationsInsert;
    [SerializeField] private TMP_Text monthText;
    [SerializeField] private TMP_Text yearText;
    [SerializeField] private TMP_Text date;
    [SerializeField] private TMP_Text promptDate;
    [SerializeField] private TMP_Text promptTime;    
    [SerializeField] private TMP_Text ReserveDate;
    [SerializeField] private TMP_Text ReserveTime;
    [SerializeField] private TMP_InputField startLocationInput;
    [SerializeField] private TMP_InputField endLocationInput;
    [SerializeField] private Button promptYes;
    [SerializeField] private Button promptNo;
    [SerializeField] private Button reserveButton;
    [SerializeField] private Button[] dayButtons;
    [SerializeField] private Button[] timeButtons;
    [SerializeField] private AppData appData;
    [SerializeField] private GameObject exitButton;
    [SerializeField] private GameObject calender;
    [SerializeField] private GameObject time;
    [SerializeField] private GameObject confirmationPrompt;
    [SerializeField] private GameObject locations;
    private List<Button> reservedTimeButton = new List<Button>();
    private int currentMonth;
    private int currentDay;
    private int currentYear;
    private int selectedDay;
    private string plannedDate;
    private string plannedTime;
    private string[] dateTime;
    private string[] reservedTime;
    private string[] allReservations;
    private void Start()
    {
        allReservations = appData.GetAllReservation();
        // Set current day, month and year
        currentMonth = System.DateTime.Now.Month;
        currentYear = System.DateTime.Now.Year;
        currentDay = System.DateTime.Now.Day;
        // Opens the calendar display
        OpenCalendar();
    }
    public void GoToHome()
    {
        SceneManager.LoadScene("HomeScreen");
    }
    public void OpenCalendar()
    {
        //reset variables
        reservedTimeButton.Clear();

        // Activates gameobjects
        calender.SetActive(true);
        exitButton.SetActive(true);

        // Deactivates gameobjects
        time.SetActive(false);
        date.gameObject.SetActive(false);
        confirmationPrompt.SetActive(false);
        locations.SetActive(false);
        UpdateCalendar();
    }
    public void NextMonth()
    {
        // Increment the current month
        currentMonth++;
        if (currentMonth > 12)
        {
            currentMonth = 1;
            currentYear++;
        }

        // Update calendar display
        UpdateCalendar();
    }
    public void PreviousMonth()
    {
        // Decrement the current month
        currentMonth--;
        if (currentMonth < 1)
        {
            currentMonth = 12;
            currentYear--;
        }

        // Update calendar display
        UpdateCalendar();
    }
    private void UpdateCalendar()
    {
        date.text = " ";
        appData.SetViewReservation(0);

        // Update month and year text
        monthText.text = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(currentMonth);
        yearText.text = currentYear.ToString();
        // Get the first day of the current month
        System.DateTime firstDayOfMonth = new System.DateTime(currentYear, currentMonth, 1);
        int startDay = (int)firstDayOfMonth.DayOfWeek;
        // Adjust the start day to be one day earlier
        startDay--;
        if (startDay < 0)
        {
            startDay = 6; // Sunday
        }
        // Get the number of days in the current month
        int numDays = System.DateTime.DaysInMonth(currentYear, currentMonth);
        // Update day texts
        for (int i = 0; i < dayButtons.Length; i++)
        {

            // The text that displays the days
            TMP_Text dayDisplay = dayButtons[i].GetComponentInChildren<TMP_Text>();
            if (i >= startDay && i < startDay + numDays)
            {
                int day = i - startDay + 1;
                dayDisplay.text = day.ToString();
                dayDisplay.gameObject.SetActive(true);
                // This if statement makes the current day turn blue
                if (day == currentDay)
                {
                    dayDisplay.color = Color.blue;
                }
                foreach (string reservation in allReservations)
                {
                    dateTime = reservation.Split("-");
                    if (currentMonth == int.Parse(dateTime[1]))
                    {
                        if (day == int.Parse(dateTime[0]))
                        {
                            dayDisplay.color = Color.red;
                        }
                        if (day == currentDay)
                        {
                            if (currentDay == int.Parse(dateTime[0]))
                            {
                                dayDisplay.color = Color.magenta;
                            }
                        }
                    }
                }

                dayButtons[i].onClick.AddListener(() => OpenTime(day, CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(currentMonth)));
                
                if (day < currentDay)
                {
                    dayDisplay.color = Color.red;
                    dayButtons[i].onClick.RemoveAllListeners();
                }
                
            }
            // Checks if it's saturday or sunday
            if (i % 7 == 6 || i % 7 == 5)
            {
                dayDisplay.color = Color.red;
                dayButtons[i].onClick.RemoveAllListeners();
            }

        }
    }
    public void OpenTime(int clickedDay, string month)
    {
        exitButton.SetActive(false);
        appData.SetViewReservation(clickedDay);
        // Deactivates gameobjects
        calender.SetActive(false);
        confirmationPrompt.SetActive(false);
        locations.SetActive(false);

        // Activates gameobjects
        time.SetActive(true);
        date.gameObject.SetActive(true);

        // Creates a string with the current date
        string currentDate = clickedDay.ToString() + " " + month.ToUpper();
        date.text = currentDate;
        selectedDay = clickedDay;
        UpdateTime(clickedDay, currentDate);
    }
    private void UpdateTime(int day, string date)
    {
        DateTime startTime = DateTime.Today.AddHours(8);
        int currentHour = DateTime.Now.Hour;
        List<DateTime> timeSlots = new List<DateTime>();
        while (startTime.Hour < 19)
        {
            timeSlots.Add(startTime);
            startTime = startTime.AddMinutes(60);
        }

        for (int i = 0; i < timeButtons.Length; i++)
        {

            TMP_Text startReservationTime = timeButtons[i].transform.Find("Text (TMP)").GetComponent<TMP_Text>();
            TMP_Text endReservationTime = timeButtons[i].transform.Find("Text (TMP) (1)").GetComponent<TMP_Text>();
            startReservationTime.text = timeSlots[i].ToString("HH:mm");
            endReservationTime.text = timeSlots[i + 1].ToString("HH:mm");
            startReservationTime.color = Color.black;
            endReservationTime.color = Color.black;
            string clickedTime = timeSlots[i].ToString("HH:mm") + " - " + timeSlots[i+1].ToString("HH:mm");
            timeButtons[i].onClick.AddListener(() => OpenConfirmation(date, clickedTime));
            foreach (string reservation in allReservations)
            {
                dateTime = reservation.Split("-");
                reservedTime = dateTime[2].Split(" ");
                if (day == int.Parse(dateTime[0]))
                {
                    if (timeSlots[i].ToString("HH:mm") == reservedTime[1])
                    {
                        startReservationTime.color = Color.red;
                        endReservationTime.color = Color.red;
                        timeButtons[i].onClick.RemoveAllListeners();
                    }

                }
            }

            if (day == currentDay)
            {
                if (int.Parse(timeSlots[i].ToString("HH:mm").Split(":")[0]) < currentHour)
                {
                    startReservationTime.color = Color.red;
                    endReservationTime.color = Color.red;
                    timeButtons[i].onClick.RemoveAllListeners();

                }
            }


        }
    }
    private void OpenConfirmation(string clickedDate, string clickedTime)
    {
        // Deactivates gameobjects
        time.SetActive(false);
        calender.SetActive(false);
        locations.SetActive(false);
        exitButton.SetActive(false);
        // Activates gameobjects
        confirmationPrompt.SetActive(true);

        UpdateConfirmation(clickedDate, clickedTime);
    }
    private void UpdateConfirmation(string plannedDate, string plannedTime)
    {
        promptDate.text = plannedDate;
        promptTime.text = plannedTime;

        promptYes.onClick.AddListener(() => OpenLocation(plannedDate, plannedTime));
        promptNo.onClick.AddListener(() => {
            calender.SetActive(false);
            confirmationPrompt.SetActive(false);
            locations.SetActive(false);
            time.SetActive(true); 
        });

    }
    private void OpenLocation(string pickedDate, string pickedTime)
    {
        // Deactivates gameobjects
        calender.SetActive(false);
        confirmationPrompt.SetActive(false);
        time.SetActive(false);
        exitButton.SetActive(false);

        // Activates gameobjects
        locations.SetActive(true);

        plannedDate = pickedDate;
        plannedTime = pickedTime;

        reserveButton.onClick.AddListener(Reserve);
        UpdateLocations();
    }
    private void UpdateLocations()
    {
        ReserveDate.text = plannedDate;
        ReserveTime.text = plannedTime;
    }
    private void Reserve()
    {
        string startDateTime = selectedDay + "-"+ currentMonth + "-" + currentYear + " " + plannedTime.Split("-")[0];
        string endDateTime = selectedDay + "-"+ currentMonth + "-" + currentYear + " " + plannedTime.Split("-")[1];
        reservationsInsert.CallReserve(appData.GetLoginId(), startLocationInput.text, endLocationInput.text, startDateTime, endDateTime);
        appData.SetFlashMsg("success","Gerserveerd voor " + selectedDay + "-" + currentMonth + "-" + currentYear + " " + plannedTime.Split("-")[0] + " - " + plannedTime.Split("-")[1]);
        
        SceneManager.LoadScene("HomeScreen");
    }
}
