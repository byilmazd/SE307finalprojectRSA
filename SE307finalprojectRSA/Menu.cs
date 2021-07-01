using System;
using System.Collections.Generic;
using System.Text;

namespace SE307finalprojectRSA
{
    class Menu
    {
        public void displayMenu() {
            Console.WriteLine(
                "1-Add a new book/video\n" +
                "2-Rent a book/video\n" +
                "3-Return a book/video\n" +
                "4-Additional Menu\n" +
                "5-Exit from the application");
        }
    }
}
