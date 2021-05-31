using System;
using System.IO;
using System.Text;
namespace SomeFiles
{
	class Program
	{
		static void Main(string[] args)
		{
			const string fileName = @"c:\test.txt";
			const string testMessage = @"Hello world1";

			/*
			 * для записи в файл необходимо перевсти текст в массив байтов
			 */
			byte[] messageBytes = Encoding.UTF8.GetBytes(testMessage);
			/*
			 * далее необходимо открыть файловый поток на запись
			 */
			FileStream testFileStream = File.Open(
				fileName,
				FileMode.Create,
				FileAccess.Write,
				FileShare.Read);
			/*этот метод создает файловый поток -- переменная, которая связана с определенным файлом
			 */
			testFileStream.Write(messageBytes);	//добавить в буфер на запись
			testFileStream.Flush();		//записать то, что находится в буфере
			testFileStream.Write(messageBytes);
			testFileStream.Write(messageBytes);
			testFileStream.Write(messageBytes);
			testFileStream.Write(messageBytes);
			/*
			 * обязательно необходимо закрыть файловый поток
			 * Все, что находится в буфере на запись будет записано непосредственно перед закрытием
			 */
			testFileStream.Close();	
		}
	}
}
