--???????????lua??
function Main()		
	LuaManager.LoadLuaFile("Login")			
	LuaManager.CallLuaFunction("Login.Init")				
end

--??????
function OnLevelWasLoaded(level)
	Time.timeSinceLevelLoad = 0
end