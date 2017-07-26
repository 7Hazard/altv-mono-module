local pool = {}
local ehandlers = {}
local extf = {}

local sendMessage = __orange__.SendPlayerMessage
local createBlipP = __orange__.CreateBlipForPlayer
local createMarkerP = __orange__.CreateMarkerForPlayer
local getHeading = __orange__.GetPlayerHeading
local getModel = __orange__.GetPlayerModel
local getName = __orange__.GetPlayerName
local getCoords = __orange__.GetPlayerCoords
local giveWeapon = __orange__.GivePlayerWeapon
local removeWeapons = __orange__.RemovePlayerWeapons
local sendNotif = __orange__.SendPlayerNotification
local setArmour = __orange__.SetPlayerArmour
local setHeading = __orange__.SetPlayerHeading
local setHealth = __orange__.SetPlayerHealth
local clientEv = __orange__.ClientEvent
local setInfoMsg = __orange__.SetPlayerInfoMsg
local setIntoVeh = __orange__.SetPlayerIntoVehicle
local setModel = __orange__.SetPlayerModel
local setCoords = __orange__.SetPlayerCoords
local getGUID = __orange__.GetPlayerGUID
local setName = __orange__.SetPlayerName
local kick = __orange__.KickPlayer
local getWorld = __orange__.GetPlayerWorld
local setWorld = __orange__.SetPlayerWorld

Player = {}
Player.__pool = pool

function Player:new(id)
	local obj = {}
		obj.__type__ = "player"
		obj.__ehandlers = {}
		obj.__meta = {}
		obj.id = id
		obj.guid = getGUID(id)

	function obj:attachBlip(name, scale, color, sprite)
		local b = Blip:Create(name or "Player", 0, 0, 0, scale or 1, color or Blip.Orange, sprite or Blip.Standard)
		b:attachTo(self)
		return b
	end

	--[[function obj:chatMsg(msg)
		sendMessage(self.id, msg)
	end]]

	function obj:createBlip(name, x, y, z, scale, color, sprite)
		return Blip:new(createBlipP(self.id, name, x, y, z, scale or 1, color or Blip.Yellow, sprite or Blip.Standard), true)
	end

	function obj:createMarker(x, y, z, h, r, blip)
		local m = Marker:new(createMarkerP(self.id, x, y, z, h or 1, r or 1), x, y, z, h or 1, r or 1)
		if type(blip) == 'nil' or blip then
			m.blip = self:createBlip("Marker", x, y, z)
		end
		return m
	end

	function obj:distanceTo(x, y, z)
		if z then
			local x1, y1, z1 = self:getPosition()
			return World:GetDistance(x1, y1, z1, x, y, z)
		else
			local x1, y1 = self:getPosition()
			return World:GetDistance(x1, y1, x, y)
		end
	end

	function obj:getHeading()
		return getHeading(self.id)
	end

	function obj:getID()
		return self.id
	end

	function obj:getModel()
		return getModel(self.id)
	end

	function obj:getName()
		return getName(self.id)
	end

	function obj:getWorld()
		return getWorld(self.id)
	end

	function obj:getPosition()
		self.x, self.y, self.z = getCoords(self.id)
		return self.x, self.y, self.z
	end

	function obj:giveWeapon(weapon, ammo)
		return giveWeapon(self.id, weapon, ammo or 100)
	end

	function obj:isInMarker(m)
		local x1, y1, z1 = self:getPosition()
		local x2, y2, z2 = m:getPosition()
		return (World:GetDistance(x1, y1, x2, y2) < 0.5) and (z1 - z2)*(z1 - z2) < 0.5*0.5
	end

	function obj:kick(reason)
		if reason ~= nil then
			kick(self.id, reason)
		end
		kick(self.id)
	end

	function obj:removeWeapons()
		removeWeapons(self.id)
	end

	function obj:on(event, cb)
		if not self.__ehandlers[event] then
			self.__ehandlers[event] = {}
		end
		local e = Event:new(cb)
		table.insert(self.__ehandlers[event], e)
		return e
	end

	function obj:sendNotification(msg)
		sendNotif(self.id, msg)
	end

	function obj:setArmour(armour)
		setArmour(self.id, armour)
	end

	function obj:setHeading(heading)
		setHeading(self.id, heading)
	end

	function obj:setHealth(health)
		setHealth(self.id, health)
	end

	function obj:setInfoMsg(msg)
		if msg then
			setInfoMsg(self.id, msg)
		else
			setInfoMsg(self.id, false)
		end
	end
	
	function obj:setIntoVeh(veh, seat)
		setIntoVeh(self.id, veh.id, seat or -1)
	end

	function obj:setModel(model)
		setModel(self.id, model)
	end

	function obj:setName(name)
		setName(self.id, name)
	end

	function obj:setPosition(x, y, z)
		setCoords(self.id, x, y, z)
	end

	function obj:setWorld(world)
		return setWorld(self.id, world)
	end

	function obj:trigger(event, ...)
		local events = ehandlers[event]
		if events then
			for k, e in pairs(events) do
				e:cb(self, ...)
			end
		end

		local ecbs = self.__ehandlers[event]
		if ecbs then
			for k, e in pairs(ecbs) do
				e:cb(...)
			end
		end

		if ecbs and #ecbs > 0 or events and #events > 0 then return false end
		return true
	end

	function obj:triggerClient(event, ...)
		clientEv(event, self.id, ...)
	end

	local mt = {
		__index = function(t, k)
			if k == 'name' then return t:getName()
			elseif k == 'model' then return t:getModel()
			elseif k == 'pos' then
				local x, y, z = t:getPosition()
				return { x = x,  y = y, z = z }
			elseif t.__meta[k] then return t.__meta[k] end
		end,
		__newindex = function(t, k, v)
			if k == 'health' then t:setHealth(v)
			elseif k == 'armour' then t:setArmour(v)
			elseif k == 'model' then t:setModel(v)
			else t.__meta[k] = v end
		end
	}

	for k, v in pairs(extf) do
		obj[k] = v
	end

	setmetatable(obj, mt)
	return obj
end

function Player:All()
	return pool
end

function Player:Exists(id)
	--return __orange__.PlayerExists(id)
	return true
end

function Player:Extend(f)
	for k, v in pairs(f) do
		extf[k] = v
	end
end

function Player:DeleteByID(id)
	pool[id] = nil
end

function Player:GetByID(id)
	if type(id) ~= "number" or not Player:Exists(id) then return -1 end
	if not pool[id] then
		pool[id] = Player:new(id)
	end
	return pool[id]
end

function Player:GetByName(name)
	if type(name) ~= "string" then return -1 end
	name = name:lower()
	for k, pl in pairs(pool) do
		if pl:getName():lower() == name then return pl end
	end
	return -1
end

function Player:On(event, cb)
	if not ehandlers[event] then
		ehandlers[event] = {}
	end
	local e = Event:new(cb)
	table.insert(ehandlers[event], e)
	return e
end

function Player:Trigger(event, ...)
	local res = true
	for k, player in pairs(Player.__pool) do
		if not player:trigger(event, ...) then res = false end
	end
	return res
end

function Player:TriggerClient(event, ...)
	clientEv(event, -1, ...)
end