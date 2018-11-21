using System;
using System.Collections.Generic;
using System.Text;
using ToDo.Models;

namespace ToDo.ViewModel
{
    public class TaskListViewModel : BaseViewModel
    {
        private MainPageListViewModel mplvm;
        public TaskModel TaskModel { get; private set; }

        public TaskListViewModel()
        {
            TaskModel = new TaskModel();
        }

        public MainPageListViewModel ListViewModel
        {
            get { return mplvm; }
            set
            {
                if(mplvm != value)
                {
                    mplvm = value;
                    NotifyPropertyChanged(nameof(ListViewModel));
                }
            }
        }

        public string TaskName
        {
            get { return TaskModel.TaskName; }
            set
            {
                if(TaskModel.TaskName != value)
                {
                    TaskModel.TaskName = value;
                    NotifyPropertyChanged(nameof(TaskName));
                }
            }
        }

        private TimeSpan timeSpan;
        public TimeSpan TimeSpan
        {
            get { return timeSpan; }
            set
            {
                if(timeSpan != value)
                {
                    timeSpan = value;
                    NotifyPropertyChanged(nameof(TimeSpan));
                }
            }
        }

        public string TaskTime
        {
            get { return timeSpan.ToString(); }
            set
            {
                if (TaskModel.TaskTime != value)
                {
                    TaskModel.TaskTime = value;
                    NotifyPropertyChanged(nameof(TaskTime));
                }
            }
        }

        public bool IsValid
        {
            get
            {
                return (!string.IsNullOrEmpty(TaskName.Trim())) ||
                    (!string.IsNullOrEmpty(TaskTime.Trim()));
            }
        }
    }
}
