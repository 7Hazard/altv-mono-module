Server:Trigger("TestEvent", "THIS IS A TEST", true, 69.346334562394250235);

Server:On('PlayerEvent', function(p)
    print('TEST EVENT CALLED')
end)

Server:On("connect", function(p)
    p:TriggerClient("CONNECTED")
end)

AddClientScript("client.lua");