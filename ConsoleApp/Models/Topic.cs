namespace ConsoleApp.Models
{
    public class Topic
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<Option> Options { get; } = new();
        public List<User> VoteUsers { get; } = new();
        public string MenuItem { get => $"{Id}. {Name}"; }
        public Option? CreateOption(string name)
        {
            if (string.IsNullOrEmpty(name) || Options.FirstOrDefault(x => x.Name == name) != null) return null;
            var opt = new Option()
            {
                Id = Options.Count + 1,
                Name = name
            };
            Options.Add(opt);
            return opt;
        }

        public User CreateVoteUser(string name, int optionid)
        {
            var option = Options.FirstOrDefault(x => x.Id == optionid);
            if (string.IsNullOrEmpty(name) || IsUserNameVotes(name) || option == null) return null;
            var user = new User()
            {
                Name = name,
                Option = option
            };
            VoteUsers.Add(user);
            return user;
        }

        public bool IsUserNameVotes(string name) =>
            VoteUsers.FirstOrDefault(x => x.Name == name) != null;


        public override string ToString()
        {
            return $"Topic:{Name}\n\t{Description}\nOptions:\n\t{string.Join(";\n\t", Options)}";
        }

        public string Result()
        {
            string results = "";
            foreach (var opt in Options)
            {
                results = $"{results}\n\t{opt.Name} Votes={VoteUsers.Where(x => x.Option.Id == opt.Id).Count()}";
            }
            return $"===============\nTopic:{Name}\n\t{Description}\nVotes:{results}";
        }
    }
}