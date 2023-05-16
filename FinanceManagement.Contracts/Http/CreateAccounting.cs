namespace AccountingManagement.Contracts.Http
{
    public class CreateAccountingRequest
    {
        public string Title {get;init;}
        public int Value {get;init;}
    }

    public class CreateAccountingResponse
    {
        public string Id {get;init;}
    }


}