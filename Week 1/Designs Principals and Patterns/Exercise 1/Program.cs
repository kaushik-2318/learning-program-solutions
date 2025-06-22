using System;
using System.Threading.Tasks;

namespace SingletonPatternExample
{
    public sealed class Logger
    {
        private static Logger _instance = null;
        private static readonly object _lock = new object();
        
        private Logger()
        {
            Console.WriteLine("Logger instance initialized.");
        }
        
        public static Logger GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new Logger();
                    }
                }
            }
            return _instance;
        }
        
        public void Log(string message)
        {
            Console.WriteLine($"[LOG] {DateTime.Now}: {message}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Testing Singleton Pattern for Logger");
            
            Logger logger1 = Logger.GetInstance();
            Logger logger2 = Logger.GetInstance();
            
            Console.WriteLine($"Are both instances the same? {ReferenceEquals(logger1, logger2)}");
            
            logger1.Log("First log message");
            logger2.Log("Second log message");
            
            Parallel.For(0, 5, i => {
                Logger logger = Logger.GetInstance();
                logger.Log($"Message from thread {i}");
            });
            
            Console.WriteLine("All tests completed.");
        }
    }
}