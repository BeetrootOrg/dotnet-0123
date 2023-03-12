namespace ConsoleApp
{
    public class OptionList : AbstractList<Option>
    {
        public bool ItemExists(int id, int topicId)
        {
            foreach(Option item in _list)
            {
                if (item.Id == id && item.TopicId == topicId)
                {
                    return true;
                }
            }

            return false;
        }

        public void AddVote(int id, int topicId)
        {
            foreach(Option item in _list)
            {
                if (item.Id == id && item.TopicId == topicId)
                {
                    item.AddVote();
                    break;
                }
            }
        } 

        public void Show(int topicId)
        {
            foreach(Option item in _list)
            {
                if (item.TopicId == topicId)
                {
                    Console.WriteLine($"{item.FullData}");
                }    
            } 
        } 

        public void SubMenu(int topicId)
        {
            foreach(Option item in _list)
            {
                if (item.TopicId == topicId)
                {
                    Console.WriteLine($"{item}");
                }
            }
            Console.WriteLine("0. Exit"); 
        }
    }
}    