local callbacks = {}

function callbacks.EnterVehicle(p0, p1)
	local p = Player:GetByID(p0)
	local veh = Vehicle:GetByID(p1)
	p:trigger('enteredvehicle', veh)
	veh:trigger('playerentered', p)
end

function callbacks.LeftVehicle(p0, p1)
	local p = Player:GetByID(p0)
	local veh = Vehicle:GetByID(p1)
	p:trigger('leftvehicle', veh)
	veh:trigger('playerleft', p)
end

function callbacks.PlayerConnect(p0, p1)
	local pl = Player:GetByID(p0)
	local ip = __split(p1, '|')[1]
	pl.ip = ip
	return pl:trigger("connect", ip)
end

function callbacks.PlayerDisconnect(p0, p1)
	Player:GetByID(p0):trigger("disconnect", p1)
	Player:DeleteByID(p0)
end

function callbacks.PlayerDead(p0, p1, p2)
	Player:GetByID(p0):trigger("death", Player:GetByID(p1), p2)
end

function callbacks.PlayerSpawn(p0, p1, p2, p3)
	Player:GetByID(p0):trigger("spawn", { x = p1, y = p2, z = p3 }) -- deprecated
	Player:GetByID(p0):trigger("respawn")
end

function callbacks.EnterMarker(p0, p1)
	local p = Player:GetByID(p0)
	local m = Marker:GetByID(p1)
	p:trigger('enteredmarker', m)
	m:trigger('playerentered', p)
end	

function callbacks.LeftMarker(p0, p1)
	local p = Player:GetByID(p0)
	local m = Marker:GetByID(p1)
	p:trigger('leftmarker', m)
	m:trigger('playerleft', p)
end

function callbacks.VehicleEnterMarker(p0, p1)
	local v = Vehicle:GetByID(p0)
	local m = Marker:GetByID(p1)
	v:trigger('enteredmarker', m)
	m:trigger('vehicleentered', v)
end	

function callbacks.VehicleLeftMarker(p0, p1)
	local v = Vehicle:GetByID(p0)
	local m = Marker:GetByID(p1)
	v:trigger('leftmarker', m)
	m:trigger('vehicleleft', v)
end

function callbacks.ServerEvent(p0, p1, ...)
	Player:GetByID(p1):trigger(p0, ...)
end

function callbacks.ServerUnload(p0)
	Server:_Trigger("unload", p0)
end

function callbacks.PlayerCommand(id, cmd, params)
	return Player:GetByID(id):trigger('command', cmd, params)
end

function callbacks.PlayerText(id, text)
	return Player:GetByID(id):trigger('text', text)
end

__orange__.OnTick(Thread.Tick)

__orange__.OnEvent(function(ev, ...)
	local cb = callbacks[ev]
	if cb then return cb(...)
	else return Server:_Trigger(ev, ...) end
end)