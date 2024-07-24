using System;
namespace Library;

/// <summary>
/// Класс, обрабатывающий csv-файл.
/// </summary>
public static class CsvProcessing
{
    /// <summary>
    /// Метод, получающий данные из csv.
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public static string[][] GetCsv(string path)
    {
        try
        {
            string[] readData = File.ReadAllLines(path);

            return DataTransformation.TransformCSVToMultiDimensional(readData);
        }
        catch
        {
            throw new ArgumentException();
        }

    }

    /// <summary>
    /// Метод, сохраняющий данные по первому типу (то есть перезаписывает существующий файл или создаёт файл и записывает туда данные).
    /// </summary>
    /// <param name="data"></param>
    /// <param name="path"></param>
    /// <exception cref="ArgumentException"></exception>
    public static void FirstTypeOfSaving(string[][] data, string path)
    {
        try
        {
            string[] lines = DataTransformation.TransformToOneDimensional(data);
            lines = DataTransformation.AddIdOfRows(lines);

            File.WriteAllLines(path, lines);
        }
        catch
        {
            throw new ArgumentException();
        }
    }

    /// <summary>
    /// Метод, сохраняющий данные по второму типу (то есть дополняет данные в уже существующий файл).
    /// </summary>
    /// <param name="data"></param>
    /// <param name="path"></param>
    /// <exception cref="ArgumentException"></exception>
    public static void SecondTypeOfSaving(string[][] data, string path)
    {
        try
        {
            string[] lines = DataTransformation.TransformToOneDimensional(data);
            lines = DataTransformation.AddIdOfRows(lines);

            File.AppendAllLines(path, lines[1..]);
        }
        catch
        {
            throw new ArgumentException();
        }
    }

    /// <summary>
    /// Метод, возвращающий индекс значения в массиве, который принадлежит нужному столбцу.
    /// </summary>
    /// <param name="data"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public static int IndexOfColumn(string[][] data, string name)
    {
        int index = Array.IndexOf(data[0], name);

        if (index == -1)
        {
            throw new ArgumentOutOfRangeException();
        }
        else
        {
            return index;
        }
    }
}