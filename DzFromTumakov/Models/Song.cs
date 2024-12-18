using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DzFromTumakov.Models
{
    class Song
    {
        private string name;
        private string author;
        private Song? prev;

        public Song(string name, string author)
        {
            this.name = name;
            this.author = author;
            prev = null;
        }
        public Song(string name, string author, Song prev)
        {
            this.name = name;
            this.author = author;
            this.prev = prev;
        }

        public Song()
        {
            name = "Зима в сердце";
            author = "Моя мишель";
            prev = null;
        }


        public void SetAuthor(string author)
        {
            this.author = author;
        }
        public void SetPreviousSong(Song prev)
        {
            this.prev = prev;
        }
        public string Title()
        {
            return $"{name} - {author}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Song))
            {
                return false;
            }

            Song other = (Song)obj;
            return name == other.name && author == other.author;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(name, author);
        }

        
        public void PrintChain()
        {
            Song current = this;
            while (current != null)
            {
                Console.WriteLine(current.Title());
                current = current.prev;
            }
        }

    }
}
