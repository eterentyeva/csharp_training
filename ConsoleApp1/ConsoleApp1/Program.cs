using System;
using System.Diagnostics.Metrics;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace ReadATextFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string filepath = GetFilePath();
            Filemanager filemanager = new Filemanager(filepath);
            filemanager.ShowTextFromFile();
            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey();
                if (key.Key == ConsoleKey.Escape)
                    break;
                if (key.Key == ConsoleKey.F1)
                {
                    string savePath = GetFilePath();
                    Console.Clear();
                    filemanager.SerializeText(savePath);
                }
            }
            while (key.Key != ConsoleKey.Escape || key.Key != ConsoleKey.F1);
        }

        private static string GetFilePath()
        {
            Console.WriteLine("введите путь к файлу");
            return Console.ReadLine();
        }
    }

    class Filemanager
    {
        private string FilePath { get; set; }
        public List<Figure> Figures { get; set; } = new List<Figure>();

        public Filemanager() { }

        public Filemanager(string path)
        {
            FilePath = path;
        }
        public void ShowTextFromFile()
        {
            string[] format = FilePath.Split(".");
            Console.Clear();
            switch (format[format.Length - 1])
            {
                case "txt":
                    ShowTextFromTXT();
                    break;
                case "json":
                    ShowTextFromJSON();
                    break;
                case "xml":
                    ShowTextFromXML();
                    break;
            }
        }

        public void SerializeText(string filePath)
        {
            string[] format = filePath.Split(".");
            Console.Clear();
            switch (format[format.Length - 1])
            {
                case "txt":
                    SerializeTXT(filePath);
                    break;
                case "json":
                    SerializeJSON(filePath);
                    break;
                case "xml":
                    SerializeXML(filePath);
                    break;
            }
        }

        private void ShowTextFromTXT()
        {
            if (File.Exists(FilePath))
            {
                GetFiguresFromTXTFile();
                WriteTextToConsole();
            }
        }

        private void ShowTextFromJSON()
        {
            if (File.Exists(FilePath))
            {
                GetFiguresFromJSONFile();
                WriteTextToConsole();
            }
        }
        private void ShowTextFromXML()
        {
            if (File.Exists(FilePath))
            {
                GetFiguresFromXMLFile();
                WriteTextToConsole();
            }
        }

        private void GetFiguresFromTXTFile()
        {
            string[] lines = File.ReadAllLines(FilePath);
            for (int i = 0; i < lines.Length; i++)
            {
                if (i % 3 == 0)
                    Figures.Add(new Figure(lines[i], Int32.Parse(lines[i + 1]), Int32.Parse(lines[i + 2])));
            }
        }
        private void GetFiguresFromJSONFile()
        {
            string text = File.ReadAllText(FilePath);

            Figures = JsonSerializer.Deserialize<List<Figure>>(text);
        }
        private void GetFiguresFromXMLFile()
        {
            XmlRootAttribute xRoot = new XmlRootAttribute();
            xRoot.ElementName = "root";
            xRoot.IsNullable = true;
            XmlSerializer mySerializer = new XmlSerializer(typeof(List<FigureXML>), xRoot);
            List<FigureXML> xmlData = new List<FigureXML>();
            using (FileStream myFileStream = new FileStream(FilePath, FileMode.Open))
            {
                xmlData = (List<FigureXML>)mySerializer.Deserialize(myFileStream);
            }
            XMLDataToFigure(xmlData);
        }

        private void XMLDataToFigure(List<FigureXML> datas)
        {
            foreach(FigureXML data in datas)
            {
                Figures.Add(new Figure(data.Title, data.Height, data.Width));
            }
        }

        private void SerializeTXT(string filepath) 
        {
            using (StreamWriter SW = new StreamWriter(filepath))
            {
                foreach (Figure figure in Figures)
                {
                    SW.WriteLine(figure.Title);
                    SW.WriteLine(figure.Height);
                    SW.WriteLine(figure.Width);
                }
            }
        }

        private void SerializeJSON(string filepath) 
        {
            using FileStream createStream = File.Create(filepath);
            JsonSerializer.SerializeAsync(createStream, Figures);
            Console.WriteLine("file created");
        }

        private void SerializeXML(string filepath) 
        {
            List<FigureXML> figures = FigureToXML();
            XmlSerializer inst = new XmlSerializer(typeof(List<FigureXML>));
            TextWriter writer = new StreamWriter(filepath);
            inst.Serialize(writer, figures);
            writer.Close();
        }

        private List<FigureXML> FigureToXML()
        {
            List<FigureXML> result = new List<FigureXML>();
            foreach(Figure figure in Figures)
            {
                result.Add(new FigureXML(figure.Title, figure.Height, figure.Width));
            }
            return result;
        }

        private void WriteTextToConsole()
        {
            foreach (Figure f in Figures)
            {
                Console.WriteLine(f.Title);
                Console.WriteLine(f.Height);
                Console.WriteLine(f.Width);
            }
        }
    }

    class Figure
    {
        public string Title { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }

        public Figure(string title, int height, int width)
        {
            Title = title;
            Height = height;
            Width = width;
        }
    }

    [XmlType("Figure")]
    public class FigureXML
    {
        [XmlElement("Title")]
        public string Title { get; set; }
        [XmlElement("Height")]
        public int Height { get; set; }
        [XmlElement("Width")]
        public int Width { get; set; }
        public FigureXML() { }

        public FigureXML(string title, int height, int width) 
        {
            Title = title;
            Height = height;
            Width = width;
        }
    }
}