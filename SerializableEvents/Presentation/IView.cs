using System.Windows.Forms;

namespace SerializableEvents.Presentation
{
    public interface IView
    {
        void Show();
        DialogResult ShowDialog();
    }
}
