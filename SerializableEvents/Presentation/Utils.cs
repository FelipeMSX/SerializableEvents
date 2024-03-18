using System.ComponentModel;

namespace SerializableEvents.Presentation
{
    public static class Utils
    {
        public static bool IsDesignMode()
        {
            return System.Diagnostics.Process.GetCurrentProcess().ProcessName == "devenv";
        }
    }
}
