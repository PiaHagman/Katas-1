using System;

namespace Scheduler.Models
{
    public class Meeting
    {
        public DateTime Start;
        public TimeSpan Duration;
        public Applicant Applicant;

        public Meeting(DateTime start)
        {
            Start = start;
            Duration = TimeSpan.FromMinutes(30);
            Applicant = null;
        }
        public Meeting(DateTime start, TimeSpan duration)
        {
            Start = start;
            Duration = duration;
            Applicant = null;
        }

        public bool Overlap(Meeting meeting)
        {
            bool endIsBefore = (Start + Duration) < meeting.Start;
            bool startIsAfter = (meeting.Start + meeting.Duration) < Start;

            return !(endIsBefore || startIsAfter);
        }

        public override string ToString()  //Override för att vi vill skapa en egen metod hur vi vill skriva ut
                                            //vår info. Annars används den ToString som finns i .Net biblioteket
        {
            string date = Start.ToString("d'/'M'/'yy");

            string startTime = Start.ToString(format: "H:mm"); //När mötet startar
            
            DateTime endTime = Start + Duration; //Resultatet är en DateTime

            string endTimeString = endTime.ToString(format: "H:mm"); //Gör om denna till en string

            string info = $"Datum: {date} Tid: {startTime} - {endTimeString}";

            if (Applicant != null)
                info += " with: " + Applicant.Name;

            return info;
        }
    }
}
