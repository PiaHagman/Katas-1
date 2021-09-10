using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Scheduler.Exceptions;
using Scheduler.Models;

namespace Scheduler
{
    public partial class CaseWorkerVisualSchedule : UserControl
    {
        private readonly CaseWorker _caseWorker;
        private readonly Action _meetingAddedhandler;

        public CaseWorkerVisualSchedule(CaseWorker caseWorker, Action meetingAddedHandler)
        {
            _caseWorker = caseWorker;
            InitializeComponent();

            _meetingAddedhandler = meetingAddedHandler;
            meetingAddedHandler();

            label_CaseWorkerName.Text = _caseWorker.Name;
            dateTimePicker.Format = DateTimePickerFormat.Custom;

            button_Add.Click += Button_Add_Click;
            button_ChangeDate.Click += Button_ChangeDate_Click;

            RefreshDisplayedMeetings();
        }

        private void Button_ChangeDate_Click(object sender, EventArgs e)
        {
            

            try
            {
                int index = listBox_Meetings.SelectedIndex;
                _caseWorker.ChangeMeeting(index, dateTimePicker.Value); //anropar ChangeMeeting och om tr
                RefreshDisplayedMeetings();
            }
            catch (MeetingOverlapException exception) //exception är ett namn i just denna sats
            {
                MessageBox.Show(exception.Message);
            }
           
        }

        private void Button_Add_Click(object sender, EventArgs e)
        {
            try
            {
                _caseWorker.NewDateAdded(dateTimePicker.Value);
                RefreshDisplayedMeetings();
                _meetingAddedhandler(); //Denna har vi lagt till för att kunna anropa RefreshFreeSpotsLabel
            }
            catch (MeetingOverlapException exception)
            {
                MessageBox.Show(exception.Message, caption: "Hej hej"); //Caption = Rubrik för Messagebox
                //mbox är kortkommande för MessageBox
            }
            //Om ett annat fel som inte fångas av ovan
            catch
            {
                MessageBox.Show("Unknown error");
            }
           
        }

        public void RefreshDisplayedMeetings()
        {
            List<string> content = new List<string>();

            foreach (Meeting meeting in _caseWorker.Meetings)
            {
                content.Add(meeting.ToString());
            }

            listBox_Meetings.DataSource = content;
        }
    }
}
