namespace TestApp.Maui
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            DigitalClockLabel.BindingContext = this.BindingContext;

            var timer = DigitalClockLabel.Dispatcher.CreateTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += (s, e) => UpdateDigitalClock();
            timer.Start();
        }

        private void UpdateDigitalClock()
        {
            DigitalClockLabel.Dispatcher.Dispatch(
                       () =>
                       {
                           DigitalClockLabel.Text = DateTime.Now.ToString("HH:mm:ss");
                       });
        }

        //protected override void OnAppearing()
        //{
        //    base.OnAppearing();
        //    Device.StartTimer(TimeSpan.FromSeconds(1), () =>
        //    {
        //        UpdateDigitalClock();
        //        return true; // Continue updating
        //    });
        //}

        //private void UpdateDigitalClock()
        //{
        //    Device.BeginInvokeOnMainThread(
        //               () =>
        //               {
        //                   DigitalClockLabel.Text = DateTime.Now.ToString("HH:mm:ss");
        //               });
        //}
    }

}
