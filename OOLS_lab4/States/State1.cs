using DevExpress.Mvvm;
using OOLS_lab4.Models;
using OOLS_lab4.ViewModels;
using System.Collections.ObjectModel;
using System.Windows;

namespace OOLS_lab4.States
{
    public class State1 : State
    {
        public State1(MainViewModel gameController) : base(gameController)
        {
            ActionOptions.Add(new ActionOption("Далее", NextState));
        }
        public override ObservableCollection<ActionOption> ActionOptions { get; set; }
        public override string TaskText => "Вы зашли выпить сливочного пива в “Дырявый котел”. "+
            "Там Вас встретил Ваш давний приятель Ньют Саламандер. Выглядел он весьма встревожено, но " +
            "Вы не придали этому значению – ведь это же Ньют! Мальчик, которого отчислили из Хогвартса " +
            "за выращивание запрещенных зверей, которые способны причинить вред человеку.";

        private DelegateCommand nextState;
        public DelegateCommand NextState => nextState ??= new DelegateCommand(() =>
        {
            gameController.ChangeState(new State2(gameController));
        });
    }
}
