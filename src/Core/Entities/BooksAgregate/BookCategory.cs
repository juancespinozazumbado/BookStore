using Biblioteca.Core.interfaces;

namespace Biblioteca.Core.Entities.BooksAgregate;

public class BookCategory : BaseEntity, IAgregateRoot
{

    public BookCategory(string name){
        this.Name = name;
    }
    public string? Name {get; private set;}
}
