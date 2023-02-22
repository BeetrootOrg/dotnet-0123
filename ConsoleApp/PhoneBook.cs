namespace ConsoleApp
{
    public class PhoneBook
    {
        public Contact[] Contacts { get; set; }

        public PhoneBook(params Contact[] contacts)
        {
            Contacts = contacts;
        }

        public void Add(Contact contact)
        {
            Contact[] contacts = Contacts;
            Array.Resize(ref contacts, contacts.Length + 1);
            contacts[^1] = contact;
            Contacts = contacts;
        }
    }
}