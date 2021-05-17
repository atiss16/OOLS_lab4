using DevExpress.Mvvm;
using OOLS_lab4.Models;
using OOLS_lab4.ViewModels;
using System.Collections.ObjectModel;
using System.Windows;

namespace OOLS_lab4.States
{
    public class State3 : State
    {
        public State3(MainViewModel gameController) : base(gameController)
        {
            ActionOptions.Add(new ActionOption("Спросить, что такое Potio Deminutum", PotioDeminutumInfo));
            ActionOptions.Add(new ActionOption("Спросить, что такое Potio Magnificat", PotioMagnificatInfo));
            ActionOptions.Add(new ActionOption("Остаться и посмотреть, что будет дальше", NextState));
            ActionOptions.Add(new ActionOption("Всё-таки встать и уйти, ибо эти люди Вас пугают", Surrender));
        }
        public override ObservableCollection<ActionOption> ActionOptions { get; set; }
        public override string TaskText => "Тем временем в баре появился ещё один человек – полноватый и с усами. " +
            "Он пытался делать вид, будто все вокруг – его давние знакомые, и ему максимально комфортно в Дырявом котле, " +
            "но в его глазах четко читалось удивление от чашек, которые полировались на барной стойке, весело позванивая " +
            "друг о друга. Это и был Якоб. Он не сразу, но нашёл ваш стол и плюхнулся рядом с Тиной. " +
            "Завидев его, Ньют начал копошиться во внутренних карманах своего плаща и спустя несколько " +
            "секунд достал оттуда 4 странных флакона: 1 с надписью Potio Deminutum и 3 одинаковых " +
            "с надписью Potio Magnificat.";

        private DelegateCommand potioMagnificatInfo;
        public DelegateCommand PotioMagnificatInfo => potioMagnificatInfo ??= new DelegateCommand(() =>
        {
            MessageBox.Show("Potio Magnificat – увеличивает уровень силы на 10%");
        });

        private DelegateCommand potioDeminutumInfo;
        public DelegateCommand PotioDeminutumInfo => potioDeminutumInfo ??= new DelegateCommand(() =>
        {
            MessageBox.Show("Potio Deminutum (если взболтать)– уменьшает уровень волшебной силы на 50%"+
                            "\nPotio Deminutum(просто) – уменьшает уровень волшебной силы на 25 %");
        });

        private DelegateCommand nextState;
        public DelegateCommand NextState => nextState ??= new DelegateCommand(() =>
        {
            gameController.ChangeState(new State4(gameController));
        });
    }
}
