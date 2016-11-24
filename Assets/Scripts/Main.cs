using UnityEngine;
using System.Collections;
using System.IO;
using LuaInterface;

public class Main : MonoBehaviour
{
    private string LuaFileFolder = "E:/tolua/Assets/Lua/Scripts";

    public LuaState LuaState { get; private set; }

    public static Main Instance
    {
        get
        {
            if (instance == null)
            {
                instance = (GameObject.Find("DontDestroyGB") ?? new GameObject("DontDestroyGB")).AddComponent<Main>();
            }

            return instance;
        }
    }

    private static Main instance;

    public void Init()
    {
#if UNITY_EDITOR
        LuaState.AddSearchPath(LuaFileFolder);
#endif
        LuaState.Start();

        LuaManager.LoadLuaFile("Main");
        LuaFunction main = LuaState.GetFunction("Main");
        main.Call();
        main.Dispose();
        main = null;
    }

    void Start()
    {
#if UNITY_EDITOR
        Init();
#else
        gameObject.AddComponent<TestABLoader>();
#endif
    }

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        instance = this;

        LuaState = new LuaState();
        this.OpenLibs();
        LuaState.LuaSetTop(0);

        LuaBinder.Bind(LuaState);
        LuaCoroutine.Register(LuaState, this);
    }

    void OpenLibs()
    {
        LuaState.OpenLibs(LuaDLL.luaopen_pb);
        LuaState.OpenLibs(LuaDLL.luaopen_lpeg);
        LuaState.OpenLibs(LuaDLL.luaopen_bit);
        LuaState.OpenLibs(LuaDLL.luaopen_socket_core);
    }
}
