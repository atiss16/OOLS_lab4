using DevExpress.Mvvm;
using OOLS_lab4.Models;
using OOLS_lab4.ViewModels;
using System.Collections.ObjectModel;
using System.Windows;

namespace OOLS_lab4.States
{
    public class State2 : State
    {
        public State2(MainViewModel gameController) : base(gameController)
        {
            ActionOptions.Add(new ActionOption("Спросить, как Куини оказалась у Гриндевальда и что такое Нурменгард", AboutQueenie));
            ActionOptions.Add(new ActionOption("Спросить, кто такой Якоб и почему его надо спасать", AboutJacob));
            ActionOptions.Add(new ActionOption("Подождать Якоба", NextState));
            ActionOptions.Add(new ActionOption("Встать, вежливо попрощаться и уйти от этих сумасшедших", Surrender));
        }
        public override ObservableCollection<ActionOption> ActionOptions { get; set; }
        public override string TaskText => "Ньют рассказал Вам о том, как он провел последний год, о том, " +
            "с чем ему пришлось столкнуться в Нью-Йорке и о том, как они с союзниками и Николасом Фламелем " +
            "совсем недавно спасли Париж от огня. В этот момент в бар вошла незнакомая Вам женщина с темными " +
            "волосами и проникновенным ищущим взглядом. Ньют встал, показал жестом, где находится ваш стол и " +
            "пригласил ее присоединиться.Это была Тина Голдштейн – бывшая сотрудница Министерства Магии и по " +
            "совместительству – возлюбленная Ньюта (правда они оба делают вид, что не догадываются об этом). " +
            "Тина начала разговор не с приветствия, а с того, что только что нашла в своих вещах 2 пузырька " +
            "оборотного зелья, которое когда-то давно им выдавали в Министерстве для одного из заданий.После чего, " +
            "не обращая внимания на Вас, она начала заверять Ньюта: «Пойми, это единственный вариант проникнуть в " +
            "Нурменгард живыми и в полном составе.Куини – моя сестра, я не могу больше не о чем думать кроме ее " +
            "вызволения из лап Гриндевальда. А Якоб… Якоб просто не согласится сидеть и ждать нас, он обязательно " +
            "попытается пойти с нами и чтобы его спасти необходим твой чемодан…»";


        private DelegateCommand aboutQueenie;
        public DelegateCommand AboutQueenie => aboutQueenie ??= new DelegateCommand(() =>
        {
            MessageBox.Show("Куини - сестра Тины. В общем, это долгая история...");
        });

        private DelegateCommand aboutJacob;
        public DelegateCommand AboutJacob => aboutJacob ??= new DelegateCommand(() =>
        {
            MessageBox.Show("Якоб не сможет просто так сидеть и ничего не делать и, возможно, " +
                "с ним что-то случится. Он скоро придет и вы познакомитесь");
        });

        private DelegateCommand nextState;
        public DelegateCommand NextState => nextState ??= new DelegateCommand(() =>
        {
            gameController.ChangeState(new State3(gameController));
        });
    }
}
