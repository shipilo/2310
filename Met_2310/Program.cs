using System;
using System.Collections.Generic;
using System.IO;

namespace Met_2310
{	
	class Account
	{
		public enum Type
		{
			Current,
			Saving
		}
		private int index;
		private Type accountType;
		private int balance;
		public Account(int Index, Type AccountType, int Balance)
		{
			index = Index;
			accountType = AccountType;
			balance = Balance;
		}
		public int Index
		{
			get => index;
		}
		public Type AccountType
		{
			get => accountType;
			set => accountType = value;
		}
		public int Balance
		{
			get => balance;
			set => balance = value;
		}

		public string OutPut()
		{
			return ($"Номер: {Index}\nТип: {AccountType}\nБаланс: {Balance}\n");
		}
		public bool Withdraw(int sum)
		{
			if (sum <= balance)
			{
				balance -= sum;
				return true;
			}
			else
            {
				return false;
            }
		}
		public bool PutInBalance(int sum)
		{
			if (sum > 0)
			{
				balance += sum;
				return true;
			}
            else
            {
				return false;
            }
		}
		public bool MakeTransfer(Account accPaymentReceiver, int sum)
        {
			if (Withdraw(sum))
            {				
				accPaymentReceiver.PutInBalance(sum);
				return true;
            }
			else
            {
				return false;
            }
        }
	}
	class Song
	{
		string name;
		string author; 
		Song previous;
		public Song()
        {

        }
		public Song(string Name, string Author)
		{
			name = Name;
			author = Author;
		}
		public Song(string Name, string Author, Song Previous)
		{
			name = Name;
			author = Author;
			previous = Previous;
		}
		public void SetName(string Name)
        {
			name = Name;
        }
		public void SetAuthor(string Author)
        {
			author = Author;
        }
		public void SetPrevious(Song Previous)
        {
			previous = Previous;
        }
		public string Title()
        {
			return String.Concat(name, " ", author);
        }
		public override bool Equals(object d)
        {
			if(d is Song)
            {
				return (d as Song).Title().Equals(Title());
            }
			else
            {
				return false;
            }
        }
	}
	class Program
    {
        static void Main(string[] args)
        {
			string path = "", str;
			string[] rows;

			Console.WriteLine("Упражнение 8.1");
			Account acc1 = new Account(0, Account.Type.Current, 100);
			Account acc2 = new Account(1, Account.Type.Current, 1000);
			Console.WriteLine(acc2.MakeTransfer(acc1, 500));

			Console.WriteLine("\nУпражнение 8.2");
			Console.WriteLine(ReverseString(Console.ReadLine()));

			Console.WriteLine("\nУпражнение 8.3");
			Console.WriteLine("Путь к файлу:");
			path = Console.ReadLine();
            if (File.Exists(path))
            {
				StreamReader sr1 = new StreamReader(path);				
				str = sr1.ReadToEnd();
				sr1.Close();
				StreamWriter sw1 = new StreamWriter(path);
				sw1.Write(str.ToUpper());
				sw1.Close();
            }
			else
            {
				Console.WriteLine("Файла по уазанному пути не существует.");
            }

			Console.WriteLine("\nУпражнение 8.4");
			Console.WriteLine(CheckInterface("")); // false для типа string
			Console.WriteLine(CheckInterface(1)); // true для типа int

			Console.WriteLine("\nДомашнее задание 8.1");
			StreamReader sr2 = new StreamReader("in.txt");
			rows = sr2.ReadToEnd().Trim().Split('\n');
			sr2.Close();
			StreamWriter sw2 = new StreamWriter("out.txt");
			string mails = "";
			foreach (string row in rows)
            {
				str = row.Trim();
				SearchMail(ref str);
				mails += !Equals(str, row) ? str : "not_found";
				mails += "\n";
			}
            try
            {
				sw2.Write(mails);
            }
            catch
            {
				Console.WriteLine("Запись не удалась.");
			}
            finally
            {
				sw2.Close();
            }
			Console.WriteLine("Успешно записано.");

			Console.WriteLine("\nДомашнее задание 8.2");
			List<Song> songs = new List<Song>();
			songs.Add(new Song("Ecstasy", "ATB"));
			songs.Add(new Song("Pieces of You", "nothing,nowhere.", songs[0]));
			songs.Add(new Song("Pieces of You", "nothing,nowhere.", songs[1]));
			songs.Add(new Song("Never Going Home", "Kungs", songs[2]));
			Console.WriteLine(songs[1].Equals(songs[2])); // true
			Console.WriteLine(songs[1].Equals(songs[3])); // true
			Console.WriteLine(songs[1].Equals(acc1)); // false

			Console.ReadLine();
		}
		static string ReverseString(string strInput)
        {
			char[] strOutput = new char[strInput.Length];

			for (int i = 0; i < strInput.Length; i++)
            {
				strOutput[i] = strInput[strInput.Length - i - 1];
            }

			return String.Join("", strOutput);
        }
		static bool CheckInterface(Object obj)
        {
			return obj is IFormattable;
        }
		static void SearchMail(ref string s)
        {
			s = s.Substring(s.IndexOf('#') + 1).Trim();
        }
	}
}
