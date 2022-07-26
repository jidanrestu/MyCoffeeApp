using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyCoffeeApp.ViewModels
{
    public class CoffeeEquipmentViewModel : BasicViewModel
    {
        public ObservableRangeCollection<string> Coffee { get; }
        public CoffeeEquipmentViewModel()
        {
            IncreaseCount = new Command(OnIncrease);
            CallServerCommand = new AsyncCommand(CallServer);
            Coffee = new ObservableRangeCollection<string>();
            Title = "Coffee Equipment";
        }

        public ICommand CallServerCommand { get; }
        async Task CallServer()
        {
            var items = new List<string> { "Yes Plz", "Tonx", "Blue Bottle" };
            Coffee.AddRange(items);
        }

        public ICommand IncreaseCount { get; /*set;*/ }

        int count = 0;
        string countDisplay = "";

        public string CountDisplay
        {
            get => countDisplay;
            set => SetProperty(ref countDisplay, value);
        }

        void OnIncrease()
        {
            count++;
            CountDisplay = $"You've clicked me {count} times";
        }
    }
}
