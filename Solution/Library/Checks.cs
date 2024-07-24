using System;
namespace Library
{
	/// <summary>
	/// Класс предназначен для различных проверок ввода пользователя.
	/// </summary>
	public static class Checks
	{
		/// <summary>
		/// Данный enum нужен для того, чтобы определять какую из проверок нужно осуществлять: на то, что существует ли файл, или на то, что он не существует.
		/// </summary>
		public enum TypeOfSaving
		{
			Exist,
			NotExist,
		}

		/// <summary>
		/// Данный метод проверяет, что введённый пользователем файл существует.
		/// </summary>
		/// <returns></returns>
		public static string CheckInputFile()
		{
			bool flagCheckFile = false;
			string path = "";

			while (!flagCheckFile)
			{
				Console.Write("Введите путь к файлу: ");
				path = Console.ReadLine();

				if (File.Exists(path))
				{
					if (path[^4..] == ".csv")
					{
						flagCheckFile = true;
					}
					else
					{
						Console.Write("Данный файл не csv-формата. Попробуйте ещё раз. ");
					}
				}
				else
				{
					Console.Write("Нет такого файла. Попробуйте ещё раз. ");
				}
			}

			return path;
		}

		/// <summary>
		/// Данный метод проверяет, что введённый пользователем файл корректного формата.
		/// </summary>
		/// <returns></returns>
		public static string[][] CheckFormat()
		{
			bool flagCheckFormat = false;
			string path = "";
			string[][] data = new string[0][];

			while (!flagCheckFormat)
			{
				flagCheckFormat = true;
				path = CheckInputFile();

				try
				{
					data = CsvProcessing.GetCsv(path);

					string[] nameOfColumns = { "ROWNUM", "CommonName", "FullName",
											   "ShortName", "AdmArea", "District",
											   "Address", "ChiefName", "ChiefPosition",
											   "PublicPhone", "Fax", "Email",
											   "WorkingHours", "ClarificationOfWorkingHours", "WebSite",
											   "OKPO", "INN", "MainHallCapacity",
											   "AdditionalHallCapacity", "X_WGS", "Y_WGS",
											   "GLOBALID" };

					for (int i = 0; i < data[0].Length; ++i)
					{
						if (data[0][i] != nameOfColumns[i])
						{
							flagCheckFormat = false;
						}
					}

					for (int j = 0; j < data.GetLength(0); ++j)
					{
						if (data[j].Length != nameOfColumns.Length)
						{
							flagCheckFormat = false;
						}
					}
				}
				catch
				{
                    flagCheckFormat = false;
                }

				if (!flagCheckFormat)
				{
                    Console.WriteLine("Неверный формат файла. Введите другой путь.");
                }
			}

			return data;
		}

		/// <summary>
		/// Данный метод проверяет, что пользователь ввёл корректную команду для показа данных в начале итерации программы.
		/// </summary>
		/// <returns></returns>
		public static int CheckTypeOfShowingData()
		{
			bool flagCheckTypeOfShowing = false;
			string commandWithType = "";

            Console.WriteLine("Вы хотите увидеть верхние или нижние строки?");

            while (!flagCheckTypeOfShowing)
			{
				Console.Write("Введите команду (0 - верхние; 1 - нижние): ");
				commandWithType = Console.ReadLine();

				if (commandWithType != "0" && commandWithType != "1")
				{
					Console.Write("Введена неверная команда. Попробуйте ещё раз. ");
				}
				else
				{
					flagCheckTypeOfShowing = true;
				}
			}

			return int.Parse(commandWithType);
		}

		/// <summary>
		/// Метод проверяет, что пользователь ввёл корректное количество строк, которое он хочет увидеть.
		/// </summary>
		/// <param name="theatres"></param>
		/// <returns></returns>
		public static int CheckNumberOfRows(Theatre[] theatres)
		{
			bool flagCheckNumberOfRows = false;
			int n = 0;

			while (!flagCheckNumberOfRows)
			{
				Console.Write($"Введите количество строк N (1 < N <= {theatres.Length}): ");

				if (int.TryParse(Console.ReadLine(), out n))
				{
					if (n > 1 && n <= theatres.Length)
					{
						flagCheckNumberOfRows = true;
					}
				}

				if (!flagCheckNumberOfRows)
				{
					Console.Write("Введено неверное количество строк. Попробуйте ещё раз. ");
				}
			}

			return n;
		}

