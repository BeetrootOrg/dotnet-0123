namespace ConsoleApp
{
    public class TopicList : AbstractList<Topic>
    {
        public bool ItemExists(int id)
        {
            foreach(Topic item in _list)
            {
                if (item.Id == id)
                {
                    return true;
                }
            }

            return false;    
        } 

        public string GetNameById(int id)
        {
            foreach(Topic item in _list)
            {
                if (item.Id == id)
                {
                    return item.Name;
                }
            } 
            
            return null;
        } 
    }
}