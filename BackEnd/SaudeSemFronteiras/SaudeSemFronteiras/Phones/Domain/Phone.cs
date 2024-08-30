using SaudeSemFronteiras.Application.Appointments.Domain;
using SaudeSemFronteiras.Application.Chats.Domain;
using SaudeSemFronteiras.Application.Chats.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaudeSemFronteiras.Application.Phones.Domain;
public class Phone
{
    public long Id { get; private set; }
    public string Number { get; private set; } = string.Empty;
    public long UserId { get; private set; }

    public Phone(long id, string number, long userId)
    {
        Id = id;
        Number = number;
        UserId = userId;
    }

    public static Phone Create(string number, long userId) =>
        new(0, number, userId);

    public void Update(string number, long userId)
    {
        Number = number;
        UserId = userId;
    }

    public void Delete(long id)
    {
        Id = id;
    }
}
