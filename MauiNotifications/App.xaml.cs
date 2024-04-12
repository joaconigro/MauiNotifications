namespace MauiNotifications
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }

        //protected override Window CreateWindow(IActivationState? activationState)
        //{
        //    Window window = base.CreateWindow(activationState);

        //    window.Stopped += (s, e) =>
        //    {
        //        Console.WriteLine(e);
        //    };


        //    window.Deactivated += (s, e) =>
        //    {
        //        Console.WriteLine(e);
        //    };

        //    window.Resumed += (s, e) =>
        //    {
        //        Console.WriteLine(e);
        //    };

        //    return window;
        //}
    }
}
