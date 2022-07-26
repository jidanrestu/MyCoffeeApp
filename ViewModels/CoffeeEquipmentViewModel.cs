using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MyCoffeeApp.ViewModels
{
    public class CoffeeEquipmentViewModel : BindableObject
    {
        public CoffeeEquipmentViewModel()
        {
            IncreaseCount = new Command(OnIncrease);
        }

        public ICommand IncreaseCount { get; /*set;*/ }

        int count = 0;
        string countDisplay = "";

        public string CountDisplay
        {
            get => countDisplay;
            set
            {
                if (value == countDisplay) return;
                else
                {
                    countDisplay = value;
                    OnPropertyChanged();
                }

            }
        }

        void OnIncrease()
        {
            count++;
            CountDisplay = $"You've clicked me {count} times";
        }
    }
}
