public class DataManager
{
    // These are the attributes
    private List<Account> _accounts;
    private List<Party> _parties;
    private List<Index> _indexes;
    private List<ActivityCode> _activityCodes;

    public DataManager()
    {
        GetAccountData();
        GetIndexData();
        GetPartyData();
    }

    // These are the methods
    public List<string> GetFundsFromParty(int partyChoice)
    {
        List<string> funds = new List<string>();
        for (int i = 0; i < _parties.Count; i++)
        {
            Party party = _parties[i];
            if (partyChoice == i + 1)
            {
                funds = party.GetFunds();
            }
        }
        return funds;
    }

    public string GetIndexFromActivity(string activityCode)
    {
        string indexCode = "";
        for (int i = 0; i < _activityCodes.Count; i++)
        {
            if (activityCode == _activityCodes[i].GetActivityCode())
            {
                indexCode = _activityCodes[i].GetIndexCode();
            } 
        }
        for (int i = 0; i < _indexes.Count; i++)
        {
            if (indexCode == _indexes[i].GetIndexCode())
            {
                indexCode = _indexes[i].GetWIndexCode();
            } 
        }
        return indexCode;
    }

    public string GetAccountDescription(string accountCode)
    {
        string accountDescription = "";
        for (int i = 0; i < _accounts.Count; i++)
        {
            if (accountCode == _accounts[i].GetAccountCode())
            {
                accountDescription = _accounts[i].GetAccountDescription();
            } 
        }
        return accountDescription;
    }
    
    public void DisplayIndexList()
    {
        foreach (Index index in _indexes)
        {
            for (int i = 0; i < 40; i++)
            {
                Console.Write("-");
            }
            index.DisplayIndexAndActivities();
        }
    }

    public void DisplayPartyList()
    {
        int index = 1;
        foreach (Party party in _parties)
        {
            Console.Write($"{index}. ");
            party.DisplayParty();
            index++;
        }
    }

    public void GetAccountData()
    {
        _accounts = new List<Account>();
        string fileName = "accountCodes.csv";
        string[] lines = System.IO.File.ReadAllLines(fileName);
        foreach (string line in lines)
        {
            string[] parts = line.Split(",");
            string accountCode = parts[0];
            string accountDescription = parts[1];
            Account account = new Account(accountCode, accountDescription);
            _accounts.Add(account);
        }
    }

    public void GetIndexData()
    {
        _indexes = new List<Index>();
        _activityCodes = new List<ActivityCode>();
        string fileName = "indexDescriptions.csv";
        string[] lines = System.IO.File.ReadAllLines(fileName);
        List<string> indexListChecker = new List<string>();
        foreach (string line in lines)
        {
            string[] parts = line.Split(",");
            string indexCode = parts[0];
            string activityCode = parts[1];
            string indexDescription = parts[2];
            ActivityCode activity = new ActivityCode(activityCode, indexDescription, indexCode);
            _activityCodes.Add(activity);
            if (!indexListChecker.Contains(indexCode))
            {
                indexListChecker.Add(indexCode);
                Index index = new Index(indexCode, indexDescription);
                index.AddActivityCode(activity);
                _indexes.Add(index);                
            }
            else
            {
                foreach (Index index in _indexes)
                {
                    string code = index.GetIndexCode();
                    if (code == indexCode)
                    {
                        index.AddActivityCode(activity);
                    }
                }
            }
            
        }
    }

    public void GetPartyData()
    {
        _parties = new List<Party>();
        string fileName = "resp&delParties.csv";
        string[] lines = System.IO.File.ReadAllLines(fileName);
        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split(",");
            string firstName = parts[0];
            string lastName = parts[1];
            string title = parts[2];
            string department = parts[3];
            string supervisor = parts[4];
            string indexes = parts[5];
            List<string> indexList = new List<string>();
            string activities = parts[6];
            List<string> activitiesList = new List<string>();
            if (indexes != "")
            {
                string[] splitIndexes = indexes.Split("-");
                foreach (string index in splitIndexes)
                {
                    indexList.Add(index);
                }
            }
            if (activities != "")
            {
                string[] splitActivities = activities.Split("-");
                foreach (string activity in splitActivities)
                {
                    activitiesList.Add(activity);
                }
            }
            if (indexes == "")        
            {
                DelegatedParty delegatedParty = new DelegatedParty(firstName, lastName, title, department, activitiesList, supervisor);
                _parties.Add(delegatedParty);
            }
            else
            {
                ResponsibleParty responsibleParty = new ResponsibleParty(firstName, lastName, title, department, activitiesList, indexList);
                _parties.Add(responsibleParty);
            }
            
        }
    }
}