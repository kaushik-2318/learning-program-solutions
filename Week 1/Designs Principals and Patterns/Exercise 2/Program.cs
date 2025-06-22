using System;

namespace FactoryMethodPatternExample
{

    public interface IDocument
    {
        void Open();
        void Save();
        void Close();
    }


    public class WordDocument : IDocument
    {
        public void Open()
        {
            Console.WriteLine("Opening Word document...");
        }

        public void Save()
        {
            Console.WriteLine("Saving Word document...");
        }

        public void Close()
        {
            Console.WriteLine("Closing Word document...");
        }
    }

    public class PdfDocument : IDocument
    {
        public void Open()
        {
            Console.WriteLine("Opening PDF document...");
        }

        public void Save()
        {
            Console.WriteLine("Saving PDF document...");
        }

        public void Close()
        {
            Console.WriteLine("Closing PDF document...");
        }
    }

    public class ExcelDocument : IDocument
    {
        public void Open()
        {
            Console.WriteLine("Opening Excel document...");
        }

        public void Save()
        {
            Console.WriteLine("Saving Excel document...");
        }

        public void Close()
        {
            Console.WriteLine("Closing Excel document...");
        }
    }


    public abstract class DocumentFactory
    {
        public abstract IDocument CreateDocument();

        public void ProcessDocument()
        {
            var document = CreateDocument();
            document.Open();
            document.Save();
            document.Close();
        }
    }

    public class WordDocumentFactory : DocumentFactory
    {
        public override IDocument CreateDocument()
        {
            return new WordDocument();
        }
    }

    public class PdfDocumentFactory : DocumentFactory
    {
        public override IDocument CreateDocument()
        {
            return new PdfDocument();
        }
    }

    public class ExcelDocumentFactory : DocumentFactory
    {
        public override IDocument CreateDocument()
        {
            return new ExcelDocument();
        }
    }

    // Test the implementation
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Document Management System");
            Console.WriteLine("--------------------------");

            DocumentFactory factory;

            factory = new WordDocumentFactory();
            Console.WriteLine("\nCreating Word Document:");
            factory.ProcessDocument();


            factory = new PdfDocumentFactory();
            Console.WriteLine("\nCreating PDF Document:");
            factory.ProcessDocument();

            factory = new ExcelDocumentFactory();
            Console.WriteLine("\nCreating Excel Document:");
            factory.ProcessDocument();
        }
    }
}