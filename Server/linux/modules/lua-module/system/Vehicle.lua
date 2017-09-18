Vehicle = {}

local ehandlers = {}
local pool = {}

Vehicle.__pool = pool

function Vehicle:new(id)
    local obj = {}
        obj.__type__ = "vehicle"
        obj.__ehandlers = {}
        obj.id = id
        obj.texts = {}
        obj.__meta = {}

    function obj:attachBlip(name, scale, color, sprite)
        local b =  Blip:Create(name or "Vehicle", 0, 0, 0, scale or 0.6, color or Blip.Orange, sprite or Blip.PersonalVehicleCar)
        b:attachTo(self)
        return b
    end

    function obj:attachText(text, x, y, z, tcolor, ocolor, size)
        local text = Text:new(__orange__.Create3DText(text, 0, 0, 72, tcolor or 0xFFFFFFFF, ocolor or 0xFFFFFFFF, size or 20))
        __orange__.Attach3DTextToVeh(text.id, self.id, x or 0, y or 0, z or 0)
        table.insert(self.texts, text)
    end

    function obj:distanceTo(x, y, z)
        if z then
            local x1, y1, z1 = self:getPosition()
            return GetDistance(x1, y1, z1, x, y, z)
        else
            local x1, y1 = self:getPosition()
            return GetDistance(x1, y1, x, y)
        end
    end

    function obj:delete()
        __orange__.DeleteVehicle(self.id)
    end

    function obj:getColours()
        return __orange__.GetVehicleColours(self.id)
    end

    function obj:getCustomColours()
        return __orange__.GetVehicleCustomColours(self.id)
    end

    function obj:getID()
        return self.id
    end

    function obj:getPosition()
        return __orange__.GetVehicleCoords(self.id)
    end

    function obj:getPrimaryColour()
        return __orange__.GetVehiclePrimaryColour(self.id)
    end

    function obj:getRotation()
        return __orange__.GetVehicleRotation(self.id)
    end

    function obj:getSecondaryColour()
        return __orange__.GetVehicleSecondaryColour(self.id)
    end

    function obj:hasBulletproofTyres()
        return __orange__.GetVehicleTyresBulletproof(self.id)
    end

    function obj:hasCustomColors()
        return __orange__.HasVehicleCustomColours(self.id)
    end

    function obj:is(veh)
        if veh and veh.__type__ and veh.__type__ == "vehicle" then  
            return self.id == veh.id
        else
            return false
        end
    end

    function obj:on(event, cb)
        if not self.__ehandlers[event] then
            self.__ehandlers[event] = {}
        end
        local e = Event:new(cb)
        table.insert(self.__ehandlers[event], e)
        return e
    end

    function obj:setColours(primary, secondary)
        __orange__.SetVehicleColours(self.id, primary, secondary)
    end

    function obj:setCustomColours(primaryR, primaryG, primaryB, secondaryR, secondaryG, secondaryB)
        __orange__.SetVehicleCustomColours(self.id, primaryR, primaryG, primaryB, secondaryR, secondaryG, secondaryB)
    end

    function obj:setPosition(x, y, z)
        __orange__.SetVehicleCoords(self.id, x, y, z)
    end

    function obj:setPrimaryColour(color)
        __orange__.SetVehiclePrimaryColour(self.id, color)
    end

    function obj:setRotation(x, y, z)
        __orange__.SetVehicleRotation(self.id, x, y, z)
    end

    function obj:setSecondaryColour(color)
        __orange__.SetVehicleSecondaryColour(self.id, color)
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
    end

    local mt = {
        __index = function(t, k)
            if k =='model' then return t:getModel() end
            if k =='pos' then
                local x, y, z = t:getPosition()
                return { x = x,  y = y, z = z } end
            if t.__meta[k] then return t.__meta[k] end
        end,
        __newindex = function(t, k, v)
            t.__meta[k] = v
        end
    }

    setmetatable(obj, mt)
    pool[id] = obj
    return obj
end

function Vehicle:Create(model, x, y, z, h)
    return Vehicle:new(__orange__.CreateVehicle(model, x, y, z, h))
end

function Vehicle:Exists(id)
    return __orange__.VehicleExists(id)
end

function Vehicle:GetByID(id)
    if type(id) ~= "number" or not Vehicle:Exists(id) then return nil end
    if not pool[id] then
        pool[id] = Vehicle:new(id)
    end
    return pool[id]
end

function Vehicle:On(event, cb)
    if not ehandlers[event] then
        ehandlers[event] = {}
    end
    local e = Event:new(cb)
    table.insert(ehandlers[event], e)
    return e
end

function Vehicle:Trigger(event, ...)
    for k, player in pairs(pool) do
        player:trigger(event, ...)
    end
end