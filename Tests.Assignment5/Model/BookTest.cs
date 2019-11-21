using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.Assignment5.Model
{
    class BookTest
    {
        public Book book;
        [SetUp]
        public void init() 
        {
            string title = "1984";
            List<string> authors = new List<string>();
            authors.Add("George Orwell");
            int copyrightRelease = 1949;
            int numberOfPages = 328;
            book = new Book(title: title, authors: authors, copyrightYear: copyrightRelease, numberOfPages: numberOfPages);
        }

        [Test]
        public void Test_BookIsImmutable()
        {
            // Assemble
            string title = "1984";
            List<string> authors = new List<string>();
            authors.Add("George Orwell");
            int copyrightRelease = 1949;
            int numberOfPages = 328;
            book = new Book(title: title, authors: authors, copyrightYear: copyrightRelease, numberOfPages: numberOfPages);
            // Act by changing everything
            // change title
            title = "Brave new World";
            // add author to list
            authors.Add("Bob");
            // change release date
            copyrightRelease = 1984;
            // number of pages
            numberOfPages = 200;
            Book secondBook = new Book(title: title, authors: authors, copyrightYear: copyrightRelease, numberOfPages: numberOfPages);
            // Assert
            Assert.That(book.GetTitle(), Is.Not.EqualTo(title));
            Assert.That(book.GetAuthors(), Is.Not.EqualTo(authors));
            Assert.That(book.GetCopyrightYear(), Is.Not.EqualTo(copyrightRelease));
            Assert.That(book.GetNumberOfPages(), Is.Not.EqualTo(numberOfPages));
            Assert.That(book, Is.Not.EqualTo(secondBook));
        }

        [Test]
        public void Test_ForEquality()
        {
            // Assemble
            Book secondBook;
            Book thirdBook;
            Book invalidBook;
            bool reflexive;
            bool symmetric;
            bool transitive;
            bool invalid;
            string title = "1984";
            List<string> authors = new List<string>();
            authors.Add("George Orwell");
            int copyrightRelease = 1949;
            int numberOfPages = 328;
            secondBook = new Book(title: title, authors: authors, copyrightYear: copyrightRelease, numberOfPages: numberOfPages);
            thirdBook = new Book(title: title, authors: authors, copyrightYear: copyrightRelease, numberOfPages: numberOfPages);
            invalidBook = new Book(title: title, authors: authors, copyrightYear: copyrightRelease, numberOfPages: 1);
            // Act
            reflexive = book.Equals(book);
            symmetric = (book.Equals(secondBook) && secondBook.Equals(book));
            transitive = (book.Equals(secondBook) && secondBook.Equals(thirdBook) && book.Equals(thirdBook));
            invalid = book.Equals(invalidBook);
            // Assert
            // reflexive
            Assert.That(reflexive, Is.True);
            Assert.That(symmetric, Is.True);
            Assert.That(transitive, Is.True);
            Assert.That(invalid, Is.False);
        }

    }
}
