print('HOOOORAAA')

Server:On('TestEvent', function(p)
    print('TRIGGERED')
end)

Server:On('CONNECTED', function(p)
    Server:Trigger("SHARPTRIGGER", 69, "Jizz")
end)

--Server:Trigger("sharpEvent");