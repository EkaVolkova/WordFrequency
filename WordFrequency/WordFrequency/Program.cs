using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

/// <summary>
/// Программа позволяет понять, какие 10 слов чаще всего встречаются в тексте.
/// </summary>
namespace WordFrequency
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = GetMostFreaqWords("Text.txt");
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
        static List<string> GetMostFreaqWords(string path)
        {
            //создаем словарь
            var dictionary = new Dictionary<string, int>();

            //считываем текст
            var text = File.ReadAllText(path);

            //Определим вспомогательные символы
            char[] splitter = { ',', '.', '-', '\'', ':', '\n', '\r', ' ', 
                '\"', '«', '»', '–', '*', '—',  ';', '!', '?', '…', '“', '„', '(', ')', '[', ']'};
            
            //разделим текст на слова при помощи вспомогательных символов
            var newText = text.ToLower().Split(splitter);

            //Добавим в словарь
            foreach (var item in newText)
            {
                //Если элемент - пустая строка, идем к следующему элементу
                if (item.Equals(string.Empty))
                    continue;

                //Если в словаре уже есть слово, то увеличим значение, если нет - запишем 1 (слово встретилось 1 раз)
                if (dictionary.ContainsKey(item))
                    dictionary[item]++;
                else
                    dictionary.Add(item, 1);
            }

            //Отсортируем словаь по значению в порядке убывания и запишем ключи (слова) в список
            var sortedList = dictionary.OrderByDescending(x => x.Value).Select(x => x.Key).ToList();

            //Оставим в списке только первые 10 элементов 
            sortedList.RemoveRange(10, sortedList.Count - 10);

            return sortedList;
        }
    }
}
