using System.Windows.Forms;

namespace SerializableEvents.Presentation
{
    internal abstract class Presenter<TView> where TView : IView
    {
        protected TView View { get; private set; }

        protected IModel Model { get; private set; }

        protected Presenter(TView view)
        {
            View = view;
        }

        protected Presenter(TView view, IModel model)
        {
            View = view;
            Model = model;
        }

        public void Show()
        {
            View.Show();
        }

        //Encapsular o Dialog em um objeto próprio
        public DialogResult ShowDialog()
        {
            return View.ShowDialog();
        }

    }
}
