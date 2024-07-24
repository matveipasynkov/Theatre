using System;
namespace Library;

/// <summary>
/// Класс "Контакты" из условия.
/// </summary>
public class Contacts
{
	private string address;

	public string Address
	{
		get
		{
			return address;
		}
	}

    private string publicPhone;

    public string PublicPhone
	{
		get
		{
			return publicPhone;
		}
	}

	private string fax;

	public string Fax
	{
		get
		{
			return fax;
		}
	}

    private string district;

    public string District
	{
		get
		{
			return district;
		}
	}

    private string admArea;

    public string AdmArea
	{
		get
		{
			return admArea;
		}
	}

    private string email;

    public string Email
    {
        get
        {
            return email;
        }
    }

    private string webSite;

    public string WebSite
    {
        get
        {
            return webSite;
        }
    }

    public Contacts()
	{
		this.address = "";
		this.publicPhone = "";
		this.fax = "";
		this.district = "";
		this.admArea = "";
		this.email = "";
		this.webSite = "";
	}

	public Contacts(string admArea = "", string district = "", string address = "",
		string publicPhone = "", string fax = "", string email = "", string webSite = "")
	{
        this.address = address;
        this.publicPhone = publicPhone;
        this.fax = fax;
        this.district = district;
        this.admArea = admArea;
		this.email = email;
		this.webSite = webSite;
    }
}