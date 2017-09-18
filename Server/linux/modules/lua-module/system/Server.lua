Server = {}
Server.rate = 183
Server.__ehandlers = {}

--[[Thread:new(function()
	local x = os.clock()
	local count = 0
	while true do
		count = count + 1
		if (os.clock() - x) > 1 then
			Server.rate = count
			count = 0
			x = os.clock()
		end
		Thread:Wait(0)
	end
end)]]

function Server:Broadcast(text)
	__orange__.Broadcast(text)
end

function Server:On(event, cb)
    if not Server.__ehandlers[event] then
        Server.__ehandlers[event] = {}
    end
    local e = Event:new(cb)
    table.insert(Server.__ehandlers[event], e)
    return e
end

function Server:Trigger(event, ...)
	return __orange__.ServerTrigger(event, ...)
end

function Server:_Trigger(event, ...)
	local events = Server.__ehandlers[event]
	if events and #events ~= 0 then
	    for k, e in pairs(events) do
        local result = e:cb(...)
        if result == false then
          return false
        end
	    end
	end
  return true
end