using UnityEngine;
using System.Collections;

public class LuaManager
{
    public static void LoadLuaFile(string path)
    {
#if UNITY_EDITOR
        Main.Instance.LuaState.DoFile(path);
#else
        if (!path.EndsWith(".lua"))
        {
            path += ".lua";
        }

        byte[] bytes = Resources.Load<TextAsset>(path).bytes;

        Main.Instance.LuaState.LuaLoadBuffer(bytes, bytes.Length, path);
#endif
    }

    public static void CallLuaFunction(string funName)
    {
        Main.Instance.LuaState.GetFunction(funName).Call();
    }
}
