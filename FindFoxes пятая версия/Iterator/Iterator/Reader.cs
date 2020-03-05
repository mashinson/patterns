using System;

namespace Iterator
{
    class Reader
    {
        public void SeeBooks(Library library)
        {
            IBookIterator iterator = library.CreateIterator();
            while (iterator.HasNext())
            {
                Book book = iterator.Next();
                Console.WriteLine(book.Name);
            }
        }
    }
}