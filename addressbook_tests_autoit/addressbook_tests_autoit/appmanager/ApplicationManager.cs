using AutoItX3Lib;

namespace addressbook_tests_autoit
{
    public class ApplicationManager
    {
        public static string WINTITLE = "Free Address Book";
        private AutoItX3 aux;
        public ApplicationManager() 
        {
            aux = new AutoItX3();
            aux.Run(@"D:\Downloads\FreeAddressBookPortable\AddressBook.exe", "", aux.SW_SHOW);
            aux.WinWait(WINTITLE);
            aux.WinActivate(WINTITLE);
            aux.WinWaitActive(WINTITLE);
            groupHelper = new GroupHelper(this);
        }

        public AutoItX3 Aux
        {
            get
            {
                return aux;
            }
        }

        private GroupHelper groupHelper;
        public void Stop()
        {
            aux.ControlClick(WINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d510");
        }
        public GroupHelper Groups
        {
            get
            {
                return groupHelper;
            }
        }
    }
}
