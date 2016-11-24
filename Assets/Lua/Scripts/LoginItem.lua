
LoginItem = {}
local this = LoginItem

function LoginItem.New(table)
	assert(table ~= nil)

	table.__index = table

	local tb = {}
	setmetatable(tb, table)

	return tb
end

function LoginItem:Init(num)
	self.LoginItemLabel.text = tostring(num)
end