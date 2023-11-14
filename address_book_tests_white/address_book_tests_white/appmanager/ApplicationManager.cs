using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.WindowItems;


namespace address_book_tests_white

{
    public class ApplicationManager
    {
        public static string WINTITLE = "Free Address Book";
        public ApplicationManager() 
        {
            Application app = Application.Launch(@"D:\Downloads\FreeAddressBookPortable\AddressBook.exe");
            MainWindow = app.GetWindow(WINTITLE);

            groupHelper = new GroupHelper(this);
        }

        public Window MainWindow { get; private set; }

        private GroupHelper groupHelper;
        public void Stop()
        {
            MainWindow.Get<Button>("uxExitAddressButton").Click();
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
