using System;
using System.Collections.Generic;
using System.Text;

namespace SE307finalprojectRSA
{
    class Video : Item
    {
        AddToTheTxt addTo = new AddToTheTxt();
        public Video(String title, int numberOfCopies) : base(title, numberOfCopies)
        {

        }
        public void callAdd(string title, int copy)
        {
            addTo.addAVideoToTxt(title, copy);
        }
    }
}
