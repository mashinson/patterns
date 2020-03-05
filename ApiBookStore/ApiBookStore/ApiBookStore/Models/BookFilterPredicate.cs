using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiBookStore.Models
{
    public interface IFilterPredicate
    {
        bool Predicate(Book task);
        void Init(FilterData filter);
    }
    public class BookFilterPredicate
    {
        private FilterData _filter;
        private List<IFilterPredicate> conditions;
        public BookFilterPredicate(FilterData filter, List<IFilterPredicate> predicate)
        {
            _filter = filter;
            conditions = predicate;
            foreach (var item in conditions)
            {
                item.Init(filter);
            }
        }
        public bool CheckBook(Book book)
        {
            bool value = true;
            foreach (var item in conditions)
            {
                value &= item.Predicate(book);
            }
            return value;
        }

    }

    public class AuthorIDFilterPredicate : IFilterPredicate
    {
        private int _authorID;
        public void Init(FilterData filter)
        {
            _authorID = filter.AuthorID;
        }
        public bool Predicate(Book book)
        {
            return _authorID == -1 ? true : book.Author.ID == _authorID;
        }


    }

    public class GenreIDFilterPredicate : IFilterPredicate
    {
        private int _genreID;
        public void Init(FilterData filter)
        {
            _genreID = filter.GenreID;
        }
        public bool Predicate(Book book)
        {
            return _genreID == -1 ? true : book.Genre.ID == _genreID;

        }
    }

    public class CreationDateFilterPredicate : IFilterPredicate
    {
        private int? _date;
        public void Init(FilterData filter)
        {
            _date = filter.CreationDate;
        }
        public bool Predicate(Book book)
        {
            return _date == null ? true : book.Year == _date;

        }
    }

    public class PublishingHouseFilterPredicate : IFilterPredicate
    {
        private int _house;
        public void Init(FilterData filter)
        {
            _house = filter.HouseID;
        }
        public bool Predicate(Book book)
        {
            return _house == -1 ? true : book.PublishingHome.ID == _house;

        }
    }
}