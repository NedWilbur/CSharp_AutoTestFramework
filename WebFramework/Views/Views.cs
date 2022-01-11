using _WebFramework.Views.Home;

namespace WebFramework
{
    /// <summary>
    /// Home for all defined POMs
    /// </summary>
    public class Views
    {
        public HomeView Home { get; }

        public Views()
        {
            Home = new HomeView();
        }
    }
}