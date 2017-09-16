--[[

Client Script Loader by jubjub!
Steam - http://steamcommunity.com/id/jubjub727/

Description: Hacky lua resource for adding client scripts from other languages. This is a system file thing.

]]--

Server:On("register-client-script", function(name)
    AddClientScript("..\\"..name)
end )

