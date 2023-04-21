using System.ComponentModel.DataAnnotations.Schema;

using Numeral.CoffeeShop.Domain.Identity.ValueObjects;
using Numeral.CoffeeShop.Domain.Models;

namespace Numeral.CoffeeShop.Domain.Identity;

public sealed class User : AggregateRoot<UserId, Guid>
{
    public string Role { get; private set; }
    public string FirstName { get; private set; }
    [Column(TypeName = "VARBINARY(64)")]
    public byte[] Salt { get; set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
    [Column(TypeName = "VARBINARY(64)")]
    public byte[] PasswordHash { get; private set; }
    
#pragma warning disable CS8618
    private User() {}
#pragma warning restore CS8618

    public User(UserId id, string firstName, string lastName, string email, byte[] passwordHash, byte[] salt, string role)
    :base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PasswordHash = passwordHash;
        Salt = salt;
        Role = role;
    }

    public static User Create(string firstName, string lastName, string email, byte[] passwordHash,byte[] salt, string role)
    {
        return new( UserId.CreateUnique(), firstName, lastName, email, passwordHash, salt, role);
    }
    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        User other = (User)obj;
        return Email == other.Email;
    }

    public override int GetHashCode()
    {
        return Email.GetHashCode();
    }
}