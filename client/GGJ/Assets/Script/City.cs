using System.Collections;
using System.Collections.Generic;


public class City
{
    public string id;
    public string name;
    public Dictionary<string, Edge> adjs;

    public City(string _id, string _name)
    {
        id = _id;
        name = _name;
        //string[] endCityIds = _adjs.Split(':');
        adjs = new Dictionary<string, Edge>();
        //for(int i = 0; i < endCityIds.Length; ++i)
        //{
        //    adjs.Add(new Edge(endCityIds[i]));
        //}
    }
}

public class Edge
{
    public string endCityId;
    public int price;

    public Edge(string _endCityId, int _price)
    {
        endCityId = _endCityId;
        price = _price;
    }
}