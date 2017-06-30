Marker = {}
Marker.__pool = {}
Marker.__ehandlers = {}

function Marker:new(id, x, y, z, h, r)
    local obj = {}
        obj.__type__ = "marker"
        obj.id = id
        obj.x = x
        obj.y = y
        obj.z = z
        obj.h = h
        obj.r = r
        obj.__ehandlers = {}
        obj.__players = {}

    function obj:delete()
        if self.blip then self.blip:delete() end
        __orange__.DeleteMarker(self.id)
        for k, v in pairs(self.__ehandlers) do
            for k1, ev in pairs(v) do ev:cancel() end
        end
        Marker.__pool[self.id] = nil
        self = nil
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

    function obj:getID()
        return self.id
    end

    function obj:getPosition()
        return self.x, self.y, self.z
    end

    function obj:on(event, cb)
        if not self.__ehandlers[event] then
            self.__ehandlers[event] = {}
        end
        local e = Event:new(cb)
        table.insert(self.__ehandlers[event], e)
        return e
    end

    function obj:trigger(event, ...)
        local events = Marker.__ehandlers[event]
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
    end

    setmetatable(obj, self)
    self.__index = self
    Marker.__pool[obj.id] = obj
    return obj
end

function Marker:Create(x, y, z, h, r, blip)
    local m = Marker:new(__orange__.CreateMarkerForAll(x, y, z, h or 1, r or 1), x, y, z, h or 1, r or 1)
    if type(blip) == 'nil' or blip then
        m.blip = Blip:Create("Marker", x, y, z)
    end
    return m
end

function Marker:GetByID(id)
    return Marker.__pool[id]
end

function Marker:On(event, cb)
    if not Marker.__ehandlers[event] then
        Marker.__ehandlers[event] = {}
    end
    local e = Event:new(cb)
    table.insert(Marker.__ehandlers[event], e)
    return e
end

function Marker:Trigger(event, ...)
    for k, m in pairs(Marker.__pool) do
        m:trigger(event, ...)
    end
end