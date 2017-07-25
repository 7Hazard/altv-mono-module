print('HOOOORAAA')

Server:On('TestEvent', function(p)
    print('TRIGGERED')
end)

--Server:Trigger("sharpEvent");