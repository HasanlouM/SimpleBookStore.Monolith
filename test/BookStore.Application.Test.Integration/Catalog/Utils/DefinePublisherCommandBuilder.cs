using BookStore.Application.Contract.Catalog.PublisherAggregate.Commands;

namespace BookStore.Application.Test.Integration.Catalog.Utils;

internal class DefinePublisherCommandBuilder
{
    private string _name = "Publisher's Name";
    private string _address = "Publisher's Address";
    private string _phoneNumber = "09122222222";
    private string _email = "Publisher@gmail.com";

    private DefinePublisherCommandBuilder() { }

    public static DefinePublisherCommandBuilder New()
    {
        return new DefinePublisherCommandBuilder();
    }

    public DefinePublisherCommandBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public DefinePublisherCommandBuilder WithAddress(string address)
    {
        _address = address;
        return this;
    }

    public DefinePublisherCommandBuilder WithPhoneNumber(string phoneNumber)
    {
        _phoneNumber = phoneNumber;
        return this;
    }

    public DefinePublisherCommandBuilder WithEmail(string email)
    {
        _email = email;
        return this;
    }

    public DefinePublisherCommand Build()
    {
        return new DefinePublisherCommand
        {
            Name = _name,
            Address = _address,
            PhoneNumber = _phoneNumber,
            Email = _email
        };
    }
}