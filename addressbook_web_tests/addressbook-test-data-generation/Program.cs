using WebAddressbookTests;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Excel = Microsoft.Office.Interop.Excel;
using System.Text.RegularExpressions;

namespace addressbook_test_data_generator
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = args[0];
            int count = Convert.ToInt32(args[1]);
            string filename = args[2];
            string format = args[3];
            if (type == "group")
            {
                List<GroupData> groups = new List<GroupData>();
                for (int i = 0; i < count; i++)
                {
                    groups.Add(new GroupData(TestBase.GenerateRandomString(10))
                    {
                        Header = TestBase.GenerateRandomString(100),
                        Footer = TestBase.GenerateRandomString(100)
                    });
                }
                StreamWriter writer = new StreamWriter(filename, false);

                if (format == "csv")
                    WriteGroupsToCSV(groups, writer);
                else if (format == "xml")
                    WriteGroupsToXML(groups, writer);
                else if (format == "json")
                    WriteGroupsToJson(groups, writer);
                else Console.WriteLine("Unrecognized format " + format);
                writer.Close();
                
            }
            else if (type == "contact")
            {
                List<ContactData> contacts = new List<ContactData>();
                for (int i = 0; i < count; i++)
                {
                    contacts.Add(new ContactData(TestBase.GenerateRandomString(100), TestBase.GenerateRandomString(100)));
                }

                StreamWriter writer = new StreamWriter(filename, false);
                if (format == "xml")
                    WriteContactsToXml(contacts, writer);
                else if (format == "json")
                    WriteContactsToJson(contacts, writer);
                else Console.WriteLine("Unrecognized format " + format);
                writer.Close();
            }
            else Console.WriteLine("Unrecognized type " + type);

        }

        static void WriteGroupsToCSV(List<GroupData> groups, StreamWriter writer)
        {
            foreach (GroupData group in groups) 
            {
                writer.WriteLine(String.Format("${0},${1},${2}",
                    group.Name, group.Header, group.Footer));
            }
        }

        static void WriteGroupsToXML(List<GroupData> groups, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<GroupData>)).Serialize(writer,groups);
        }

        static void WriteGroupsToJson(List<GroupData> groups, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(groups, Newtonsoft.Json.Formatting.Indented));
        }

        static void WriteGroupsToExcel(List<GroupData> groups, string filename)
        {
            Excel.Application app = new Excel.Application();
            app.Visible = true;
            Excel.Workbook wb = app.Workbooks.Add();
            Excel.Worksheet sheet = app.ActiveSheet;
            int row = 1;
            foreach (GroupData group in groups)
            {
                sheet.Cells[row, 1] = group.Name;
                sheet.Cells[row, 2] = group.Header;
                sheet.Cells[row, 3] = group.Footer;
                row++;
            }
            string fullPath = Path.Combine(Directory.GetCurrentDirectory(), filename);
            File.Delete(fullPath);
            wb.SaveAs(fullPath);
            wb.Close();
            app.Visible = false;
            app.Quit();
        }

        static void WriteContactsToXml(List<ContactData> contacts, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<ContactData>)).Serialize(writer, contacts);
        }

        static void WriteContactsToJson(List<ContactData> contacts, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(contacts, Newtonsoft.Json.Formatting.Indented));
        }
    }
}