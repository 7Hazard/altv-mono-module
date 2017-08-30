Chat = {}

local f = {}

function f:chatMsg(msg)
	--print(self.id, msg)
	Chat:SendMessageToPl(self, msg)
end

Player:Extend(f)

function Chat:SendMessage(pl, msg)
	if type(msg) ~= 'string' then
		return
	end

	if type(pl) == 'string' then
		Player:TriggerClient("chat:msg", pl, msg:gsub("[}{\">/<'&]", {
	    ["&"] = "&amp;",
	    ["<"] = "&lt;",
	    [">"] = "&gt;",
	    ['"'] = "&quot;",
	    ["'"] = "&#39;",
	    ["/"] = "&#47;"
	  }))
	elseif type(pl) == 'table' and type(pl.name) == 'string' then
		Player:TriggerClient("chat:msg", pl.name, msg:gsub("[}{\">/<'&]", {
	    ["&"] = "&amp;",
	    ["<"] = "&lt;",
	    [">"] = "&gt;",
	    ['"'] = "&quot;",
	    ["'"] = "&#39;",
	    ["/"] = "&#47;"
	  }))
	else
		Player:TriggerClient("chat:msg", false, msg:gsub("[}{\">/<'&]", {
	    ["&"] = "&amp;",
	    ["<"] = "&lt;",
	    [">"] = "&gt;",
	    ['"'] = "&quot;",
	    ["'"] = "&#39;",
	    ["/"] = "&#47;"
	  }))
	end
end

function Chat:SendMessageToPl(pl, msg)
	if type(msg) ~= 'string' then
		return
	end

	pl:triggerClient("chat:msg", false, msg:gsub("[}{\">/<'&]", {
    ["&"] = "&amp;",
    ["<"] = "&lt;",
    [">"] = "&gt;",
    ['"'] = "&quot;",
    ["'"] = "&#39;",
    ["/"] = "&#47;"
  }))
end

Player:On("chat:msg", function(pl, text)
	--print(pl.name, text)
	if text:sub(1, 1) == "/" then
		local pos = string.find(text, ' ')

		if pos then
			local cmd = text:sub(2, pos - 1)
			local rargs = text:sub(pos + 1)
			local args = __split(rargs, ' ')

			Server:Trigger('PlayerCommand', pl.id, cmd, args)
		else
			Server:Trigger('PlayerCommand', pl.id, text:sub(2), {})
		end
	else
		if text:len() > 0 then
	    local result = Server:Trigger('PlayerText', pl.id, text)
			if result ~= false then
				Player:TriggerClient("chat:msg", pl.name, text:gsub("[}{\">/<'&]", {
		      ["&"] = "&amp;",
		      ["<"] = "&lt;",
		      [">"] = "&gt;",
		      ['"'] = "&quot;",
		      ["'"] = "&#39;",
		      ["/"] = "&#47;"
		  	}))
			end
		end
	end
end)

AddClientScript("chat_client.lua")