using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDo.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddTaskView : ContentPage
	{
        public TaskListViewModel ViewModel { get; private set; }

		public AddTaskView (TaskListViewModel vm)
		{
			InitializeComponent ();
            ViewModel = vm;
            this.BindingContext = ViewModel;
		}
	}
}