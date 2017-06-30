Event = {}
Event.__pool = {}
Event.__current = 0

function Event:new(cb)
    local obj = {}
        obj.__type__ = "event"
        obj.__cb = cb
        obj.id = Event.__current

        Event.__current = Event.__current + 1

    function obj:cb(...)
        if self.__cb then
            local r, e = pcall(self.__cb, ...)
            if not r then print("Error calling callback: "..e) end
        end
    end

    function obj:cancel()
        Event.__pool[self.id] = nil
        self.__cb = nil
    end

    setmetatable(obj, self)
    self.__index = self;
    Event.__pool[obj.id] = obj
    return obj
end