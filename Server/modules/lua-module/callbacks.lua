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
	pl:trigger("connect", ip)
end

function callbacks.PlayerDisconnect(p0, p1)
	Player:GetByID(p0):trigger("disconnect", p1)
	Player:DeleteByID(p0)
end

function callbacks.PlayerDead(p0, p1, p2)
	Player:GetByID(p0):trigger("death", Player:GetByID(p1), p2)
end

function callbacks.PlayerSpawn(p0, p1, p2, p3)
	Player:GetByID(p0):trigger("spawn", { x = p1, y = p2, z = p3 })
end

function callbacks.keyPress(p0, p1)
	Player:GetByID(p0):trigger("keypress", p1)
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

function callbacks.VehEnterMarker(p0, p1)
	local v = Vehicle:GetByID(p0)
	local m = Marker:GetByID(p1)
	v:trigger('enteredmarker', m)
	m:trigger('vehicleentered', v)
end	

function callbacks.VehLeftMarker(p0, p1)
	local v = Vehicle:GetByID(p0)
	local m = Marker:GetByID(p1)
	v:trigger('leftmarker', m)
	m:trigger('vehicleleft', v)
end

function callbacks.serverEvent(p0, p1, ...)
	Player:GetByID(p1):trigger(p0, ...)
end

function callbacks.ServerUnload(p0)
	Server:Trigger("unload", p0)
end

__orange__.OnTick(Thread.Tick)

__orange__.OnEvent(function(ev, ...)
	local cb = callbacks[ev]
	if cb then cb(...)
	else Server:_Trigger(ev, ...) end
end)