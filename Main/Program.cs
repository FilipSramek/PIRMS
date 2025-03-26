using Project.Drivers;


namespace Project.Main
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Serial serial = new Serial();
            serial.Initialize("COM1", 9600);



            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }
    }
}