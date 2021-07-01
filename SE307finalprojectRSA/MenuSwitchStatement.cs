using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace SE307finalprojectRSA
{
    class MenuSwitchStatement
    {
        AddToTheTxt txt = new AddToTheTxt();
        Menu m = new Menu();
        Exit ex = new Exit();
        MoneyEarned money = new MoneyEarned();
        public void switchS()
        {
                try
                {
                    m.displayMenu();
                    int userInput = Convert.ToInt32(Console.ReadLine());
                    switch (userInput)
                    {
                        case 1:
                            Console.WriteLine("" +
                                "Press 1 to add a Book\n" +
                                "Press 2 to add a Video");
                            int userI = Convert.ToInt32(Console.ReadLine());
                            if (userI == 1)
                            {
                                Console.WriteLine("Enter the Title, Author, ISBN number and Number of Copies");
                                String title = Console.ReadLine();
                                String author = Console.ReadLine();
                                String isbn = Console.ReadLine();
                                int copies = Convert.ToInt32(Console.ReadLine());
                                Book b = new Book(title, author, isbn, copies);
                                b.callAdd(title, author, isbn, copies);
                            System.Diagnostics.Process.Start(System.AppDomain.CurrentDomain.FriendlyName);
                            }
                            else if (userI == 2)
                            {
                                Console.WriteLine("Enter the Title and Number of Copies");
                                String a = Console.ReadLine();
                                int b = Convert.ToInt32(Console.ReadLine());
                                Video v = new Video(a, b);
                                v.callAdd(a, b);
                            System.Diagnostics.Process.Start(System.AppDomain.CurrentDomain.FriendlyName);
                            }
                            else
                            {
                                Console.WriteLine("Wrong Input");
                            System.Diagnostics.Process.Start(System.AppDomain.CurrentDomain.FriendlyName);
                            }
                            break;
                        case 2:
                            txt.LoadArrayList();
                            Console.WriteLine("To Rent a Book Press 1\n" +
                                "To Rent a Video Press 2");
                            int userI2 = Convert.ToInt32(Console.ReadLine());
                            if (userI2 == 1)
                            {
                                String b = "Book";
                                txt.searchBookOrVideo(b);
                                Console.WriteLine("Which book do you want to rent?(name of the book)");
                                String bookName = Console.ReadLine();
                                txt.decreaseCopies(bookName, b);
                                txt.changeWithDataBase();
                                Console.WriteLine("Enter the name: ");
                                String name = Console.ReadLine();
                                Console.WriteLine("Enter the surname: ");
                                String surname = Console.ReadLine();
                                Console.WriteLine("Enter the address: ");
                                String address = Console.ReadLine();
                                Console.WriteLine("Enter the phonenumber: ");
                                String phonenumber = Console.ReadLine();
                                txt.addMemberToTheTxt(name, surname, address, phonenumber, bookName);
                            txt.addToTheRentalHistoryTxt(name, surname, address, phonenumber, bookName);
                            money.moneyFromBooks();
                            System.Diagnostics.Process.Start(System.AppDomain.CurrentDomain.FriendlyName);
                            }
                            else if (userI2 == 2)
                            {
                                String v = "Video";
                                txt.searchBookOrVideo(v);
                                Console.WriteLine("Which video do you want to rent?(name of the video)");
                                String videoName = Console.ReadLine();
                                txt.decreaseCopies(videoName, v);
                                txt.changeWithDataBase();
                            Console.WriteLine("Enter the name: ");
                            String name = Console.ReadLine();
                            Console.WriteLine("Enter the surname: ");
                            String surname = Console.ReadLine();
                            Console.WriteLine("Enter the address: ");
                            String address = Console.ReadLine();
                            Console.WriteLine("Enter the phonenumber: ");
                            String phonenumber = Console.ReadLine();
                            txt.addMemberToTheTxt(name, surname, address, phonenumber, videoName);
                            txt.addToTheRentalHistoryTxt(name, surname, address, phonenumber, videoName);
                            money.moneyFromVideos();
                            System.Diagnostics.Process.Start(System.AppDomain.CurrentDomain.FriendlyName);
                            }
                            else
                            {
                                Console.WriteLine("Wrong Input");
                            System.Diagnostics.Process.Start(System.AppDomain.CurrentDomain.FriendlyName);
                            }
                            break;
                        case 3:
                            txt.LoadArrayList();
                            txt.LoadRentalTxt();
                            Console.WriteLine("To Return a Book Press 1\n" +
                                              "To Return a Video Press 2");
                            int userI3 = Convert.ToInt32(Console.ReadLine());
                            if (userI3 == 1)
                            {
                                String b = "Book";
                                txt.searchBookOrVideo(b);
                                Console.WriteLine("Which book you want to return?");
                                String bookName = Console.ReadLine();
                                txt.returnVideoOrBook(bookName, b);
                                
                            Console.WriteLine("Which member returning the book?");
                            txt.loadArrayMember();
                            txt.displayMembersAndArrange();
                            Console.WriteLine("Enter a name: ");
                            String name = Console.ReadLine();
                            Console.WriteLine("Enter a surname: ");
                            String surname = Console.ReadLine();
                            txt.addToTheRentalHistoryReturnedTxt(name, surname, bookName);
                            txt.changeWithDataBase();
                            System.Diagnostics.Process.Start(System.AppDomain.CurrentDomain.FriendlyName);
                            }
                            if (userI3 == 2)
                            {
                                String b = "Video";
                                txt.searchBookOrVideo(b);
                                Console.WriteLine("Which video you want to return?");
                                String videoName = Console.ReadLine();
                                txt.returnVideoOrBook(videoName, b);
                                
                            Console.WriteLine("Which member returning the book?");
                            txt.loadArrayMember();
                            txt.displayMembersAndArrange();
                            Console.WriteLine("Enter a name: ");
                            String name = Console.ReadLine();
                            Console.WriteLine("Enter a surname: ");
                            String surname = Console.ReadLine();
                            txt.addToTheRentalHistoryReturnedTxt(name, surname, videoName);
                            txt.changeWithDataBase();
                            System.Diagnostics.Process.Start(System.AppDomain.CurrentDomain.FriendlyName);
                            }
                            break;
                        case 4:
                            Console.WriteLine("Press 1 to search for a specific member.");
                            Console.WriteLine("Press 2 to display how much money earned from books and videos.");
                            Console.WriteLine("Press 3 to display all members.");
                            int userInp = Convert.ToInt32(Console.ReadLine());
                            if (userInp == 1)
                            {
                                txt.loadArrayMember();
                                txt.displayMembersAndArrange();
                                Console.WriteLine("Enter a name: ");
                                String name = Console.ReadLine();
                                Console.WriteLine("Enter a surname: ");
                                String surname = Console.ReadLine();
                                txt.displayMembers(name, surname);
                            System.Diagnostics.Process.Start(System.AppDomain.CurrentDomain.FriendlyName);
                            }
                            if (userInp == 2)
                            {
                            Console.WriteLine("Money earned from books: " + money.displayMoneyEarnedFromBooks() + "TL");
                            Console.WriteLine("Money earned from videos: " + money.displayMoneyEarnedFromVideos() + "TL");
                            System.Diagnostics.Process.Start(System.AppDomain.CurrentDomain.FriendlyName);
                            }
                            if (userInp == 3)
                            {
                                txt.loadArrayMember();
                                txt.displayMembersAndArrange();
                            System.Diagnostics.Process.Start(System.AppDomain.CurrentDomain.FriendlyName);
                            }
                            break;
                        case 5:
                            ex.exitFunc();
                            break;
                    }
                }
                catch (Exception) {
                Console.WriteLine("Invalid value, please try again..");
                System.Diagnostics.Process.Start(System.AppDomain.CurrentDomain.FriendlyName); }            
        }
    }
}

