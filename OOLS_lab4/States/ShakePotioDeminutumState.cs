using DevExpress.Mvvm;
using OOLS_lab4.Models;
using OOLS_lab4.Models.Beasts;
using OOLS_lab4.ViewModels;
using OOLS_lab4.Models.Potions;
using System.Collections.ObjectModel;
using ReactiveUI;

namespace OOLS_lab4.States
{
    public class ShakePotioDeminutumState : SelectBeastState
    {
        public ShakePotioDeminutumState(MainViewModel gameController, ObservableCollection<Beast> beasts) : base(gameController, beasts)
        {
        }
        public override ObservableCollection<ActionOption> ActionOptions { get; set; }
        public override string TaskText => "Выберите зверька:";
        public override void ExecuteAction()
        {
            PotioDeminutum potioDeminutum = new PotioDeminutum();
            potioDeminutum.TakeShakedPotio(SelectedBeast);
            gameController.PotioDeminutumCount--;
        }
    }
}
