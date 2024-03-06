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
    }
}
