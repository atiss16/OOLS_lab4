using DevExpress.Mvvm;
using OOLS_lab4.Models;
using OOLS_lab4.Models.Beasts;
using OOLS_lab4.ViewModels;
using System.Collections.ObjectModel;

namespace OOLS_lab4.States
{
    public class PutBeastIntoCaseState : SelectBeastState
    {
        public PutBeastIntoCaseState(MainViewModel gameController, ObservableCollection<Beast> beasts) : base(gameController, beasts)
        {
        }
        public override ObservableCollection<ActionOption> ActionOptions { get; set; }
        public override string TaskText => "Выберите зверька:";
        public override void ExecuteAction()
        {
            gameController.OutsideBeasts.Remove(SelectedBeast);
            gameController.CaseBeasts.Add(SelectedBeast);
        }
    }
}
