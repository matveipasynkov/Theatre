using System;
namespace Library;

/// <summary>
/// Класс, содержащий методы фильтраций.
/// </summary>
public static class Filtration
{
	/// <summary>
	/// Метод, осуществляющий фильтрацию по имени директора театра.
	/// </summary>
	/// <param name="data"></param>
	/// <returns></returns>
	public static Theatre[] FiltrationByChiefName(Theatre[] data)
	{
		Console.Write("Введите имя директора театра: ");

		string name = Console.ReadLine();

		Theatre[] result = new Theatre[0];

		for (int i = 0; i < data.Length; ++i)
		{
			Theatre theatre = data[i];

			if (theatre.ChiefName == name)
			{
				Array.Resize(ref result, result.Length + 1);
				result[^1] = theatre;
			}
		}

		return result;
	}

	/// <summary>
	/// Метод, осуществляющий фильтрацию по названию административного округа.
	/// </summary>
	/// <param name="data"></param>
	/// <returns></returns>
	public static Theatre[] FiltrationByAdmArea(Theatre[] data)
	{
        Console.Write("Введите название административного округа: ");

        string name = Console.ReadLine();

        Theatre[] result = new Theatre[0];

        for (int i = 0; i < data.Length; ++i)
        {
            Theatre theatre = data[i];

            if (theatre.ContactsOfTheatre.AdmArea == name)
            {
                Array.Resize(ref result, result.Length + 1);
                result[^1] = theatre;
            }
        }

        return result;
    }
}