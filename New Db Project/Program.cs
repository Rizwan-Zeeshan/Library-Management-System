namespace New_Db_Project
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        //[STAThread]
        //static void Main()
        //{
        //    // To customize application configuration such as set high DPI settings or default font,
        //    // see https://aka.ms/applicationconfiguration.
        //    ApplicationConfiguration.Initialize();
        //    Application.Run(new Login());
        //    Application.Run(new Form1());
        //}
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Login loginForm = new Login(); // Create an instance of the LoginForm
            Application.Run(loginForm); // Run the LoginForm

            // Check if the LoginForm is closed before opening Form1
            if (loginForm.DialogResult == DialogResult.OK)
            {
                Application.Run(new Form1());
            }
        }

    }
}


