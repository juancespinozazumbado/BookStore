using BookStore.Core.Entities;
using BookStore.Core.interfaces;


namespace BookStore.Core.Entities.BooksAgregate;

public class BookCategory : BaseEntity, IAgregateRoot
{

    public BookCategory(string name){
        this.Name = name;
    }
    public string? Name {get; private set;}
}
