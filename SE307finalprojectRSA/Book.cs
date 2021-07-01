using System;
using System.Collections.Generic;
using System.Text;

namespace SE307finalprojectRSA
{
    class Book : Item
    {
        public String authorName;
        public String isbnn;
        AddToTheTxt addTo = new AddToTheTxt();
        public Book(String title, String author, String isbn, int numberOfCopies) : base(title, numberOfCopies)
        {
            authorName = author;
            isbnn = isbn;
        }
        public void callAdd(string title, string author, string isbn, int copy)
        {
            addTo.addABookToTxt(title, author, isbn, copy);
        }
    }
}
