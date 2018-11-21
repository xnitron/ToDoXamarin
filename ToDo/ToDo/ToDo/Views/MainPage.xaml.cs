using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ToDo.ViewModel;

namespace ToDo.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = new MainPageListViewModel(this) { Navigation = this.Navigation };
        }
    }
}
