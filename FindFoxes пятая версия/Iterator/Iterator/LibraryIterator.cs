namespace Iterator
{
    class LibraryIterator : IBookIterator
    {
        IBookNumerable aggregate;
        int index = 0;
        public LibraryIterator(IBookNumerable a)
        {
            aggregate = a;
        }
        public bool HasNext()
        {
            return index < aggregate.Count;
        }

        public Book Next()
        {
            return aggregate[index++];
        }
    }
}