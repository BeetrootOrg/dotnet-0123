namespace ConsoleApp
{
    public class PhoneBook
    {
        public Contact[] Contacts { get; set; }

        public PhoneBook (params Contact[] contacts)
        {
            Contacts = contacts;
        }

        public void Add(Contact contact)
        {
            var contacts = Contacts;
            Array.Resize(ref contacts, Contacts.Length+1);
            contacts[^1] = contact;
            Contacts = contacts;
        }
    }
}