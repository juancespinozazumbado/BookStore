using BookStore.Core.Entities.BooksAgregate;

namespace BookStore.CoreUnitTest;
public class BooksShould
{
    [Fact]
    public void BookShouldContainCategory()
    {

        Book book = new Book();

        book.Category = new BookCategory("NameCategory");

        Assert.IsType<BookCategory>(book.Category);
    }

    [Fact]
    public void CategorySouldHAveName()
    {

        BookCategory category = new BookCategory("NAme");

        Assert.Equal("NAme", category.Name);
    }
}