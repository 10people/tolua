using UnityEngine;
using System.Collections;

public class LuaManager
{
    public static object[] LoadLuaFile(string path)
    {
        return Main.Instance.LuaState.DoFile(path);
    }

    public static void CallLuaFunction(string funName)
    {
        Main.Instance.LuaState.GetFunction(funName).Call();
    }
}
