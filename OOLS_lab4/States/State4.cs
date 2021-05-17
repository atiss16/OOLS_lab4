using DevExpress.Mvvm;
using OOLS_lab4.Models;
using OOLS_lab4.ViewModels;
using System.Collections.ObjectModel;
using System.Windows;

namespace OOLS_lab4.States
{
    public class State4 : State
    {
        public State4(MainViewModel gameController) : base(gameController)
        {
            ActionOptions.Add(new ActionOption("Спросить, что именно нужно просчитать и почему Якоба может испепелить?", AboutTaskInfo));
            ActionOptions.Add(new ActionOption("Спросить, почему Ньют сам не может себе помочь, в конце концов:" +
                " у кого из вас волшебная палочка?", WhyMeInfo));
            ActionOptions.Add(new ActionOption("Согласиться", NextState));
            ActionOptions.Add(new ActionOption("Поблагодарить Ньюта за доверие, сослаться на скорую практику" +
                " и завал по учебе, после чего удалиться.", Surrender));
        }
        public override ObservableCollection<ActionOption> ActionOptions { get; set; }
        public override string TaskText => "Якоб начал убеждать Ньюта, что он ни за что не останется просто" +
            " сидеть дома и ждать Куини и, что ему все равно, если его испепелит Гриндевальд: «Так мне и надо, " +
            "если испепелит! Нечего было вместо математики в школе печь пироги!». Тут Ньют внимательно посмотрел " +
            "на Вас и сказал: «Мой друг, магия не всегда может спасти мир. Математика – куда важнее и сильнее, поэтому " +
            "я вынужден просить тебя о помощи – сможешь ли ты произвести точные расчеты и провести Якоба и моих питомцев " +
            "через границу Нурменграда?»";

        private DelegateCommand aboutTaskInfo;
        public DelegateCommand AboutTaskInfo => aboutTaskInfo ??= new DelegateCommand(() =>
        {
            MessageBox.Show("Нужно придумать как отправить его так, чтобы никто не пострадал. " +
                "Дело в том, что уровень волшебной силы был равен 80, иначе его могут испепелить.");
        });

        private DelegateCommand whyMeInfo;
        public DelegateCommand WhyMeInfo => whyMeInfo ??= new DelegateCommand(() =>
        {
            MessageBox.Show("Волшебство не может решить все проблемы само по себе, нужна еще помощь ума и сообразительности");
        });

        private DelegateCommand nextState;
        public DelegateCommand NextState => nextState ??= new DelegateCommand(() =>
        {
            gameController.ChangeState(new State5(gameController));
        });
    }
}
