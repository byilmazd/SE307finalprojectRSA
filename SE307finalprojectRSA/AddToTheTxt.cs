using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SE307finalprojectRSA
{
    class AddToTheTxt : IDisplayItemsOnLoan
    {
        List<String> memberDatabase = new List<String>();
        List<String> database = new List<String>();
        List<String> history = new List<String>();
        List<Item> allItems = new List<Item>();
        ArrayList realbooks = new ArrayList();
        ArrayList realvideos = new ArrayList();
        List<Member> members = new List<Member>();
        public void addAVideoToTxt(string title, int copy)
        {
            using (TextWriter writer = new StreamWriter("C:/Users/barki/source/repos/SE307finalprojectRSA/SE307finalprojectRSA/Txt files/ItemsInfo.txt", true))
            {
                writer.Write("Video ");
                writer.Write(title + " ");
                writer.Write(copy + " ");
                writer.Close();
                writer.Dispose();
            }
            //string readText = File.ReadAllText("C:/Users/barki/source/repos/SE307finalprojectRSA/SE307finalprojectRSA/Txt files/ItemsInfo.txt");
            //Console.WriteLine(readText);
        }
        public void addABookToTxt(string title, string author, string isbn, int copy)
        {
            using (TextWriter writer = new StreamWriter("C:/Users/barki/source/repos/SE307finalprojectRSA/SE307finalprojectRSA/Txt files/ItemsInfo.txt", true))
            {
                writer.Write("Book ");
                writer.Write(title + " ");
                writer.Write(author + " ");
                writer.Write(isbn + " ");
                writer.Write(copy + " ");
                writer.Close();
                writer.Dispose();
            }
        }
        public void LoadArrayList()
        {
            TextReader tr;
            tr = File.OpenText("C:/Users/barki/source/repos/SE307finalprojectRSA/SE307finalprojectRSA/Txt files/ItemsInfo.txt");

            string allInfo;
            allInfo = tr.ReadLine();
            if (allInfo != null)
            {
                String[] words = allInfo.Split(" ");
                for (int q = 0; q <= words.Length; q++)
                {
                    try
                    {
                        database.Add(words[q]);
                    }
                    catch (IndexOutOfRangeException)
                    {
                    }
                }
            }
            tr.Close();
            tr.Dispose();
        }
        public void LoadRentalTxt()
        {
            TextReader tr;
            tr = File.OpenText("C:/Users/barki/source/repos/SE307finalprojectRSA/SE307finalprojectRSA/Txt files/rentalHistory.txt");

            string allInfo;
            allInfo = tr.ReadLine();
            if (allInfo != null)
            {
                String[] words = allInfo.Split(" ");
                for (int q = 0; q <= words.Length; q++)
                {
                    try
                    {
                        history.Add(words[q]);
                    }
                    catch (IndexOutOfRangeException)
                    {
                    }
                }
            }
            tr.Close();
            tr.Dispose();
        }
        public void searchBookOrVideo(String which)
        {
            if (database.Contains(which))
            {
                for (int i = 0; i <= database.Count; i++)
                {
                    try
                    {
                        if (database[i].Equals(which) && which == "Book")
                        {
                            Console.Write(database[i] + " ");
                            Console.Write("Title: " + database[i + 1] + " ");
                            Console.Write("Author: " + database[i + 2] + " ");
                            Console.Write("ISBN: " + database[i + 3] + " ");
                            Console.Write("Number of Copies: " + database[i + 4] + " \n");
                            try
                            {
                                Book bb = new Book(database[i+1], database[i + 2], database[i + 3], Int32.Parse(database[i + 4]));
                                allItems.Add(bb);
                            }
                            
                            catch (InvalidCastException) { }                           
                        }
                        if (database[i].Equals(which) && which == "Video")
                        {
                            Console.Write(database[i] + " ");
                            Console.Write("Title: " + database[i + 1] + " ");
                            Console.Write("Number of Copies: " + database[i + 2] + " \n");
                            try
                            {
                                Video vv = new Video(database[i + 1], Int32.Parse(database[i + 2]));
                                allItems.Add(vv);
                            }
                            catch (InvalidCastException) { }
                        }
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                    }
                }
            }
        }
        public void decreaseCopies(String bookOrVideoName, String bookOrVideo)
        {
            if (bookOrVideo == "Book")
            {
                try
                {
                    Item foundItem = findItem(bookOrVideoName, allItems);
                    if (foundItem == null)
                    {
                        Console.WriteLine("Invalid Name for the Item.");
                    }
                    else
                    {
                        foundItem.numberOfCopies = foundItem.numberOfCopies - 1;
                        TextWriter tw = new StreamWriter("C:/Users/barki/source/repos/SE307finalprojectRSA/SE307finalprojectRSA/Txt files/booksInfo.txt");
                        foreach (Book s in allItems)
                        {
                            tw.Write(" Book " + s.title + " " + s.authorName + " " + s.isbnn + " " + s.numberOfCopies + " ");
                        }
                        tw.Close();

                        TextReader tr;
                        tr = File.OpenText("C:/Users/barki/source/repos/SE307finalprojectRSA/SE307finalprojectRSA/Txt files/booksInfo.txt");

                        string allInfo;
                        allInfo = tr.ReadLine();
                        if (allInfo != null)
                        {
                            String[] words = allInfo.Split("\n");
                            for (int q = 0; q <= words.Length; q++)
                            {
                                try
                                {
                                    realbooks.Add(words[q]);
                                }
                                catch (IndexOutOfRangeException)
                                {
                                }
                            }
                        }
                    }
                }
                catch (ArgumentNullException) { }
            }
            else if (bookOrVideo == "Video")
            {
                try
                {
                    Item foundItem = findItem(bookOrVideoName, allItems);
                    if (foundItem == null)
                    {
                        Console.WriteLine("Invalid Name for the Item.");
                    }
                    else
                    {
                        foundItem.numberOfCopies = foundItem.numberOfCopies - 1;
                        TextWriter tw = new StreamWriter("C:/Users/barki/source/repos/SE307finalprojectRSA/SE307finalprojectRSA/Txt files/videoInfo.txt");
                        foreach (Video s in allItems)
                            tw.Write(" Video " + s.title + " " + s.numberOfCopies + " ");
                        tw.Close();

                        TextReader tr;
                        tr = File.OpenText("C:/Users/barki/source/repos/SE307finalprojectRSA/SE307finalprojectRSA/Txt files/videoInfo.txt");

                        string allInfo;
                        allInfo = tr.ReadLine();
                        if (allInfo != null)
                        {
                            String[] words = allInfo.Split("\n");
                            for (int q = 0; q <= words.Length; q++)
                            {
                                try
                                {
                                    realvideos.Add(words[q]);
                                }
                                catch (IndexOutOfRangeException)
                                {
                                }
                            }
                        }
                    }
                }
                catch (ArgumentNullException) { }
            }
        }
        public Item findItem(string name, List<Item> items)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].title.Equals(name)){
                    return items[i];
                }
            }
            return null;
        }
        public Member findMember(String name, String surname, List<Member> members)
        {
            for (int i = 0; i < members.Count; i++)
            {
                if (members[i].name.Equals(name) && members[i].surname.Equals(surname))
                {
                    return members[i];
                }
            }
            return null;
        }
        public void changeWithDataBase()
        {
            try
            {
                string[] book = File.ReadAllLines("C:/Users/barki/source/repos/SE307finalprojectRSA/SE307finalprojectRSA/Txt files/booksInfo.txt");
                string[] video = File.ReadAllLines("C:/Users/barki/source/repos/SE307finalprojectRSA/SE307finalprojectRSA/Txt files/videoInfo.txt");
                using (TextWriter textWriter = new StreamWriter("C:/Users/barki/source/repos/SE307finalprojectRSA/SE307finalprojectRSA/Txt files/ItemsInfo.txt"))
                for (int i = 0; i <= video.Length; i++) { textWriter.Write("{0}\t{1}", book[i], video[i]); }
            }
            catch (IndexOutOfRangeException) { }
        }
        public void returnVideoOrBook(String bookOrVideoName, String bookOrVideo)
        {
            if (bookOrVideo == "Book")
            {
                Item foundItem = findItem(bookOrVideoName, allItems);
                if (foundItem == null)
                {
                    Console.WriteLine("Couldn't find the item.");
                }
                else
                {
                    foundItem.numberOfCopies = foundItem.numberOfCopies + 1;
                    TextWriter tw = new StreamWriter("C:/Users/barki/source/repos/SE307finalprojectRSA/SE307finalprojectRSA/Txt files/booksInfo.txt");
                    foreach (Book s in allItems)
                    {
                        tw.Write(" Book " + s.title + " " + s.authorName + " " + s.isbnn + " " + s.numberOfCopies + " ");
                    }
                    tw.Close();
                }
            }
            if (bookOrVideo == "Video")
            {
                Item foundItem = findItem(bookOrVideoName, allItems);
                if (foundItem == null)
                {
                    Console.WriteLine("Couldn't find the item.");
                }
                else
                {
                    foundItem.numberOfCopies = foundItem.numberOfCopies + 1;
                    TextWriter tw = new StreamWriter("C:/Users/barki/source/repos/SE307finalprojectRSA/SE307finalprojectRSA/Txt files/videoInfo.txt");
                    foreach (Video s in allItems)
                    {
                        tw.Write(" Video " + s.title + " " + s.numberOfCopies + " ");
                    }
                    tw.Close();
                }
            }
        }
        public void addMemberToTheTxt(String n, String s, String a, String p, String productName)
        {
            Item foundItem = findItem(productName, allItems);
            Member foundMember = findMember(n, s, members);
            using (TextWriter writer = new StreamWriter("C:/Users/barki/source/repos/SE307finalprojectRSA/SE307finalprojectRSA/Txt files/MembersInfo.txt", true))
            {

                    writer.Write(" Member ");
                    writer.Write(n + " ");
                    writer.Write(s + " ");
                    writer.Write(a + " ");
                    writer.Write(p + " ");            
                writer.Close();
                writer.Dispose();
            }
        }
        public void addToTheRentalHistoryTxt(String n, String s, String a, String p, String productName)
        {
            Item foundItem = findItem(productName, allItems);
            using (TextWriter writer = new StreamWriter("C:/Users/barki/source/repos/SE307finalprojectRSA/SE307finalprojectRSA/Txt files/rentalHistory.txt", true))
            {
                writer.WriteLine(DateTime.Now.ToString());
                writer.Write("Member(Rented) ");
                writer.Write(n + " ");
                writer.Write(s + " ");
                writer.Write(a + " ");
                writer.Write(p + " ");
                writer.WriteLine("Rented Items: " + foundItem.title);
                writer.Close();
                writer.Dispose();
            }
        }
        public void addToTheRentalHistoryReturnedTxt(String n, String s, String productName)
        {
            Item foundItem = findItem(productName, allItems);
            Member foundMember = findMember(n, s, members);

            if (foundMember == null)
            {
                Console.WriteLine("Member not found or the person you have entered didn't rent the certain book, please enter a valid member..");
                
                if (foundItem is Video)
                {
                    foundItem.numberOfCopies = foundItem.numberOfCopies - 1;
                    TextWriter tw = new StreamWriter("C:/Users/barki/source/repos/SE307finalprojectRSA/SE307finalprojectRSA/Txt files/videoInfo.txt");
                    foreach (Video a in allItems)
                    {
                        tw.Write(" Video " + a.title + " " + a.numberOfCopies + " ");
                    }
                    tw.Close();
                }
                if (foundItem is Book)
                {
                    foundItem.numberOfCopies = foundItem.numberOfCopies - 1;
                    TextWriter tw = new StreamWriter("C:/Users/barki/source/repos/SE307finalprojectRSA/SE307finalprojectRSA/Txt files/booksInfo.txt");
                    foreach (Book a in allItems)
                    {
                        tw.Write(" Video " + a.title + " " + a.numberOfCopies + " ");
                    }
                    tw.Close();
                }
            }
            else
            {
                using (TextWriter writer = new StreamWriter("C:/Users/barki/source/repos/SE307finalprojectRSA/SE307finalprojectRSA/Txt files/rentalHistory.txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToString());
                    writer.Write("Member(Returned) ");
                    writer.Write(foundMember.name + " ");
                    writer.Write(foundMember.surname + " ");
                    writer.Write(foundMember.address + " ");
                    writer.Write(foundMember.phoneNumber + " ");
                    writer.WriteLine("Rented Items: " + foundItem.title);
                    writer.Close();
                    writer.Dispose();
                }
                displayAllItemsOnLoan();
            }
        }
        public void displayMembers(String name, String surname)
        {
            try
            {   
                Member foundMember = findMember(name, surname, members);
                if (foundMember != null) { 
                    Console.WriteLine(foundMember.name + " " + foundMember.surname + " " + foundMember.address + " " + foundMember.phoneNumber);
                }else { Console.WriteLine("There are no members associated with that name and surname."); }                    
            }
            catch (Exception)
            {
                Console.WriteLine("There are no members associated with that name and surname.");
            }
        }
        public void loadArrayMember()
        {
            TextReader tr;
            tr = File.OpenText("C:/Users/barki/source/repos/SE307finalprojectRSA/SE307finalprojectRSA/Txt files/MembersInfo.txt");

            string allInfo;
            allInfo = tr.ReadLine();
            if (allInfo != null)
            {
                String[] words = allInfo.Split(" ");
                for (int q = 0; q <= words.Length; q++)
                {
                    try
                    {
                        memberDatabase.Add(words[q]);
                    }
                    catch (IndexOutOfRangeException)
                    {
                    }
                }
            }
            tr.Close();
            tr.Dispose();
        }
        public void displayMembersAndArrange()
        {
                for (int i = 0; i <= memberDatabase.Count; i++)
                {
                    try
                    {
                        if (memberDatabase[i].Equals("Member"))
                        {
                            Console.Write(" " + memberDatabase[i] + " ");
                            Console.Write("Name: " + memberDatabase[i + 1] + " ");
                            Console.Write("Surname: " + memberDatabase[i + 2] + " ");
                            Console.Write("Address: " + memberDatabase[i + 3] + " ");
                            Console.Write("PhoneNumber: " + memberDatabase[i + 4] + " \n");
                            try
                            {
                            Member mm = new Member(memberDatabase[i + 1], memberDatabase[i + 2], memberDatabase[i + 3], memberDatabase[i + 4]);
                            members.Add(mm);
                        }
                            catch (InvalidCastException) { }
                        }                      
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                    }
                }         
        }
        public void displayAllItemsToBeRent(List<Item> items)
        {
            for(int i = 0; i <= items.Count; i++)
            {
                Console.WriteLine("Title: " + items[i].title + "Number of Copies: " + items[i].numberOfCopies);
            }
        }
        public void displayAllItemsOnLoan()
        {
            TextReader tr;
            tr = File.OpenText("C:/Users/barki/source/repos/SE307finalprojectRSA/SE307finalprojectRSA/Txt files/rentalHistory.txt");

            string allInfo;
            allInfo = tr.ReadToEnd();
            if (allInfo != null)
            {
                String[] words = allInfo.Split(" ");
                for (int q = 0; q <= words.Length; q++)
                {
                    try
                    {
                        Console.Write(words[q]);
                    }
                    catch (IndexOutOfRangeException)
                    {
                    }
                }
            }
            tr.Close();
            tr.Dispose();
        }
    }
}
