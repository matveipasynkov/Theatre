using Library;

class Program
{
    static void Main()
    {
        do
        {
            // Каждая итерация с чистой консоли.
            Console.Clear();

            try
            {
                string[][] data = Checks.CheckFormat();
                Theatre[] theatres = DataTransformation.TransformToListOfTheatres(data);

                Console.Clear();

                InteractWithUser.PrintMenu();

                InteractWithUser.Menu(theatres);

                Console.WriteLine("Выполнено!");
            }
            catch (Exception)
            {
                Console.WriteLine("Произошла непредвиденная ошибка");
            }
            finally
            {
                Console.WriteLine("Нажмите ESC, чтобы продолжить. Иначе нажмите любую другую кнопку.");
            }
        }
        while (Console.ReadKey().Key == ConsoleKey.Escape);
    }
}