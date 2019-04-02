using Azure.AppServices;
using RESTClient;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq;

public class AzureCoordinate : MonoBehaviour
{
    private AppServiceClient client;
    private AppServiceTable<Name> table;

    void Start()
    {
        client = new AppServiceClient("https://poc-ra.azurewebsites.net");
        table = client.GetTable<Name>("Coordinates");
    }

    public void Insert()
    {
        Coordinate coordinate = GetCoordinates();
        StartCoroutine(table.Insert<Coordinate>(coordinate, null));
    }

    private Coordinate GetCoordinates()
    {
        string x = GameObject.Find("x").GetComponent<Text>().text;
        string y = GameObject.Find("y").GetComponent<Text>().text;
        string z = GameObject.Find("z").GetComponent<Text>().text;
        string description = GameObject.Find("InputField").GetComponent<InputField>().text;
        Coordinate coordinate = new Coordinate();
        coordinate.x = x;
        coordinate.y = y;
        coordinate.y = z;
        coordinate.description = description;
        return coordinate;
    }
}