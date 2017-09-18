MySQL = {}

local __env = __orange__.SQLEnv()
if not __env then print("error loading mysql")
else __env = __env.mysql() end

function MySQL:new(conn)
	if not conn then print('error connecting to database') end
	local obj = {}
        obj.__conn = conn

    function obj:close()
        if self.__conn then self.__conn:close() end
    end

    function obj:noQuery(query, ...)
		if self.__conn then
			self.__conn:execute(string.format(query, MySQL:Escape(self.__conn, ...)))
		else print("Connection closed") end
	end

	function obj:query(query, ...)
		if self.__conn then
			local _r = self.__conn:execute(string.format(query, MySQL:Escape(self.__conn, ...)))

			if type(_r) == 'userdata' then
				local res = {}

				local row = _r:fetch({}, 'a')
				while row do
					local ent = {} for k, v in pairs(row) do ent[k] = v end
					table.insert(res, ent)
					row = _r:fetch(row, 'a')
				end
				_r:close()

				return res
			elseif type(_r) == 'number' then
				return _r
			else
				print(type(_r))
				return {}
			end
		else print("Connection closed") end
	end

    return obj
end

function MySQL:Connect(host, db, user, pass)
	local _host = string.split(host, ':')
	local _pass
	if not pass then _pass = "" else _pass = pass end

	return MySQL:new(__env:connect(db, user, _pass, _host[1], _host[2]))
end

function MySQL:Escape(conn, ...)
	local res = {}

	for k, v in pairs({ ... }) do
		table.insert(res, conn:escape(v))
	end

	return unpack(res)
end