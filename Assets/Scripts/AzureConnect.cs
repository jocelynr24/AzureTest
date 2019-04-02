using Azure.AppServices;
using RESTClient;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq;
using System;

public class AzureConnect : MonoBehaviour
{
    private AppServiceClient client;
    private AppServiceTable<Name> table;

    void Start()
    {
        client = new AppServiceClient("https://poc-ra.azurewebsites.net");
        table = client.GetTable<Name>("Names");
    }

    public void Insert()
    {
        Name name = GetName();
        StartCoroutine(table.Insert<Name>(name, null));
    }

    public void GetAllNames()
    {
        var orderBy = new OrderBy("createdAt", SortDirection.asc);
        TableQuery query = new TableQuery("", 50, 0, "id,firstname,lastname", TableSystemProperty.nil, false, orderBy);
        StartCoroutine(table.Query<Name>(query, GetAllNamesCompleted));
    }

    private void GetAllNamesCompleted(IRestResponse<NestedResults<Name>> response)
    {
        Name[] items = response.Data.results;
        List<Name> names = new List<Name>();
        names = items.ToList();
        int index = int.Parse(GameObject.Find("InputIndex").GetComponent<InputField>().text);
        GameObject.Find("ResultFirstName").GetComponent<Text>().text = names[index].firstname;
        GameObject.Find("ResultLastName").GetComponent<Text>().text = names[index].lastname;
    }

    private Name GetName()
    {
        string firstname = GameObject.Find("InputFirstName").GetComponent<InputField>().text;
        string lastname = GameObject.Find("InputLastName").GetComponent<InputField>().text;
        Name name = new Name();
        name.firstname = firstname;
        name.lastname = lastname;
        return name;
    }
}