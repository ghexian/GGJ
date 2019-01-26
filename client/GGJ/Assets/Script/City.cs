using System.Collections;
using System.Collections.Generic;


public class City
{
    public string id;
    public string name;
    public List<Edge> adjs;

    public City(string _id, string _name, string _adjs)
    {
        id = _id;
        name = _name;
        string[] endCityIds = _adjs.Split(':');
        adjs = new List<Edge>();
        for(int i = 0; i < endCityIds.Length; ++i)
        {
            adjs.Add(new Edge(endCityIds[i]));
        }
    }
}

public class Edge
{
    public string endCityId;
    //public int price;

    public Edge(string _endCityId)
    {
        endCityId = _endCityId;
    }
}