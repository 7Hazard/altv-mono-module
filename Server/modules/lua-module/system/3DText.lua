Text = {}
Text.__pool = {}

function Text:new(id)
    local obj = {}
        obj.__type__ = "text"
        obj.id = id
        obj.__ehandlers = {}

    function obj:delete()
        __orange__.Delete3DText(self.id)
        Text.__pool[self.id] = nil
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

    setmetatable(obj, self)
    self.__index = self;
    return obj
end

function Text:Create(text, x, y, z, tcolor, ocolor, size)
    return Text:new(__orange__.Create3DText(text, x, y, z, tcolor or 0xFFFFFFFF, ocolor or 0xFFFFFFFF, size or 20))
end