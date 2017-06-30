Server:Trigger("TestEvent", 69.346334562394250235);

Server:On('PlayerEvent', function(p)
    print('TEST EVENT CALLED')
end)

AddClientScript("client.lua");