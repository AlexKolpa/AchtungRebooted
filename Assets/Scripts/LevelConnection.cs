using UnityEngine;
using System.Collections;

public class LevelConnection  {

    public Level EndPoint1 { get; private set; }
    public Level EndPoint2 { get; private set; }

    public LevelConnection(Level endPoint1, Level endPoint2)
    {
        EndPoint1 = endPoint1;
        EndPoint2 = endPoint2;
    }
}
