using UnityEngine;
using System.Collections;

public class ResManager
{
    public static GameObject LoadGB(string path)
    {
        return Resources.Load<GameObject>(path);
    }
}
