using PhoneBook.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Controllers
{

    public class KeyboardController
    {
        List<Contact> _phoneBook;
        public KeyboardController(List<Contact> phoneBook)
        {
            _phoneBook = phoneBook;
        }

        public void ButtonPhoneBook()
        {
            Console.Write("Введите номер страницы:");
            while (true)
            {

                try
                {// Читаем введенный с консоли символ

                    var input = Console.ReadKey().KeyChar;
                    Console.Clear();
                    // проверяем, число ли это
                    var parsed = Int32.TryParse(input.ToString(), out int pageNumber);

                    // если не соответствует критериям - показываем ошибку
                    if (!parsed || pageNumber < 1 || pageNumber > 3)
                    {
                        throw new MyException("Упс! Вы ввели не корректно номер страницы! \nПожалуйста, повторите ввод!" +
                            "\nДля продолжения введите номер страницы(не более 3х):");
                    }
                    // если соответствует - запускаем вывод
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine($"Номер страницы: {pageNumber} из  3");
                        // пропускаем нужное количество элементов и берем 2 для показа на странице
                        var pageContent = _phoneBook.Skip((pageNumber - 1) * 2).Take(2);
                        Console.WriteLine();

                        // выводим результат
                        // сортировка Имя , Фамилия
                        var sortContact = from contact in pageContent
                                                             .OrderBy(s => s.Name)
                                                             .ThenBy(s => s.LastName)
                                          select contact;

                        foreach (var entry in sortContact)
                            Console.WriteLine(entry.Name + "  " + entry.LastName + ": " + entry.PhoneNumber + " - " + entry.Email);

                        Console.WriteLine();
                        Console.Write("Для продолжения введите номер страницы:");
                    }
                }
                catch (Exception ex) when (ex is MyException)
                {
                    Console.WriteLine();
                    Console.WriteLine(ex.Message);
                }
            }
        }


    }
}
