using NUnit.Framework;
using System.Collections.Generic;
using System.IO;

namespace mantis_tests
{
    /// <summary>
    /// Summary description for AccountCreationTests
    /// </summary>
    [TestFixture]
    public class AccountCreationTests : TestBase
    {
        [TestFixtureSetUp]
        public void SetUpConfig()
        {
            app.FTPHelper.BackupFile("config_inc.php");
            using (Stream localFile = File.Open("config_inc.php", FileMode.Open))
            {
                app.FTPHelper.Upload("/config_inc.php", localFile);
            }
        }

        [Test]
        public void TestAccountRegistration()
        {
              
            AccountData account = new AccountData() {
                Name = "testuser",
                Password = "password",
                Email = "testuser@localhost.localdomain"
            };

            List<AccountData> accounts = app.Admin.GetAllAccounts();
            AccountData existingAccount = accounts.Find(x => x.Name == account.Name);
            if (existingAccount != null)
            {
                app.Admin.DeleteAccount(existingAccount);
            }
            app.James.Delete(account);
            app.James.Add(account);

            app.Registration.Register(account);
        }
        [TestFixtureTearDown]
        public void restoreConfig()
        {
            app.FTPHelper.RestoreBackupFile("");
        }
    }
}
