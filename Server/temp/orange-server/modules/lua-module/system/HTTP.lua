HTTP = {}
HTTP.__handlers = {GET = {}, POST = {}}

function HTTP:Bind(method, url, f)
    if not f then
        HTTP.__handlers["GET"][method] = url
    else
        HTTP.__handlers[method][url] = f
    end
end

function HTTP.OnRequest(method, url, query, body)
    print('method', method, url, query, body)
    if HTTP.__handlers[method][url] then
        local _query = {}
        local _tmp = __split(query, '&')
        for k, v in pairs(_tmp) do
            local tmp = __split(v, '=')
            _query[tmp[1]] = tmp[2]
        end

        local _body = {}
        _tmp = __split(body, '&')
        for k, v in pairs(_tmp) do
            local tmp = __split(v, '=')
            _body[tmp[1]] = tmp[2]
        end
        local res, ret = pcall(HTTP.__handlers[method][url], _query, _body)
        if res then return ret else return "" end
    end
    return nil
end