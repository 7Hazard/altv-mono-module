___open = io.open
___dofile = dofile

function __path()
   local str = debug.getinfo(3, "S").source:sub(2)
   return str:match("(.*/)") or '.'
end

function __split(_str, d)
	local str = _str
	local res = {}
	while true do
        if string.find(str, d) == nil then
        	table.insert(res, str)
   			return res
        else
            local tmp = string.sub(str, 1, string.find(str, d) - 1)
            table.insert(res, tmp)
            str = string.sub(str, string.find(str, d) + 1)
        end
    end
end

function __pack(...)
    return { n = select("#", ...), ... }
end

function __open(name, mode)
    return ___open(__path()..name, mode)
end

function __dofile(name)
    return ___dofile(__path()..name)
end

function AddClientScript(name)
    return __orange__.AddClientScript(__path()..name)
end

string.split = __split
table.pack = pack
io.open = __open
dofile = __dofile