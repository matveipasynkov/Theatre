using System;
namespace Library;

/// <summary>
/// Класс, содержащий различные виды сортировок.
/// </summary>
public static class Sortings
{
	/// <summary>
	/// Метод, реализующий обычную сортировку.
	/// </summary>
	/// <param name="data"></param>
	/// <returns></returns>
	public static Theatre[] DefaultSort(Theatre[] data)
	{
        Theatre[] resultData = data[..];

        Array.Sort(resultData);

        return resultData;
	}

	/// <summary>
	/// Метод, реализующий сортировку пузырьком.
	/// </summary>
	/// <param name="inputData"></param>
	/// <returns></returns>
	public static Theatre[] BubbleSort(Theatre[] inputData)
	{
		bool flag = false;
		Theatre[] data = inputData[..];

		while (!flag)
		{
			flag = true;

			for (int i = 0; i < data.Length - 1; ++i)
			{
				if (data[i].CompareTo(data[i + 1]) == 1)
				{
					flag = false;

					Theatre tmp = data[i];
					data[i] = data[i + 1];
					data[i + 1] = tmp;
				}
			}
		}

		return data;
	}
}