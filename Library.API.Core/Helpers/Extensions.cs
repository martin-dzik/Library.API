using Azure;
using Library.API.Data.Models;

namespace Library.API.Helpers
{
    public static class Extensions
    {
        public static Book GetBookWithMergedAuthors(this Book book, IList<Author> authors)
        {
            var newAuthorList = MergeBookAuthorsWithNewAuthors(book.Authors!, authors);
            book.Authors = newAuthorList;

            return book;
        }

        public static List<Author> MergeBookAuthorsWithNewAuthors(ICollection<Author> incomingAuthors, IList<Author> dbAuthors)
        {
            return dbAuthors.UnionBy(incomingAuthors, author => author.Id).ToList();
        }
    }
}
