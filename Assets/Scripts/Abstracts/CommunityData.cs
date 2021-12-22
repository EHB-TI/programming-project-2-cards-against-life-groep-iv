using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class CommunityData
{
    public int success { get; set; }
    public Community Community { get; set; }

    public List<Community> communities { get; set; }
}


[System.Serializable]
public class Community
{
    public List<CommunityAnswer> answers { get; set; }
    public List<CommunityQuestion> questions { get; set; }
}


[System.Serializable]
public class CommunityAnswer
{
    public int id { get; set; }
    public string answer { get; set; }
}
[System.Serializable]
public class CommunityQuestion
{
    public int id { get; set; }
    public string question { get; set; }
}

