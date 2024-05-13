using PhoneBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneBook.Controllers;

namespace PhoneBook
{
    internal class MyPhoneBooks
    {
        List<Contact> phoneBook = new List<Contact>();
        KeyboardController keyboard;
        public MyPhoneBooks()
        {

            // добавляем контакты
            phoneBook.Add(new Contact("Игорь", "Николаев", 79990000001, "igor@example.com"));
            phoneBook.Add(new Contact("Сергей", "Довлатов", 79990000010, "serge@example.com"));
            phoneBook.Add(new Contact("Анатолий", "Карпов", 79990000011, "anatoly@example.com"));
            phoneBook.Add(new Contact("Валерий", "Леонтьев", 79990000012, "valera@example.com"));
            phoneBook.Add(new Contact("Сергей", "Брин", 799900000013, "serg@example.com"));
            phoneBook.Add(new Contact("Иннокентий", "Смоктуновский", 799900000013, "innokentii@example.com"));
            keyboard = new KeyboardController(phoneBook);
        }
        public void ClickedPhoneBooks()
        {
            keyboard.ButtonPhoneBook();

        }
    }
}
