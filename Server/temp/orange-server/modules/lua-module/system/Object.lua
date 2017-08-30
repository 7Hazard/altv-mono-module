Object = {}
Object.__pool = {}

function Object:new(id, model, x, y, z, pitch, yaw, roll)
    local obj = {}
        obj.__type__ = "object"
        obj.id = id
        obj.__meta = {}
        obj.model = model
        obj.x = x
        obj.y = y
        obj.z = z
        obj.pitch = pitch
        obj.yaw = yaw
        obj.roll = roll

    function obj:getID()
        return self.id
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

    function obj:getModel()
        return self.model
    end

    function obj:getPosition()
        return self.x, self.y, self.z
    end

    function obj:getRotation()
        return self.pitch, self.yaw, self.roll
    end

    function obj:delete()
        __orange__.DeleteObject(self.id)
    end

    function obj:is(object)
        if object and object.__type__ and object.__type__ == "object" then  
            return self.id == object.id
        else
            return false
        end
    end

    local mt = {
        __index = function(t, k)
            if t.__meta[k] then return t.__meta[k] end
        end,
        __newindex = function(t, k, v)
            t.__meta[k] = v
        end
    }

    setmetatable(obj, mt)
    return obj
end

function Object:Create(model, x, y, z, pitch, yaw, roll)
    return Object:new(__orange__.CreateObject(model, x, y, z, pitch, yaw, roll), model, x, y, z, pitch, yaw, roll)
end


function Object:GetByID(id)
    if type(id) ~= "number" then return -1 end
    if not Object.__pool[id] then
        Object.__pool[id] = Object:new(id)
    end
    return Object.__pool[id]
end