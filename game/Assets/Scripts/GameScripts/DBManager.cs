using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DBManager
{
    //Author: De Vogel Ryan
    //source: https://www.youtube.com/watch?v=SKbY-0zt2VE&t=141s It's a serie

    public static string username;
    public static int score;

    // This is to check if the user is logged in
    public static bool LoggedIn { get { return username != null; } }

    public static void LogOut()
    {
        username = null;
    }
}
