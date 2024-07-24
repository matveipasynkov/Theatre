using System;
using System.Security.AccessControl;
using System.Security.Cryptography.X509Certificates;

namespace Library;

/// <summary>
/// Класс, содержащий методы преобразования массивов из одних типов в другие.
/// </summary>
public static class DataTransformation
{
    /// <summary>
    /// Метод, преобразующий зубчатый массив string[][] data в массив объектов Theatre.
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
	public static Theatre[] TransformToListOfTheatres(string[][] data)
	{
		Theatre[] theatres = new Theatre[data.GetLength(0) - 1];

		for (int i = 1; i < theatres.Length + 1; ++i)
		{
			string[] row = data[i];

			string address = row[CsvProcessing.IndexOfColumn(data, "Address")];
			string publicphone = row[CsvProcessing.IndexOfColumn(data, "PublicPhone")];
            string fax = row[CsvProcessing.IndexOfColumn(data, "Fax")];
            string district = row[CsvProcessing.IndexOfColumn(data, "District")];
            string admArea = row[CsvProcessing.IndexOfColumn(data, "AdmArea")];
            string commonName = row[CsvProcessing.IndexOfColumn(data, "CommonName")];
            string fullName = row[CsvProcessing.IndexOfColumn(data, "FullName")];
            string shortName = row[CsvProcessing.IndexOfColumn(data, "ShortName")];
            string chiefName = row[CsvProcessing.IndexOfColumn(data, "ChiefName")];
            string chiefPosition = row[CsvProcessing.IndexOfColumn(data, "ChiefPosition")];
            string email = row[CsvProcessing.IndexOfColumn(data, "Email")];
            string workingHours = row[CsvProcessing.IndexOfColumn(data, "WorkingHours")];
            string clarificationOfWorkingHours = row[CsvProcessing.IndexOfColumn(data, "ClarificationOfWorkingHours")];
            string website = row[CsvProcessing.IndexOfColumn(data, "WebSite")];
            string okpo = row[CsvProcessing.IndexOfColumn(data, "OKPO")];
            string inn = row[CsvProcessing.IndexOfColumn(data, "INN")];
            string mainHallCapacity = row[CsvProcessing.IndexOfColumn(data, "MainHallCapacity")];
            string additionalHallCapacity = row[CsvProcessing.IndexOfColumn(data, "AdditionalHallCapacity")];
            string x_WGS = row[CsvProcessing.IndexOfColumn(data, "X_WGS")];
            string y_WGS = row[CsvProcessing.IndexOfColumn(data, "Y_WGS")];
            string globalId = row[CsvProcessing.IndexOfColumn(data, "GLOBALID")];

            theatres[i - 1] = new Theatre(commonName, fullName, shortName,
                admArea, district, address, chiefName, chiefPosition,
                publicphone, fax, email, workingHours, clarificationOfWorkingHours,
                website, okpo, inn, mainHallCapacity, additionalHallCapacity,
                x_WGS, y_WGS, globalId);
        }

        return theatres;
	}

    /// <summary>
    /// Метод, преобразующий зубчатый массив в одномерный.
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public static string[] TransformToOneDimensional(string[][] data)
    {
        string[] lines = new string[data.GetLength(0)];

        for (int i = 0; i < data.GetLength(0); ++i)
        {
            string row = "";

            for (int j = 0; j < data[i].Length; ++j)
            {
                // Если строка не является шапкой таблицы, то каждый её элемент должен содержать кавычки.
                if (i > 0)
                {
                    row += "\"" + data[i][j] + "\"" + ";";
                }
                // А если является, то названия столбцов должны быть без кавычек.
                else
                {
                    row += data[i][j] + ";";
                }
            }

            lines[i] = row;
        }

        return lines;
    }

    /// <summary>
    /// Данный метод преобразует массив строк, полученных из csv-файла в зубчатый массив.
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public static string[][] TransformCSVToMultiDimensional(string[] data)
    {
        string[][] csvFile = new string[data.Length][];

        string[] columns = data[0][..^1].Split(';');

        csvFile[0] = columns;

        for (int i = 1; i < data.Length; ++i)
        {
            string[] row = new string[columns.Length];
            int indexStart = 0;
            int index = 0;

            for (int j = 0; j < data[i].Length - 1; ++j)
            {
                if (data[i][j] == ';' & data[i][j..(j + 2)] != "; ")
                {
                    if (index == 0)
                    {
                        row[index] = data[i][indexStart..j];
                    }
                    else
                    {
                        // Обрезаем кавычки, если значение строки не принадлежит столбцу ROWNUM.
                        row[index] = data[i][indexStart..j][1..^1];
                    }

                    indexStart = j + 1;
                    ++index;
                }
            }

            row[^1] = data[i][indexStart..^1][1..^1];
            csvFile[i] = row;
        }

        return csvFile;
    }

    /// <summary>
    /// Метод, преобразующий объект Theatre в одномерный массив строк.
    /// </summary>
    /// <param name="theatre"></param>
    /// <returns></returns>
    public static string[] TransformTheatreToArray(Theatre theatre)
    {
        string[] infoAboutTheatre = {theatre.CommonName, theatre.FullName, theatre.ShortName,
            theatre.ContactsOfTheatre.AdmArea, theatre.ContactsOfTheatre.District, theatre.ContactsOfTheatre.Address, theatre.ChiefName,
            theatre.ChiefPosition, theatre.ContactsOfTheatre.PublicPhone, theatre.ContactsOfTheatre.Fax,
            theatre.ContactsOfTheatre.Email, theatre.WorkingHours, theatre.ClarificationOfWorkingHours,
            theatre.ContactsOfTheatre.WebSite, theatre.Okpo.ToString(), theatre.Inn.ToString(), theatre.MainHallCapacity.ToString(),
            theatre.AdditionalHallCapacity.ToString(), theatre.XWGS.ToString(), theatre.YWGS.ToString(), theatre.GlobalId.ToString()};

        return infoAboutTheatre;
    }

    /// <summary>
    /// Метод, преобразующий массив объектов Theatre в двумерный массив строк.
    /// </summary>
    /// <param name="columns"></param>
    /// <param name="theatres"></param>
    /// <returns></returns>
    public static string[][] TransformArrayOfTheatresToArrayString(string[] columns, Theatre[] theatres)
    {
        string[][] data = new string[theatres.Length + 1][];
        data[0] = columns[..];

        for (int i = 1; i < data.Length; ++i)
        {
            data[i] = TransformTheatreToArray(theatres[i - 1]);
        }

        return data;
    }

    /// <summary>
    /// Метод, добавляющий строкам таблицы их номер (кроме шапки таблицы).
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public static string[] AddIdOfRows(string[] data)
    {
        string[] result = new string[data.Length];
        result[0] = data[0];

        for (int i = 1; i < result.Length; ++i)
        {
            result[i] = i.ToString() + ";" + data[i];
        }

        return result;
    }
}