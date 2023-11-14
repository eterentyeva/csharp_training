
namespace address_book_tests_white

{
    public class HelperBase
    {
        protected ApplicationManager manager;
        protected string WINTITLE;

        public HelperBase(ApplicationManager manager) 
        {
            this.manager = manager;
            WINTITLE = ApplicationManager.WINTITLE;
        }
    }
}