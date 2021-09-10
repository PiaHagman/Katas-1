using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KataHelper;

namespace Scheduler.Models
{
    public class Scheduler
    {
        public List<Applicant> UnassignedApplicants;
        public List<CaseWorker> CaseWorkers;

        public Scheduler()
        {
            UnassignedApplicants = new List<Applicant>();
            CaseWorkers = new List<CaseWorker>();

            string[] randomNames = Helper.GetRandomNames(14, 123);

            for (int i = 0; i < 10; i++)
            {
                Applicant applicant = new Applicant();
                applicant.Name = randomNames[i];
                UnassignedApplicants.Add(applicant);
            }

            for (int i = 0; i < 4; i++)
            {
                CaseWorker caseWorker = new CaseWorker();
                caseWorker.Name = randomNames[10 + i];
                CaseWorkers.Add(caseWorker);
            }
        }

        public void RandomlyFillUpMeetings()
        {
            //Här går vi igenom varje caseWorkers mötesschema
            foreach (CaseWorker caseWorker in CaseWorkers) //För varje objenktinstans (caseWorker) av
                                                           //klassen Caseworker i listan CaseWorkers
            {
                foreach (Meeting meeting in caseWorker.Meetings) //För varje meeting i klassen Meeting i varje 
                                                                    //caseWorker.Meetings-listan (varje caseWorker har en egen lista med möten)
                {
                    if (UnassignedApplicants.Count == 0) //count motsvarar .Length i en array
                        return;

                    if (meeting.Applicant == null)
                    {
                        Random rand = new Random(); //Skapar ett Random objekt som heter rand
                        int randomIndex = rand.Next(0, UnassignedApplicants.Count); //0 till slutet på Applicants-listan

                        meeting.Applicant = UnassignedApplicants[randomIndex];
                        UnassignedApplicants.RemoveAt(randomIndex);
                    }
                }
            }
        }
    }
}
