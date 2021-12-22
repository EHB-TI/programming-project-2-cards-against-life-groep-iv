using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class RData
{
    public int success { get; set; }
    public RRated R { get; set; }
}

[System.Serializable]
public class RRated
{
    public List<RAnswer> Answers { get; set; }
    public List<RQuestion> Questions { get; set; }
}


[System.Serializable]
public class RAnswer
{
    public int id { get; set; }
    public string value { get; set; }
}
[System.Serializable]
public class RQuestion
{
    public int id { get; set; }
    public string value { get; set; }
}

