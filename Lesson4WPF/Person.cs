using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Lesson4WPF
{
    public class Person
    {
        public Person(string fullname, ListBox messages, Label lastMessage)
        {
            Fullname = fullname;
            Messages = messages;
            LastMessage = lastMessage;

        }

        public string Fullname { get; set; }

        public ListBox Messages { get; set; }

        public Label LastMessage { get; set; }

    }
}
