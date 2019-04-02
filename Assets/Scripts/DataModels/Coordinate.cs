using System;
using Azure.AppServices;

[Serializable]
public class Coordinate : DataModel
{
    public string x;
    public string y;
    public string z;
    public string description;
}