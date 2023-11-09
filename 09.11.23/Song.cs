using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _09._11._23
{
    internal class Song
    {
        string name;
        string author;
        Song prev;
        public void Name(string name)
        {
            this.name = name;
        }
        public void Name()
        {
            name = "Неизвестно";
        }
        public void Author(string author)
        {
            this.author = author;
        }
        public void Author()
        {
            author = "Неизвестно";
        }
        public void Prev(Song prev)
        {
            this.prev = prev;
        }
        public void Prev()
        {
            prev = null;
        }

        public void PrintSong()
        {
            Console.WriteLine($"{author} - {name}");
        }
        public string Title() { return $"{author} - {name}"; }
        public override bool Equals(object d)
        {
            return RuntimeHelpers.Equals(this, d);
        }
    }
}
