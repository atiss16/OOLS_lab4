using DevExpress.Mvvm;
using OOLS_lab4.Models;
using OOLS_lab4.Models.Beasts;
using OOLS_lab4.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace OOLS_lab4.States
{
    public abstract class State
    {
        public State(MainViewModel gameController)
        {
            this.gameController = gameController;
            ActionOptions = new ObservableCollection<ActionOption>();
        }
        protected MainViewModel gameController { get; set; }
        public abstract ObservableCollection<ActionOption> ActionOptions { get; set; }
        public abstract string TaskText { get; }

        private DelegateCommand surrender;
        public DelegateCommand Surrender => surrender ??= new DelegateCommand(() =>
        {
            gameController.Surrender();
        });
    }

    public abstract class SelectBeastState : State
    {
        public SelectBeastState(MainViewModel gameController, ObservableCollection<Beast> beasts) : base(gameController)
        {
            foreach (Beast beast in beasts)
            {
                ActionOptions.Add(new ActionOption(beast.Name, CreateSelectBeastCommand(beast)));
            }
            ActionOptions.Add(new ActionOption("Отмена", Cancel));
        }
        public Beast SelectedBeast { get; set; }
        private DelegateCommand CreateSelectBeastCommand(Beast beast)
        {
            return new DelegateCommand(() =>
            {
                this.SelectedBeast = beast;
                gameController.ChangeState(gameController.GameState);
                ExecuteAction();
            });
        }
        public abstract void ExecuteAction();


        private DelegateCommand cancel;
        public DelegateCommand Cancel => cancel ??= new DelegateCommand(() =>
        {
            gameController.ChangeState(gameController.GameState);
        });

    }
}
