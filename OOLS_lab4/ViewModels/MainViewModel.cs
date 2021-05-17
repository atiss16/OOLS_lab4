using DevExpress.Mvvm;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System.Collections.ObjectModel;
using OOLS_lab4.States;
using OOLS_lab4.Models.Beasts;
using System.Linq;
using OOLS_lab4.Models;
using System.Windows;

namespace OOLS_lab4.ViewModels
{
    public class MainViewModel : ReactiveObject
    {
        public MainViewModel()
        {
            ChangeState(new State1(this));
        }
        [Reactive] public string TaskText { get; set; }
        [Reactive] public ObservableCollection<ActionOption> ActionOptions { get; set; } = new ObservableCollection<ActionOption>();
        [Reactive] public ObservableCollection<Beast> OutsideBeasts { get; set; } = new ObservableCollection<Beast>();
        [Reactive] public ObservableCollection<Beast> NurmenguardBeasts { get; set; } = new ObservableCollection<Beast>();
        [Reactive] public ObservableCollection<Beast> CaseBeasts { get; set; } = new ObservableCollection<Beast>();
        //[Reactive] public Beast SelectedBeast { get; set; }

        [Reactive] public int PotioDeminutumCount { get; set; }
        [Reactive] public int PotioMagnificatCount { get; set; }
        [Reactive] public int CirculatingPotioCount { get; set; }
        public int MagicPowerSum => CaseBeasts.Sum(x => x.Power);

        public State State { get; set; }
        public State GameState { get; set; }

        public void ChangeState(State state)
        {
            State = state;
            TaskText = state.TaskText;
            ActionOptions = state.ActionOptions;
        }

        public void ResetGame()
        {
            PotioDeminutumCount = 0;
            PotioMagnificatCount = 0;
            CirculatingPotioCount = 0;

            OutsideBeasts.Clear();
            NurmenguardBeasts.Clear();
            CaseBeasts.Clear();

            ChangeState(new State1(this));
        }

        public void Surrender()
        {
            MessageBoxResult result = MessageBox.Show("Хотите сдаться?)", "Сдаться", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    Close();
                    break;
                case MessageBoxResult.No:
                    MessageBox.Show("Так держать!");
                    break;
            }
        }

        public void Close()
        {
            Application.Current.MainWindow.Close();
        }

        public void EndTheGame(string text)
        {
            MessageBoxResult result = MessageBox.Show($"{text}\nХотите начать заново?", "", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    ResetGame();
                    break;
                case MessageBoxResult.No:
                    Close();
                    break;
            }
        }
    }
}
