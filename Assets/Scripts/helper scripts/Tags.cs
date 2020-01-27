using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tags
{
    public static string WALL = "Wall";
    public static string FOOD = "Food";
    public static string RED = "Red";
    public static string BLUE = "Blue";
    public static string GREEN = "Green";
    public static string YELLOW = "Yellow";
    public static string TAIL = "Tail";
}

public class Metrics
{
    public static float NODE = 2f;
}

public enum PlayerDirection
{
    LEFT=0,UP=1,RIGHT=2,DOWN=3,COUNT=4
}

public enum foodColors
{
    RED=0,BLUE=1,GREEN=2,YELLOW=3
}
