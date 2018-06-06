using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RestAPITestFrameWork.Models
{

    class UserData
    {
        [JsonProperty("data")]
        public User User { get; set; }

        public UserData(int id, string firstName, string lastName, Uri avatar)
        {
            User = new User(id, firstName, lastName, avatar);
        }

        public bool Equals(UserData other)
        {
            return User.Equals((User)other.User);
        }

    }


    class User
    {
        [JsonProperty("id")] public int Id { get; set; }

        [JsonProperty("first_name")] public string FirstName { get; set; }

        [JsonProperty("last_name")] public string LastName { get; set; }

        [JsonProperty("avatar")] public Uri Avatar { get; set; }

        public User(int id, string firstName, string lastName, Uri avatar)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Avatar = avatar;
        }

        protected bool Equals(User other)
        {
            return Id == other.Id && string.Equals(FirstName, other.FirstName) && string.Equals(LastName, other.LastName) && Equals(Avatar, other.Avatar);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((User) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Id;
                hashCode = (hashCode * 397) ^ (FirstName != null ? FirstName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (LastName != null ? LastName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Avatar != null ? Avatar.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}
