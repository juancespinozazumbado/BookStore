﻿using BookStore.Core.interfaces;


namespace BookStore.Core.Entities.BooksAgregate;

public class Book : BaseEntity, IAgregateRoot
{
    public string? Name { get; private set; }

    public string?Description { get; private set; }

    public DateTime PublishingDate { set; private get; }

    public BookCategory? Category { get; set; }

}
