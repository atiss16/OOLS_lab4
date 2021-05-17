using DevExpress.Mvvm;
using OOLS_lab4.Models;
using OOLS_lab4.Models.Beasts;
using OOLS_lab4.ViewModels;
using System.Collections.ObjectModel;
using System.Windows;

namespace OOLS_lab4.States
{
    public class State5 : State
    {
        public State5(MainViewModel gameController) : base(gameController)
        {
            ActionOptions.Add(new ActionOption("Далее", NextState));
        }
        public override ObservableCollection<ActionOption> ActionOptions { get; set; }
        public override string TaskText => "После того, как Ньют рассказал Вам о сути проблемы и исходных данных, " +
            "он приоткрыл крышку своего чемодана, с которым он никогда не расставался, и сквозь щель Вы успели " +
            "заметить маленького черного зверька с утиным носом. «Нюхль, полезай обратно, кому говорят! Если ты ещё раз…» " +
            "- разразился громом Ньют и вытащил из чемодана желтый свиток, который предназначается Вам. " +
            "В свитке было написано следующее:\n" +
            "   Нюхль, уровень силы – 80\n" +
            "   Лечурка, уровень силы – 16\n" +
            "   Птица-гром, уровень силы – 32\n" +
            "   Камуфлори, уровень силы – 32\n" +
            "   Пикирующий злыдень, уровень силы – 29\n" +
            "   Лунтеленок, уровень силы – 20\n";

        private DelegateCommand nextState;
        public DelegateCommand NextState => nextState ??= new DelegateCommand(() =>
        {
            gameController.GameState = new GameState(gameController);
            gameController.ChangeState(gameController.GameState);
        });
    }
}
