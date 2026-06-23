Logger logger1 = Logger.GetInstance();
Logger logger2 = Logger.GetInstance();

logger1.Log("Application Started");

Console.WriteLine(
    ReferenceEquals(logger1, logger2)
);