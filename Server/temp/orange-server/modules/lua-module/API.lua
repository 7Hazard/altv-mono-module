package.path = package.path..";dependencies/?.lua;deps/?.lua"

local ext = package.cpath:match("%p[\\|/]?%p(%a+)")
package.cpath = string.format("%s;dependencies/?.%s;deps/?.%s;modules/lua-module/bin/?.%s", package.cpath, ext, ext, ext)

--For real random
math.randomseed(os.time())
math.random(); math.random(); math.random()

dofile('modules/lua-module/sys.lua')

dofile("debug.lua")

dofile("system/Color.lua")
dofile("system/Button.lua")

dofile("system/Thread.lua")
dofile("system/MySQL.lua")
dofile("system/Blip.lua")
dofile("system/Event.lua")
dofile("system/World.lua")
dofile("system/Player.lua")
dofile("system/Vehicle.lua")
dofile("system/Object.lua")
dofile("system/Marker.lua")
dofile("system/HTTP.lua")
dofile("system/Server.lua")
dofile("system/3DText.lua")

dofile("callbacks.lua")