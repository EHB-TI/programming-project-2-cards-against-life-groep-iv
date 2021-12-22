using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PGData
{
    public int success { get; set; }
    public PG PG { get; set; }
}

[System.Serializable]
public class PG
{
    public List<PGAnswer> answers { get; set; }
    public List<PGQuestion> questions { get; set; }
}


[System.Serializable]
public class PGAnswer
{
    public int id { get; set; }
    public string answer { get; set; }
}
[System.Serializable]
public class PGQuestion
{
    public int id { get; set; }
    public string question { get; set; }
}

