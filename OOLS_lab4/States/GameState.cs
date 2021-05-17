using DevExpress.Mvvm;
using OOLS_lab4.Models;
using OOLS_lab4.Models.Beasts;
using OOLS_lab4.ViewModels;
using ReactiveUI;
using System.Collections.ObjectModel;
using System.Windows;

namespace OOLS_lab4.States
{
    public class GameState : State
    {
        public GameState(MainViewModel gameController) : base(gameController)
        {
            ActionOptions.Add(new ActionOption("Попросить Ньюта «перебросить» обратно за границу зверька ...", ReturnBeastState));
            ActionOptions.Add(new ActionOption("Побрызгать Potio Magnificat зверька ...", TakePotioMagnificatState));
            ActionOptions.Add(new ActionOption("Полить Potio Deminutum зверька ...", TakePotioDeminutum));
            ActionOptions.Add(new ActionOption("Взболтать Potio Deminutum и вылить его на зверька ...", ShakePotioDeminutum));
            ActionOptions.Add(new ActionOption("Положить в чемодан зверька ...", PutBeastIntoCase));
            ActionOptions.Add(new ActionOption("Вытащить из чемодана зверька ...", TakeBeastFromCase));
            ActionOptions.Add(new ActionOption("Отправить Якоба", SendJacobToNurmenguard));
            ActionOptions.Add(new ActionOption("Сбежать", Surrender));

            InitializeGame();
        }
        public override ObservableCollection<ActionOption> ActionOptions { get; set; }
        public override string TaskText => "Итак, у Вас есть 6 зверьков, Якоб, чемодан и 6 зелий:"+
            $"\n    {gameController.PotioDeminutumCount} флакон Potio Deminutum " +
            $"\n    {gameController.PotioMagnificatCount} флакона Potio Magnificat " +
            $"\n    {gameController.CirculatingPotioCount} флакона оборотного зелья " +
            "\nТакже Ньют сообщил, что они с Тиной решили разделиться: " +
            "Тина будет отправлять Якоба снаружи Нурменграда, а Ньют будет ждать внутри." +
            "После этого Ньют резко взял Вас за руку и Вы трансгрессировали в Австрию " +
            "на границу Нурменграда.Теперь всё в Ваших руках.";


        public void InitializeGame()
        {
            gameController.PotioDeminutumCount = 1;
            gameController.PotioMagnificatCount = 3;
            gameController.CirculatingPotioCount = 2;

            gameController.OutsideBeasts.Add(new Beast("Нюхль", 80));
            gameController.OutsideBeasts.Add(new Beast("Лечурка", 16));
            gameController.OutsideBeasts.Add(new Beast("Птица-гром", 32));
            gameController.OutsideBeasts.Add(new Beast("Камуфлори", 32));
            gameController.OutsideBeasts.Add(new Beast("Пикирующий злыдень", 29));
            gameController.OutsideBeasts.Add(new Beast("Лунтеленок", 20));
        }

        private DelegateCommand returnBeastState;
        public DelegateCommand ReturnBeastState => returnBeastState ??= new DelegateCommand(() =>
        {
            var selectBeastState = new ReturnBeastState(gameController, gameController.NurmenguardBeasts);
            gameController.ChangeState(selectBeastState);

        }, () => gameController.NurmenguardBeasts.Count > 0);


        private DelegateCommand takePotioMagnificatState;
        public DelegateCommand TakePotioMagnificatState => takePotioMagnificatState ??= new DelegateCommand(() =>
        {
            gameController.ChangeState(new TakePotioMagnificatState(gameController, gameController.OutsideBeasts));
        }, () => gameController.PotioMagnificatCount > 0 && gameController.OutsideBeasts.Count > 0);


        private DelegateCommand takePotioDeminutum;
        public DelegateCommand TakePotioDeminutum => takePotioDeminutum ??= new DelegateCommand(() =>
        {
            gameController.ChangeState(new TakePotioDiminutumState(gameController, gameController.OutsideBeasts));
        }, () => gameController.PotioDeminutumCount > 0 && gameController.OutsideBeasts.Count > 0);


        private DelegateCommand shakePotioDeminutum;
        public DelegateCommand ShakePotioDeminutum => shakePotioDeminutum ??= new DelegateCommand(() =>
        {
            gameController.ChangeState(new ShakePotioDeminutumState(gameController, gameController.OutsideBeasts));
        }, () => gameController.PotioDeminutumCount > 0 && gameController.OutsideBeasts.Count > 0);


        private DelegateCommand putBeastIntoCase;
        public DelegateCommand PutBeastIntoCase => putBeastIntoCase ??= new DelegateCommand(() =>
        {
            gameController.ChangeState(new PutBeastIntoCaseState(gameController, gameController.OutsideBeasts));
        }, () => gameController.OutsideBeasts.Count > 0);


        private DelegateCommand takeBeastFromCase;
        public DelegateCommand TakeBeastFromCase => takeBeastFromCase ??= new DelegateCommand(() =>
        {
            gameController.ChangeState(new TakeBeastFromCaseState(gameController, gameController.CaseBeasts));

        }, () => gameController.CaseBeasts.Count > 0);


        private DelegateCommand sendJacobToNurmenguard;
        public DelegateCommand SendJacobToNurmenguard => sendJacobToNurmenguard ??= new DelegateCommand(() =>
        {

            if (gameController.MagicPowerSum != 80)
            {
                gameController.EndTheGame("Вы проиграли, уровень силы зверьков в чемодане должен быть равным 80");
                return;
            }

            
            if (gameController.CirculatingPotioCount == 0 && gameController.OutsideBeasts.Count > 0)
            {
                gameController.EndTheGame("Вы проиграли :(");
                return;
            }
            gameController.CirculatingPotioCount--;

            foreach (Beast beast in gameController.CaseBeasts)
                gameController.NurmenguardBeasts.Add(beast);
            gameController.CaseBeasts.Clear();

            if (gameController.OutsideBeasts.Count == 0 && gameController.CaseBeasts.Count == 0)
                gameController.EndTheGame("Вы выиграли, поздравляем 🍑🍑🍑");

        }, () => gameController.CirculatingPotioCount >= 0);

    }
}
