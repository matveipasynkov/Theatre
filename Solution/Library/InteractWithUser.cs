using System;
namespace Library;

/// <summary>
/// Данный класс содержит методы, которые взаимодействуют с пользователем (например выводят меню на консоль, данные и т.д.).
/// </summary>
public static class InteractWithUser
{
    /// <summary>
    /// Массив названий столбцов.
    /// </summary>
    private static string[] Columns = { "ROWNUM", "CommonName", "FullName",
                                               "ShortName", "AdmArea", "District",
                                               "Address", "ChiefName", "ChiefPosition",
                                               "PublicPhone", "Fax", "Email",
                                               "WorkingHours", "ClarificationOfWorkingHours", "WebSite",
                                               "OKPO", "INN", "MainHallCapacity",
                                               "AdditionalHallCapacity", "X_WGS", "Y_WGS",
                                               "GLOBALID" };

    /// <summary>
    /// Enum, содержащий два типа демонстрации данных (верхние строки или нижние).
    /// </summary>
    public enum Types
    {
        Top,
        Bottom,
    }

    /// <summary>
    /// Enum, содержащий два типа сортировки (по возрастанию или убыванию).
    /// </summary>
    public enum SortingType
    {
        Increase,
        Decrease,
    }

    /// <summary>
    /// Метод, демонстрирующий первые или последних N строк из данных.
    /// </summary>
    /// <param name="theatres"></param>
    public static void ShowTheData(Theatre[] theatres)
	{
        Types type = (Types)Checks.CheckTypeOfShowingData();
        int n = Checks.CheckNumberOfRows(theatres);

        if (type == Types.Top)
        {
            PrintData(theatres[..n], type, theatres.Length);
        }
        else
        {
            PrintData(theatres[^n..], type, theatres.Length);
        }
	}

    /// <summary>
    /// Метод, выводящий данные на экран.
    /// </summary>
    /// <param name="theatres"></param>
    /// <param name="type"></param>
    /// <param name="allLines"></param>
    public static void PrintData(Theatre[] theatres, Types type, int allLines)
    {
        int[] numsOfElemInCell = { 7, 72, 147, 70, 40, 20, 60, 35, 15, 50, 15, 30, 170, 65, 25, 10, 10, 16, 22, 10, 10, 10 };

        for (int i = 0; i < theatres.Length + 1; ++i)
        {
            if (i == 0)
            {
                for (int j = 0; j < Columns.Length; ++j)
                {
                    Console.Write($"{Columns[j].PadRight(numsOfElemInCell[j])}|");
                }

                Console.WriteLine();
                Console.Write(new string('-', numsOfElemInCell.Sum() + numsOfElemInCell.Count() + 1));
            }
            else
            {
                string[] row = DataTransformation.TransformTheatreToArray(theatres[i - 1]);

                for (int j = 0; j < Columns.Length; ++j)
                {
                    if (j == 0)
                    {
                        if (type == Types.Top)
                        {
                            Console.Write($"{i.ToString().PadRight(numsOfElemInCell[0])}|");
                        }
                        else
                        {
                            Console.Write($"{(allLines - theatres.Length + i).ToString().PadRight(numsOfElemInCell[0])}|");
                        }
                    }
                    else
                    {
                        Console.Write($"{row[j - 1].PadRight(numsOfElemInCell[j])}|");
                    }
                }
            }

            Console.WriteLine();
        }

        Console.WriteLine();
    }

    /// <summary>
    /// Метод, выводящий меню.
    /// </summary>
    public static void PrintMenu()
    {
        Console.WriteLine("Выберите один из следующих пунктов:");
        Console.WriteLine("    1. Отсортировать таблицу театров в зависимости от их вместимости.");
        Console.WriteLine("    2. Произвести фильтрацию по значению ChiefName.");
        Console.WriteLine("    3. Произвести фильтрацию по значению AdmArea.");
        Console.WriteLine("    4. Показать первые или последние N строк таблицы.");
    }

    /// <summary>
    /// Метод, реализующий консольное меню.
    /// </summary>
    /// <param name="theatres"></param>
    public static void Menu(Theatre[] theatres)
    {
        int cmd = Checks.CheckMenuCommand();
        Theatre[] result = new Theatre[0];

        Console.Clear();

        if (cmd == 1)
        {
            // В качестве альтернативного решения можно использовать другие виды сортировок, которые хранятся в Sortings (например BubbleSort).
            result = Sortings.DefaultSort(theatres);

            SortingType typeOfSorting = (SortingType)Checks.CheckTypeOfSorting();

            if (typeOfSorting == SortingType.Decrease)
            {
                Array.Reverse(result);
            }
        }
        else if (cmd == 2)
        {
            result = Filtration.FiltrationByChiefName(theatres);
        }
        else if (cmd == 3)
        {
            result = Filtration.FiltrationByAdmArea(theatres);
        }
        else
        {
            ShowTheData(theatres);
        }

        if (cmd >= 1 && cmd <= 3)
        {
            if (result.Length == 0)
            {
                Console.WriteLine("Результат пуст.");
            }
            else
            {
                PrintData(result, Types.Top, result.Length);
                SaveTheData(result);
            }
        }
    }

    /// <summary>
    /// Метод, сохраняющий данные в результате сортировки или фильтрации.
    /// </summary>
    /// <param name="theatres"></param>
    public static void SaveTheData(Theatre[] theatres)
    {
        int typeOfSaving = Checks.CheckTypeOfSaving();

        if (typeOfSaving == 1)
        {
            string path = Checks.CheckExistenceOfFile(0);

            string[][] data = DataTransformation.TransformArrayOfTheatresToArrayString(Columns, theatres);

            try
            {
                CsvProcessing.FirstTypeOfSaving(data, path);
            }
            catch
            {
                Console.WriteLine("Путь некорректного формата. Попробуйте ещё раз.");
                SaveTheData(theatres);
            }
        }
        else if (typeOfSaving == 2)
        {
            string path = Checks.CheckExistenceOfFile(1);

            string[][] data = DataTransformation.TransformArrayOfTheatresToArrayString(Columns, theatres);

            try
            {
                CsvProcessing.FirstTypeOfSaving(data, path);
            }
            catch
            {
                Console.WriteLine("Путь некорректного формата. Попробуйте ещё раз.");
                SaveTheData(theatres);
            }
        }
        else
        {
            string path = Checks.CheckExistenceOfFile(1);

            string[][] data = DataTransformation.TransformArrayOfTheatresToArrayString(Columns, theatres);

            try
            {
                CsvProcessing.SecondTypeOfSaving(data, path);
            }
            catch
            {
                Console.WriteLine("Путь некорректного формата. Попробуйте ещё раз.");
                SaveTheData(theatres);
            }
        }
    }
}