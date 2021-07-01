using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SE307finalprojectRSA
{
    class MoneyEarned : IDisplayItemsOnLoan
    {
        float moneyBook = 0.0f;
        float moneyVideo = 0.0f;
        public void moneyFromBooks()
        {
            TextReader tr;
            tr = File.OpenText("C:/Users/barki/source/repos/SE307finalprojectRSA/SE307finalprojectRSA/Txt files/moneyEarnedFromBooks.txt");
            String mm = tr.ReadLine();
            float mmChanged = float.Parse(mm);
            mmChanged = mmChanged + 1.0f;
            tr.Close();
            tr.Dispose();

            using (TextWriter writer = new StreamWriter("C:/Users/barki/source/repos/SE307finalprojectRSA/SE307finalprojectRSA/Txt files/moneyEarnedFromBooks.txt"))
            {
                writer.Write(mmChanged);
                writer.Close();
                writer.Dispose();
            }
        }
        public void moneyFromVideos()
        {
            TextReader tr;
            tr = File.OpenText("C:/Users/barki/source/repos/SE307finalprojectRSA/SE307finalprojectRSA/Txt files/moneyEarnedFromVideos.txt");
            String mm = tr.ReadLine();
            float mmChanged = float.Parse(mm);
            mmChanged = mmChanged + 2.0f;
            tr.Close();
            tr.Dispose();

            using (TextWriter writer = new StreamWriter("C:/Users/barki/source/repos/SE307finalprojectRSA/SE307finalprojectRSA/Txt files/moneyEarnedFromVideos.txt"))
            {
                writer.Write(mmChanged);
                writer.Close();
                writer.Dispose();
            }
        }
        public String displayMoneyEarnedFromBooks()
        {
            TextReader tr;
            tr = File.OpenText("C:/Users/barki/source/repos/SE307finalprojectRSA/SE307finalprojectRSA/Txt files/moneyEarnedFromBooks.txt");
            String mm = tr.ReadLine();
            tr.Close();
            tr.Dispose();
            return mm;
        }
        public String displayMoneyEarnedFromVideos()
        {
            TextReader tr;
            tr = File.OpenText("C:/Users/barki/source/repos/SE307finalprojectRSA/SE307finalprojectRSA/Txt files/moneyEarnedFromVideos.txt");
            String mm = tr.ReadLine();
            tr.Close();
            tr.Dispose();
            return mm;
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
