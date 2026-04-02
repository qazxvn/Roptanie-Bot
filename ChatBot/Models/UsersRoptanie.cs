using System.Collections.Concurrent;

namespace ChatBot.Models;

public class UsersRoptanie
{
    public static ConcurrentDictionary<long?, int> Users { get; set; } = new();

    public static void AddToDict(long? userId)
    {
        Users.AddOrUpdate(userId, 1, (key, oldValue) => oldValue + 1);
    }

    public static int ShowBalance(long? userId)
    {
        return Users.GetValueOrDefault(userId, 0);
    }
}