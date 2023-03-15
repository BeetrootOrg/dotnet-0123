namespace ConsoleApp
{
    public class OptionList : VoteList<Option>
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

        public OptionList FilteredByTopic(int topicId)
        {
            OptionList filteredList = new OptionList();
            
            foreach(Option item in _list)
            {
                if (item.TopicId == topicId)
                {
                    filteredList.Add(item);
                }    
            } 
            
            return filteredList;
        } 
    }
}    