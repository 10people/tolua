
Login = {}
local this = Login

local GameObject = UnityEngine.GameObject
local Instantiate = GameObject.Instantiate
local Vector3 = UnityEngine.Vector3
local Type = System.Type

local parent
local ItemManagerList = {}

function Login.Init()					
	local prefab = ResManager.LoadGB("Login")
	local ins = Instantiate(prefab)
	ins.transform.parent = GameObject.Find("Camera").transform
	ins.transform.localScale = Vector3.one

	local loginOutlet = ins:GetComponent("UILuaOutlet")
	loginOutlet.m_TargetLuaTable = this
	loginOutlet:SetLuaTable()

	this.LoginLabel.text = "Setted by lua."

	LuaManager.LoadLuaFile("LoginItem")

	local itemPrefab = ResManager.LoadGB("LoginItem")
	for i = 0, 9 do
		local itemIns = Instantiate(itemPrefab)
		itemIns.transform.parent = this.LoginGrid.transform
		itemIns.transform.localScale = Vector3.one

		ItemManagerList[i] = itemIns:GetComponent("UILuaOutlet")
		-- local currentItemTable = LoginItem
		local currentItemTable = LoginItem.New(LoginItem)
		ItemManagerList[i].m_TargetLuaTable = currentItemTable
		ItemManagerList[i]:SetLuaTable()

		currentItemTable:Init(i)
	end

	this.LoginGrid.arrangement = UIGrid.Arrangement.Vertical
	this.LoginGrid.cellHeight = 50
	this.LoginGrid:Reposition()

end