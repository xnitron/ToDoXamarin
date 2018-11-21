using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using ToDo.Views;
using System.Collections.ObjectModel;

namespace ToDo.ViewModel
{
    public class MainPageListViewModel : BaseViewModel
    {
        public ObservableCollection<TaskListViewModel> Tasks { get; set; }

        public ICommand AddCommand { get; protected set; }
        public ICommand SaveCommand { get; protected set; }
        public INavigation Navigation { get; set; }

        private ContentPage page;
        private TaskListViewModel selectTask { get; set; }

        public MainPageListViewModel(ContentPage page)
        {
            this.page = page;
            Tasks = new ObservableCollection<TaskListViewModel>();
            AddCommand = new Command(AddTask);
            SaveCommand = new Command(SaveTask);
        }

        public TaskListViewModel SelectTask
        {
            get { return selectTask; }
            set
            {
                if(selectTask != value)
                {
                    selectTask = value;
                    ChangeTask(selectTask);
                    NotifyPropertyChanged(nameof(SelectTask));
                }
            }
        }

        private void AddTask()
        {
            Navigation.PushAsync(new AddTaskView(new TaskListViewModel() { ListViewModel = this })) ;
        }

        private void SaveTask(object taskObj)
        {
            try
            {
                if (taskObj is TaskListViewModel task && task.IsValid)
                {
                    Tasks.Add(task);
                }
                Back();
            }
            catch (Exception)
            {
                page.DisplayAlert("Error", "Task was empty, try again!", "Ok");
            }
        }

        private void Back()
        {
            Navigation.PopAsync();
        }

        private void RemoveTask(object taskObj)
        {
            if (taskObj is TaskListViewModel task)
            {
                Tasks.Remove(task);
            }
        }
        private async void ChangeTask(object taskObj)
        {
            var action = await page.DisplayActionSheet("Options", null, "Close", "Remove", "Change time");

            if (action == "Remove")
            {
                RemoveTask(taskObj);
            }
        }
    }
}
