using HairShop.Services;
using HairShop.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HairShop.ViewModels
{
    class MessageShowViewModel : INotifyPropertyChanged
    {
        private MessageShow messageshow;
        public MessageShowViewModel(MessageShow messageshow)
        {
            this.messageshow = messageshow;

            Message = Swapper.MessageShowText;
        }


        private string message;
        public string Message
        {
            get { return message; }
            set { message = value; }
        }


        private ReCommand close;
        public ReCommand Close_Win
        {
            get
            {
                return close ??
                  (close = new ReCommand(obj =>
                  {
                      messageshow.Close();
                  }));
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
