using System;
using System.Collections.Generic;

namespace Tests.Assignment5.Model
{
    /// <summary>
    /// <para>Book is immutable.</para>
    /// <para>Book contains information about:</para>
    /// <para>Title</para>
    /// <para>List of Authors</para>
    /// <para>Copyright Year</para>
    /// <para>Number of Pages</para>
    /// </summary>
    public class Book
    {
        private readonly string _title;
        private readonly List<string> _authors;
        private readonly int _copyrightYear;
        private readonly int _numberOfPages;
        /* Rep Invariant:
         *      Title != null + white spaced.
         *      List of Authors != non null + size >= 1
         *      1900 < copyrightYear <= 2018
         *      numberOfPages >= 1
         *              
         * AF(title,author,copyrightYear,numberOfPages) = title * author + copyrightYear + numberOfPages
         */

        
        /// <summary>
        /// Creates a new book
        /// </summary>
        /// <param name="title">The title of the book</param>
        /// <param name="author">The author(s) of the book</param>
        /// <param name="copyrightYear">the year of release</param>
        /// <param name="numberOfPages">number of pages</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public Book(string title, List<string> authors, int copyrightYear, int numberOfPages)
        {
            _title = title;
            _authors = new List<string>(authors);
            _copyrightYear = copyrightYear;
            _numberOfPages = numberOfPages;
            _CheckRep();
        }
        // simple observers of this class.

        public string GetTitle() => _title;
        public List<string> GetAuthors() => new List<string>(_authors);
        public int GetCopyrightYear() => _copyrightYear;
        public int GetNumberOfPages() => _numberOfPages;
        public override bool Equals(object obj)
        {
            if (!(obj is Book book))
            {
              return false;
            }
            Book other = (Book) obj;
            return _title == book._title &&
                   _AuthorsEquality(other.GetAuthors()) &&
                   _copyrightYear == book._copyrightYear &&
                   _numberOfPages == book._numberOfPages;
        }
        
        public override int GetHashCode()
        {
            return HashCode.Combine(_title, _authors, _copyrightYear, _numberOfPages);
        }

        public override string ToString()
        {
            return $"[{_title} by {_authors} - p. {_numberOfPages}. Copyright: {_copyrightYear}]";
        }

        private bool _AuthorsEquality(List<string> toCompare)
        {
            HashSet<string> actual = new HashSet<string>(_authors);
            HashSet<string> other = new HashSet<string>(toCompare);
            return (actual.SetEquals(other)) ? true : false;
        }

        /// <summary>
        /// Checks class invariance and AF.
        /// </summary>
        private void _CheckRep()
        {
            // title invariance checker: Title != null + white spaced.
            _ = (String.IsNullOrWhiteSpace(_title)) ? throw new ArgumentNullException("title", "The title cannot be empty") : "";
            // author invariance checker: List of Authors != non null + size >= 1
            _ = _authors ?? throw new ArgumentNullException("author", "author cannot be null");
            _ = (_authors.Count < 1 || String.IsNullOrWhiteSpace(_authors[0])) ? throw new ArgumentNullException("At least one Author must be not Whitespaced") : "";
            // 1900 < copyrightYear <= 2018
            _ = (_copyrightYear > 2019 || _copyrightYear < 1900 ) ? throw new ArgumentOutOfRangeException("Copyright Year", "Invalid Copyright Year") : "";
            // numberOfPages >= 1
            _ = (_numberOfPages < 1) ? throw new ArgumentOutOfRangeException("Number of Pages","A book cannot have less than one page.") : "";
        }
    }
}