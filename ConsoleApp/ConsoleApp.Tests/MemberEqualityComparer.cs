using System;
using System.Collections.Generic;

using ConsoleApp.Models.Slack;

namespace ConsoleApp.Tests
{
    internal class MemberEqualityComparer : IEqualityComparer<Member>
    {
        public bool Equals(Member x, Member y)
        {
            return ReferenceEquals(x, y)
                || (x is not null
                && y is not null
                && x.GetType() == y.GetType()
                && x.RealName == y.RealName &&
                            x.Name == y.Name &&
                            x.IsAdmin == y.IsAdmin &&
                            x.IsOwner == y.IsOwner &&
                            x.IsBot == y.IsBot &&
                            x.IsAppUser == y.IsAppUser &&
                            x.IsPrimaryOwner == y.IsPrimaryOwner);
        }

        public int GetHashCode(Member obj)
        {
            return HashCode.Combine(obj.RealName, obj.Name, obj.IsAdmin, obj.IsOwner, obj.IsBot, obj.IsAppUser, obj.IsPrimaryOwner);
        }
    }
}