using System;
using TestStack.White;
using WhiteLibrary;

namespace CSWhiteLibrary
{
	public partial class Keywords : WhiteFW
    {
        private Application app;

        public void launch_application(string sut)
        {
            app = Application.Launch(sut);
        }

        public void close_application()
        {
            app.Close();
        }
    }
}
