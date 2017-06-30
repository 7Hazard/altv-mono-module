Thread = {}

local __pool = {}
local __current = 0
local __curthread = nil
local __curtime = 0

function Thread:new(f)
    local obj = {}
        obj.__type__ = "thread"
        obj.co = coroutine.create(f)
        obj.wake = 0
        obj.id = __current

        __current = __current + 1

    function obj:stop()
        __pool[self.id] = nil
    end

    setmetatable(obj, self)
    self.__index = self;
    __pool[obj.id] = obj
    return obj
end

function Thread:SetTimeout(f, ms)
    local t = Thread:new(f)
    t.wake = __curtime + math.floor(ms/1000*Server.rate)
    return t
end

function Thread:Wait(ms)
    if ms then __curthread.wake = __curtime + math.floor(ms/1000*Server.rate) end
    coroutine.yield()
end

function Thread:End()
    __pool[__curthread.id] = nil
end

function Thread.Tick()
    for key, thread in pairs(__pool) do
        if __curtime >= thread.wake then
            __curkey = key
            __curthread = thread
            local result, err = coroutine.resume(thread.co)
            
            if err == 0 then
                __pool[key] = nil
            elseif not result then
                print("Error resuming thread: "..err)
                __pool[key] = nil
            end
        end
    end
    __curtime = __curtime + 1
end