		/// <summary>
		/// Метод проверяет, что пользователем корректно введена команда из меню.
		/// </summary>
		/// <returns></returns>
		public static int CheckMenuCommand()
		{
			bool flagCheckCommand = false;
			int cmd = 0;

			while (!flagCheckCommand)
			{
				flagCheckCommand = true;
				Console.Write("Введите команду: ");

				if (!int.TryParse(Console.ReadLine(), out cmd) || cmd < 1 || cmd > 4)
				{
					flagCheckCommand = false;
					Console.Write("Неверная команда. Попробуйте ещё раз. ");
				}
			}

			return cmd;
		}

		/// <summary>
		/// Метод проверяет, что пользователем корректно введена команда типа сортировки.
		/// </summary>
		/// <returns></returns>
		public static int CheckTypeOfSorting()
		{
			bool flagCheckType = false;
            int commandOfType = 0;
			Console.WriteLine("Упорядочить по возрастанию или убыванию?");

            while (!flagCheckType)
			{
				flagCheckType = true;
				Console.Write("Введите команду (0 - по возрастанию, 1 - по убыванию): ");

				if (!int.TryParse(Console.ReadLine(), out commandOfType) || commandOfType < 0 || commandOfType > 1)
				{
					flagCheckType = false;
                    Console.Write("Неверная команда. Попробуйте ещё раз. ");
                }
			}

			return commandOfType;
		}

		/// <summary>
		/// Метод проверяет, что пользователь корректно ввёл команду типа сохранения.
		/// </summary>
		/// <returns></returns>
		public static int CheckTypeOfSaving()
		{
            bool flagCheckTypeOfSaving = false;
            int typeOfSaving = 0;

            Console.WriteLine("Как сохранить результат?");
			Console.WriteLine("	1. В новом файле.");
            Console.WriteLine("	2. Перезаписать существующий файл.");
			Console.WriteLine("	3. Дописать в файл.");

            while (!flagCheckTypeOfSaving)
            {
                flagCheckTypeOfSaving = true;
                Console.Write("Введите команду: ");

                if (!int.TryParse(Console.ReadLine(), out typeOfSaving) || typeOfSaving < 1 || typeOfSaving > 3)
                {
                    flagCheckTypeOfSaving = false;
                    Console.Write("Неверная команда. Попробуйте ещё раз. ");
                }
            }

            return typeOfSaving;
        }

		/// <summary>
		/// Метод проверяет, существует ли файл, путь к которому указал пользователь, и что он csv-формата.
		/// </summary>
		/// <param name="type"></param>
		/// <returns></returns>
		public static string CheckExistenceOfFile(int type)
		{
			TypeOfSaving typeOfSaving = (TypeOfSaving)type;
			string path = "";
			// Заметим, что если файл уже есть, а пользователь хочет создать по этому пути новый, то мы должны вывести соотвествующее сообщение.
			// Также, если файла нет, а пользователь хочет перезаписать или дописать в существующий, то мы так же выводим сообщение.
			if (typeOfSaving == TypeOfSaving.Exist)
			{
				bool flagExist = false;

				while (!flagExist)
				{
					flagExist = true;

					Console.Write("Введите путь файла, который вы хотите создать (.csv в названии файла нужно указывать): ");
					path = Console.ReadLine();

					if (File.Exists(path))
					{
						Console.Write("Такой файл уже существует. Попробуйте ещё раз. ");
						flagExist = false;
					}
					else
					{
						if (path[^4..] != ".csv")
						{
							Console.Write("Вы хотите создать файл не csv-формата. Попробуйте ещё раз. ");
							flagExist = false;
						}
					}
				}
			}
			else
			{
                bool flagNotExist = false;

                while (!flagNotExist)
                {
                    flagNotExist = true;

                    Console.Write("Введите путь к файлу: ");
                    path = Console.ReadLine();

                    if (!File.Exists(path))
                    {
                        Console.Write("Такого файла не существует. Попробуйте ещё раз. ");
                        flagNotExist = false;
                    }
					else
					{
						if (path[^4..] != ".csv")
						{
							Console.Write("Данный файл не csv-формата. Попробуйте ещё раз. ");
							flagNotExist = false;
						}
					}
                }
            }

			return path;
		}
	}
}