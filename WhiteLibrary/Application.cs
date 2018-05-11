using System;
using TestStack.White;
using WhiteLibrary;

namespace CSWhiteLibrary
{
	public partial class Keywords : WhiteFW
    {

		public void launch_application(string sut)
        {
            this.app = Application.Launch(sut);
        }
    }
}
