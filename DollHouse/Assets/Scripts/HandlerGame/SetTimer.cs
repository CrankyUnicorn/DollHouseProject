using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTimer
{

    private int monthInt = 1;
    private int weekDayInt = 0;
    private int daysDiference = -1;//must be -1 because otherwise it will move up WEEKDAY


    //TIME SETTER-------------------------------------------------
    public void SetTime()  //Maps time and corrects incorrect data
    {
        if (ContainerStory.ins.actStory.ActYear < 1) { ContainerStory.ins.actStory.ActYear = 1; }//dont trust the user
        if (ContainerStory.ins.actStory.ActDay < 1) { ContainerStory.ins.actStory.ActDay = 1; }//dont trust the user

        //get MONTH number 1-12 and limit max day if story writer fails
        if (ContainerStory.ins.actStory.ActMonth == ContainerStory.ins.actStory.MonthNames[0])
        {
            monthInt = 1;
            if (ContainerStory.ins.actStory.ActDay > 31) { ContainerStory.ins.actStory.ActDay = 31; }
        }
        else if (ContainerStory.ins.actStory.ActMonth == ContainerStory.ins.actStory.MonthNames[1])
        {
            monthInt = 2;
            if (ContainerStory.ins.actStory.ActYear % 400 == 0)
            {
                if (ContainerStory.ins.actStory.ActDay > 29) { ContainerStory.ins.actStory.ActDay = 29; }
            }
            else if (ContainerStory.ins.actStory.ActYear % 100 == 0)
            {
                if (ContainerStory.ins.actStory.ActDay > 28) { ContainerStory.ins.actStory.ActDay = 28; }
            }
            else if (ContainerStory.ins.actStory.ActYear % 4 == 0)
            {
                if (ContainerStory.ins.actStory.ActDay > 29) { ContainerStory.ins.actStory.ActDay = 29; }
            }
            else
            {
                if (ContainerStory.ins.actStory.ActDay > 28) { ContainerStory.ins.actStory.ActDay = 28; }
            }

        }
        else if (ContainerStory.ins.actStory.ActMonth == ContainerStory.ins.actStory.MonthNames[2])
        {
            monthInt = 3;
            if (ContainerStory.ins.actStory.ActDay > 31) { ContainerStory.ins.actStory.ActDay = 31; }
        }
        else if (ContainerStory.ins.actStory.ActMonth == ContainerStory.ins.actStory.MonthNames[3])
        {
            monthInt = 4;
            if (ContainerStory.ins.actStory.ActDay > 30) { ContainerStory.ins.actStory.ActDay = 30; }
        }
        else if (ContainerStory.ins.actStory.ActMonth == ContainerStory.ins.actStory.MonthNames[4])
        {
            monthInt = 5;
            if (ContainerStory.ins.actStory.ActDay > 31) { ContainerStory.ins.actStory.ActDay = 31; }
        }
        else if (ContainerStory.ins.actStory.ActMonth == ContainerStory.ins.actStory.MonthNames[5])
        {
            monthInt = 6;
            if (ContainerStory.ins.actStory.ActDay > 30) { ContainerStory.ins.actStory.ActDay = 30; }
        }
        else if (ContainerStory.ins.actStory.ActMonth == ContainerStory.ins.actStory.MonthNames[6])
        {
            monthInt = 7;
            if (ContainerStory.ins.actStory.ActDay > 31) { ContainerStory.ins.actStory.ActDay = 31; }
        }
        else if (ContainerStory.ins.actStory.ActMonth == ContainerStory.ins.actStory.MonthNames[7])
        {
            monthInt = 8;
            if (ContainerStory.ins.actStory.ActDay > 31) { ContainerStory.ins.actStory.ActDay = 31; }
        }
        else if (ContainerStory.ins.actStory.ActMonth == ContainerStory.ins.actStory.MonthNames[8])
        {
            monthInt = 9;
            if (ContainerStory.ins.actStory.ActDay > 30) { ContainerStory.ins.actStory.ActDay = 30; }
        }
        else if (ContainerStory.ins.actStory.ActMonth == ContainerStory.ins.actStory.MonthNames[9])
        {
            monthInt = 10;
            if (ContainerStory.ins.actStory.ActDay > 31) { ContainerStory.ins.actStory.ActDay = 31; }
        }
        else if (ContainerStory.ins.actStory.ActMonth == ContainerStory.ins.actStory.MonthNames[10])
        {
            monthInt = 11;
            if (ContainerStory.ins.actStory.ActDay > 30) { ContainerStory.ins.actStory.ActDay = 30; }
        }
        else if (ContainerStory.ins.actStory.ActMonth == ContainerStory.ins.actStory.MonthNames[11])
        {
            monthInt = 12;
            if (ContainerStory.ins.actStory.ActDay > 31) { ContainerStory.ins.actStory.ActDay = 31; }
        }
        else
        {
            //dont trust the user
            ContainerStory.ins.actStory.ActMonth = ContainerStory.ins.actStory.MonthNames[0];

            monthInt = 1;
            if (ContainerStory.ins.actStory.ActDay > 31)
            {
                ContainerStory.ins.actStory.ActDay = 31;

            }
        }

        //Finds WEEKDAY at January 1st REVIEW THIS CRAP ...SOLVED!?
        weekDayInt = ((int)Mathf.Floor((ContainerStory.ins.actStory.ActYear - 1) / 400)
            - (int)Mathf.Floor((ContainerStory.ins.actStory.ActYear - 1) / 100)
            + (int)Mathf.Floor((ContainerStory.ins.actStory.ActYear - 1) / 4)
            + (ContainerStory.ins.actStory.ActYear - 1)) % 7;



        //Finds days elapsed since the fist day of starting year and sets correct WEEKDAY to it

        if (monthInt > 0 || monthInt < 13)
        {
            while (true)
            {

                if (monthInt != 1)
                {
                    daysDiference += 31;
                }
                else if (monthInt == 1)
                {
                    daysDiference += ContainerStory.ins.actStory.ActDay;
                    weekDayInt = (weekDayInt + daysDiference) % 7;
                    break;
                }
                if (monthInt != 2)
                {
                    if (ContainerStory.ins.actStory.ActYear % 400 == 0)
                    {
                        daysDiference += 29;
                    }
                    else if (ContainerStory.ins.actStory.ActYear % 100 == 0)
                    {
                        daysDiference += 28;
                    }
                    else if (ContainerStory.ins.actStory.ActYear % 4 == 0)
                    {
                        daysDiference += 29;
                    }
                    else
                    {
                        daysDiference += 28;
                    }
                }
                else if (monthInt == 2)
                {
                    daysDiference += ContainerStory.ins.actStory.ActDay;
                    weekDayInt = (weekDayInt + daysDiference) % 7;
                    break;
                }
                if (monthInt != 3)
                {
                    daysDiference += 31;
                }
                else if (monthInt == 3)
                {
                    daysDiference += ContainerStory.ins.actStory.ActDay;
                    weekDayInt = (weekDayInt + daysDiference) % 7;
                    break;
                }
                if (monthInt != 4)
                {
                    daysDiference += 30;
                }
                else if (monthInt == 4)
                {
                    daysDiference += ContainerStory.ins.actStory.ActDay;
                    weekDayInt = (weekDayInt + daysDiference) % 7;
                    break;
                }
                if (monthInt != 5)
                {
                    daysDiference += 31;
                }
                else if (monthInt == 5)
                {
                    daysDiference += ContainerStory.ins.actStory.ActDay;
                    weekDayInt = (weekDayInt + daysDiference) % 7;
                    break;
                }
                if (monthInt != 6)
                {
                    daysDiference += 30;
                }
                else if (monthInt == 6)
                {
                    daysDiference += ContainerStory.ins.actStory.ActDay;
                    weekDayInt = (weekDayInt + daysDiference) % 7;
                    break;
                }
                if (monthInt != 7)
                {
                    daysDiference += 31;
                }
                else if (monthInt == 7)
                {
                    daysDiference += ContainerStory.ins.actStory.ActDay;
                    weekDayInt = (weekDayInt + daysDiference) % 7;
                    break;
                }
                if (monthInt != 8)
                {
                    daysDiference += 31;
                }
                else if (monthInt == 8)
                {
                    daysDiference += ContainerStory.ins.actStory.ActDay;
                    weekDayInt = (weekDayInt + daysDiference) % 7;
                    break;
                }
                if (monthInt != 9)
                {
                    daysDiference += 30;
                }
                else if (monthInt == 9)
                {
                    daysDiference += ContainerStory.ins.actStory.ActDay;
                    weekDayInt = (weekDayInt + daysDiference) % 7;
                    break;
                }
                if (monthInt != 10)
                {
                    daysDiference += 31;
                }
                else if (monthInt == 10)
                {
                    daysDiference += ContainerStory.ins.actStory.ActDay;
                    weekDayInt = (weekDayInt + daysDiference) % 7;
                    break;
                }
                if (monthInt != 11)
                {
                    daysDiference += 30;
                }
                else if (monthInt == 11)
                {
                    daysDiference += ContainerStory.ins.actStory.ActDay;
                    weekDayInt = (weekDayInt + daysDiference) % 7;
                    break;
                }
                if (monthInt != 12)
                {
                    //not needed
                }
                else if (monthInt == 12)
                {
                    daysDiference += ContainerStory.ins.actStory.ActDay;
                    weekDayInt = (weekDayInt + daysDiference) % 7;
                    break;
                }
                else
                {
                    Debug.Log("BUG!");
                    break;
                }

            }
        }

        //Map WEEKDAYS
        if (weekDayInt == 0)
        {
            ContainerStory.ins.actStory.ActWeekday = ContainerStory.ins.actStory.WeekdayNames[0];
        }
        else if (weekDayInt == 1)
        {
            ContainerStory.ins.actStory.ActWeekday = ContainerStory.ins.actStory.WeekdayNames[1];
        }
        else if (weekDayInt == 2)
        {
            ContainerStory.ins.actStory.ActWeekday = ContainerStory.ins.actStory.WeekdayNames[2];
        }
        else if (weekDayInt == 3)
        {
            ContainerStory.ins.actStory.ActWeekday = ContainerStory.ins.actStory.WeekdayNames[3];
        }
        else if (weekDayInt == 4)
        {
            ContainerStory.ins.actStory.ActWeekday = ContainerStory.ins.actStory.WeekdayNames[4];
        }
        else if (weekDayInt == 5)
        {
            ContainerStory.ins.actStory.ActWeekday = ContainerStory.ins.actStory.WeekdayNames[5];
        }
        else if (weekDayInt == 6)
        {
            ContainerStory.ins.actStory.ActWeekday = ContainerStory.ins.actStory.WeekdayNames[6];
        }
    }

    //TIMER---------------------------------------------------------------------- 

    public void TimeController()//Correct the time every times TIC changes
    {

        ContainerStory.ins.actStory.ActHour = ContainerStory.ins.actStory.ActTick % 24;

        int dayPartInt = ContainerStory.ins.actStory.ActHour;
        if (dayPartInt >= 6 && dayPartInt < 12)
        {
            ContainerStory.ins.actStory.ActDayPart = ContainerStory.ins.actStory.DayPartNames[0];
        }
        else if (dayPartInt >= 12 && dayPartInt < 18)
        {
            ContainerStory.ins.actStory.ActDayPart = ContainerStory.ins.actStory.DayPartNames[1];
        }
        else if (dayPartInt >= 18 && dayPartInt < 24)
        {
            ContainerStory.ins.actStory.ActDayPart = ContainerStory.ins.actStory.DayPartNames[2];
        }
        else if (dayPartInt >= 0 && dayPartInt < 6)
        {
            ContainerStory.ins.actStory.ActDayPart = ContainerStory.ins.actStory.DayPartNames[3];
        }


        if (ContainerStory.ins.actStory.ActHour == 0)
        {

            weekDayInt = (weekDayInt + 1) % 7;

            if (weekDayInt == 0)
            {
                ContainerStory.ins.actStory.ActWeekday = ContainerStory.ins.actStory.WeekdayNames[0];
            }
            else if (weekDayInt == 1)
            {
                ContainerStory.ins.actStory.ActWeekday = ContainerStory.ins.actStory.WeekdayNames[1];
            }
            else if (weekDayInt == 2)
            {
                ContainerStory.ins.actStory.ActWeekday = ContainerStory.ins.actStory.WeekdayNames[2];
            }
            else if (weekDayInt == 3)
            {
                ContainerStory.ins.actStory.ActWeekday = ContainerStory.ins.actStory.WeekdayNames[3];
            }
            else if (weekDayInt == 4)
            {
                ContainerStory.ins.actStory.ActWeekday = ContainerStory.ins.actStory.WeekdayNames[4];
            }
            else if (weekDayInt == 5)
            {
                ContainerStory.ins.actStory.ActWeekday = ContainerStory.ins.actStory.WeekdayNames[5];
            }
            else if (weekDayInt == 6)
            {
                ContainerStory.ins.actStory.ActWeekday = ContainerStory.ins.actStory.WeekdayNames[6];
            }

        }

        if (ContainerStory.ins.actStory.ActHour == 0)
        {
            if (monthInt == 1)
            {
                ContainerStory.ins.actStory.ActMonth = ContainerStory.ins.actStory.MonthNames[0];

                if (ContainerStory.ins.actStory.ActDay == 31)
                {
                    ContainerStory.ins.actStory.ActDay = 1;//turn last day of the month in fist adding one day
                    monthInt = ((monthInt) % 12) + 1;//adds another month
                    ContainerStory.ins.actStory.ActMonth = ContainerStory.ins.actStory.MonthNames[1];//necessary for correct display
                }
                else { ContainerStory.ins.actStory.ActDay++; }
            }
            else if (monthInt == 2)
            {
                ContainerStory.ins.actStory.ActMonth = ContainerStory.ins.actStory.MonthNames[1];
                if (ContainerStory.ins.actStory.ActYear % 400 == 0)
                {

                    if (ContainerStory.ins.actStory.ActDay == 29)
                    {
                        ContainerStory.ins.actStory.ActDay = 1;
                        monthInt = ((monthInt) % 12) + 1;
                        ContainerStory.ins.actStory.ActMonth = ContainerStory.ins.actStory.MonthNames[2];
                    }
                    else { ContainerStory.ins.actStory.ActDay++; }
                }
                else if (ContainerStory.ins.actStory.ActYear % 100 == 0)
                {

                    if (ContainerStory.ins.actStory.ActDay == 28)
                    {
                        ContainerStory.ins.actStory.ActDay = 1;
                        monthInt = ((monthInt) % 12) + 1;
                        ContainerStory.ins.actStory.ActMonth = ContainerStory.ins.actStory.MonthNames[2];
                    }
                    else { ContainerStory.ins.actStory.ActDay++; }
                }
                else if (ContainerStory.ins.actStory.ActYear % 4 == 0)
                {

                    if (ContainerStory.ins.actStory.ActDay == 29)
                    {
                        ContainerStory.ins.actStory.ActDay = 1;
                        monthInt = ((monthInt) % 12) + 1;
                        ContainerStory.ins.actStory.ActMonth = ContainerStory.ins.actStory.MonthNames[2];
                    }
                    else { ContainerStory.ins.actStory.ActDay++; }
                }
                else
                {
                    if (ContainerStory.ins.actStory.ActDay == 28)
                    {
                        ContainerStory.ins.actStory.ActDay = 1;
                        monthInt = ((monthInt) % 12) + 1;
                        ContainerStory.ins.actStory.ActMonth = ContainerStory.ins.actStory.MonthNames[2];
                    }
                    else { ContainerStory.ins.actStory.ActDay++; }
                }
            }
            else if (monthInt == 3)
            {
                ContainerStory.ins.actStory.ActMonth = ContainerStory.ins.actStory.MonthNames[2];

                if (ContainerStory.ins.actStory.ActDay == 31)
                {
                    ContainerStory.ins.actStory.ActDay = 1;
                    monthInt = ((monthInt) % 12) + 1;
                    ContainerStory.ins.actStory.ActMonth = ContainerStory.ins.actStory.MonthNames[3];
                }
                else { ContainerStory.ins.actStory.ActDay++; }
            }
            else if (monthInt == 4)
            {
                ContainerStory.ins.actStory.ActMonth = ContainerStory.ins.actStory.MonthNames[3];

                if (ContainerStory.ins.actStory.ActDay == 30)
                {
                    ContainerStory.ins.actStory.ActDay = 1;
                    monthInt = ((monthInt) % 12) + 1;
                    ContainerStory.ins.actStory.ActMonth = ContainerStory.ins.actStory.MonthNames[4];
                }
                else { ContainerStory.ins.actStory.ActDay++; }
            }
            else if (monthInt == 5)
            {
                ContainerStory.ins.actStory.ActMonth = ContainerStory.ins.actStory.MonthNames[4];

                if (ContainerStory.ins.actStory.ActDay == 31)
                {
                    ContainerStory.ins.actStory.ActDay = 1;
                    monthInt = ((monthInt) % 12) + 1;
                    ContainerStory.ins.actStory.ActMonth = ContainerStory.ins.actStory.MonthNames[5];
                }
                else { ContainerStory.ins.actStory.ActDay++; }
            }
            else if (monthInt == 6)
            {
                ContainerStory.ins.actStory.ActMonth = ContainerStory.ins.actStory.MonthNames[5];

                if (ContainerStory.ins.actStory.ActDay == 30)
                {
                    ContainerStory.ins.actStory.ActDay = 1;
                    monthInt = ((monthInt) % 12) + 1;
                    ContainerStory.ins.actStory.ActMonth = ContainerStory.ins.actStory.MonthNames[6];
                }
                else { ContainerStory.ins.actStory.ActDay++; }
            }
            else if (monthInt == 7)
            {
                ContainerStory.ins.actStory.ActMonth = ContainerStory.ins.actStory.MonthNames[6];

                if (ContainerStory.ins.actStory.ActDay == 31)
                {
                    ContainerStory.ins.actStory.ActDay = 1;
                    monthInt = ((monthInt) % 12) + 1;
                    ContainerStory.ins.actStory.ActMonth = ContainerStory.ins.actStory.MonthNames[7];
                }
                else { ContainerStory.ins.actStory.ActDay++; }
            }
            else if (monthInt == 8)
            {
                ContainerStory.ins.actStory.ActMonth = ContainerStory.ins.actStory.MonthNames[7];

                if (ContainerStory.ins.actStory.ActDay == 31)
                {
                    ContainerStory.ins.actStory.ActDay = 1;
                    monthInt = ((monthInt) % 12) + 1;
                    ContainerStory.ins.actStory.ActMonth = ContainerStory.ins.actStory.MonthNames[8];
                }
                else { ContainerStory.ins.actStory.ActDay++; }
            }
            else if (monthInt == 9)
            {
                ContainerStory.ins.actStory.ActMonth = ContainerStory.ins.actStory.MonthNames[8];

                if (ContainerStory.ins.actStory.ActDay == 30)
                {
                    ContainerStory.ins.actStory.ActDay = 1;
                    monthInt = ((monthInt) % 12) + 1;
                    ContainerStory.ins.actStory.ActMonth = ContainerStory.ins.actStory.MonthNames[9];
                }
                else { ContainerStory.ins.actStory.ActDay++; }
            }
            else if (monthInt == 10)
            {
                ContainerStory.ins.actStory.ActMonth = ContainerStory.ins.actStory.MonthNames[9];

                if (ContainerStory.ins.actStory.ActDay == 31)
                {
                    ContainerStory.ins.actStory.ActDay = 1;
                    monthInt = ((monthInt) % 12) + 1;
                    ContainerStory.ins.actStory.ActMonth = ContainerStory.ins.actStory.MonthNames[10];
                }
                else { ContainerStory.ins.actStory.ActDay++; }
            }
            else if (monthInt == 11)
            {
                ContainerStory.ins.actStory.ActMonth = ContainerStory.ins.actStory.MonthNames[10];

                if (ContainerStory.ins.actStory.ActDay == 30)
                {
                    ContainerStory.ins.actStory.ActDay = 1;
                    monthInt = ((monthInt) % 12) + 1;
                    ContainerStory.ins.actStory.ActMonth = ContainerStory.ins.actStory.MonthNames[11];
                }
                else { ContainerStory.ins.actStory.ActDay++; }
            }
            else if (monthInt == 12)
            {
                ContainerStory.ins.actStory.ActMonth = ContainerStory.ins.actStory.MonthNames[11];

                if (ContainerStory.ins.actStory.ActDay == 31)
                {
                    ContainerStory.ins.actStory.ActDay = 1;
                    monthInt = ((monthInt) % 12) + 1;
                    ContainerStory.ins.actStory.ActMonth = ContainerStory.ins.actStory.MonthNames[0];
                    ContainerStory.ins.actStory.ActYear++;
                }
                else { ContainerStory.ins.actStory.ActDay++; }
            }
        }
    }

}
