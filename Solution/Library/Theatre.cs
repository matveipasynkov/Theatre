namespace Library;

/// <summary>
/// Класс "Театр" из условия.
/// </summary>
public class Theatre : IComparable<Theatre>
{
    private Contacts contacts;

    public Contacts ContactsOfTheatre
    {
        get
        {
            return contacts;
        }
    }

    private string commonName;

    public string CommonName
    {
        get
        {
            return commonName;
        }
    }

    private string fullName;

    public string FullName
    {
        get
        {
            return fullName;
        }
    }

    private string shortName;

    public string ShortName
    {
        get
        {
            return shortName;
        }
    }

    private string chiefName;

    public string ChiefName
    {
        get
        {
            return chiefName;
        }
    }

    private string chiefPosition;

    public string ChiefPosition
    {
        get
        {
            return chiefPosition;
        }
    }

    private string workingHours;

    public string WorkingHours
    {
        get
        {
            return workingHours;
        }
    }

    private string clarificationOfWorkingHours;

    public string ClarificationOfWorkingHours
    {
        get
        {
            return clarificationOfWorkingHours;
        }
    }

    private long okpo;

    public long Okpo
    {
        get
        {
            return okpo;
        }
    }

    private long inn;

    public long Inn
    {
        get
        {
            return inn;
        }
    }

    private int mainHallCapacity;

    public int MainHallCapacity
    {
        get
        {
            return mainHallCapacity;
        }
    }

    private int additionalHallCapacity;

    public int AdditionalHallCapacity
    {
        get
        {
            return additionalHallCapacity;
        }
    }

    private double xWGS;

    public double XWGS
    {
        get
        {
            return xWGS;
        }
    }

    private double yWGS;

    public double YWGS
    {
        get
        {
            return yWGS;
        }
    }

    private long globalId;

    public long GlobalId
    {
        get
        {
            return globalId;
        }
    }

    public Theatre()
    {
        this.contacts = new Contacts();
        this.commonName = "";
        this.fullName = "";
        this.shortName = "";
        this.chiefName = "";
        this.chiefPosition = "";
        this.workingHours = "";
        this.clarificationOfWorkingHours = "";
        this.okpo = 0;
        this.inn = 0;
        this.mainHallCapacity = 0;
        this.additionalHallCapacity = 0;
        this.xWGS = 0;
        this.yWGS = 0;
        this.globalId = 0;
    }

    public Theatre(string commonName = "", string fullName = "", string shortName = "",
        string admArea = "", string district = "", string address = "",
        string chiefName = "", string chiefPosition = "",
        string publicPhone = "", string fax = "", string email = "",
        string workingHours = "", string clarificationOfWorkingHours = "", string webSite = "",
        string okpo = "0", string inn = "0", string mainHallCapacity = "0",
        string additionalHallCapacity = "0",
        string xWGS = "0", string yWGS = "0", string globalId = "0")
    {
        this.contacts = new Contacts(admArea, district, address, publicPhone, fax, email, webSite);
        this.commonName = commonName;
        this.fullName = fullName;
        this.shortName = shortName;
        this.chiefName = chiefName;
        this.chiefPosition = chiefPosition;
        this.workingHours = workingHours;
        this.clarificationOfWorkingHours = clarificationOfWorkingHours;
        long.TryParse(okpo, out this.okpo);
        long.TryParse(inn, out this.inn);
        int.TryParse(mainHallCapacity, out this.mainHallCapacity);
        int.TryParse(additionalHallCapacity, out this.additionalHallCapacity);
        double.TryParse(xWGS, out this.xWGS);
        double.TryParse(yWGS, out this.yWGS);
        long.TryParse(globalId, out this.globalId);
    }

    public int CompareTo(Theatre theatre)
    {
        int thisCapacity = this.MainHallCapacity + this.AdditionalHallCapacity;
        int objCapacity = theatre.MainHallCapacity + theatre.AdditionalHallCapacity;

        if (thisCapacity > objCapacity)
        {
            return 1;
        }
        else if (thisCapacity == objCapacity)
        {
            return 0;
        }
        else
        {
            return -1;
        }
    }
}