Blip = {}
Blip.__pool = {}

function Blip:new(id, global)
    local obj = {}
        obj.__type__ = "blip"
        obj.id = id
        obj.global = global
        obj.__ehandlers = {}

    function obj:attachTo(dest)
        if type(dest) ~= 'table' then return end
        if dest.__type__ == 'player' then
            __orange__.AttachBlipToPlayer(self.id, dest.id)
        elseif dest.__type__ == 'vehicle' then
            __orange__.AttachBlipToVehicle(self.id, dest.id)
        end
    end

    function obj:delete()
        __orange__.DeleteBlip(self.id)
        Blip.__pool[self.id] = nil
        self = nil
    end

    function obj:distanceTo(x, y, z)
        if z then
            local x1, y1, z1 = self:getPosition()
            return World:GetDistance(x1, y1, z1, x, y, z)
        else
            local x1, y1 = self:getPosition()
            return World:GetDistance(x1, y1, x, y)
        end
    end

    function obj:getID()
        return self.id
    end

    function obj:getPosition()
        return __orange__.GetBlipCoords(self.id)
    end

    function obj:setColor(color)
        __orange__.SetBlipColor(self.id, color)
    end

    function obj:setRoute(route)
        __orange__.SetBlipRoute(self.id, route)
    end

    function obj:setScale(scale)
        __orange__.SetBlipScale(self.id, scale)
    end

    function obj:setSprite(sprite)
        __orange__.SetBlipSprite(self.id, sprite)
    end

    function obj:setShortRange(toggle)
        __orange__.SetBlipShortRange(self.id, toggle)
    end

    setmetatable(obj, self)
    self.__index = self;
    return obj
end

function Blip:Create(name, x, y, z, scale, color, sprite)
    return Blip:new(__orange__.CreateBlipForAll(name, x, y, z, scale or 1, color or Blip.Orange, sprite or Blip.Standard), true)
end

function Blip:GetByID(id)
    return Blip.__pool[id]
end

--Colors 
Blip.White = 0
Blip.Red = 1
Blip.Green = 2
Blip.Blue = 3
Blip.Orange = 17
Blip.Purple = 19
Blip.Grey = 20
Blip.Brown = 21
Blip.Pink = 23
Blip.DarkGreen = 25
Blip.DarkPurple = 27
Blip.DarkBlue = 29
Blip.MichaelBlue = 42
Blip.FranklinGreen = 43
Blip.TrevorOrange = 44
Blip.Yellow = 66

--Sprites
Blip.Standard = 1
Blip.BigBlip = 2
Blip.PoliceOfficer = 3
Blip.PoliceArea = 4
Blip.Square = 5
Blip.Player = 6
Blip.North = 7
Blip.Waypoint = 8
Blip.BigCircle = 9
Blip.BigCircleOutline = 10
Blip.ArrowUpOutlined = 11
Blip.ArrowDownOutlined = 12
Blip.ArrowUp = 13
Blip.ArrowDown = 14
Blip.PoliceHelicopterAnimated = 15
Blip.Jet = 16
Blip.Number1 = 17
Blip.Number2 = 18
Blip.Number3 = 19
Blip.Number4 = 20
Blip.Number5 = 21
Blip.Number6 = 22
Blip.Number7 = 23
Blip.Number8 = 24
Blip.Number9 = 25
Blip.Number10 = 26
Blip.GTAOCrew = 27
Blip.GTAOFriendly = 28
Blip.Lift = 36
Blip.RaceFinish = 38
Blip.Safehouse = 40
Blip.PoliceOfficer2 = 41
Blip.PoliceCarDot = 42
Blip.PoliceHelicopter = 43
Blip.ChatBubble = 47
Blip.Garage2 = 50
Blip.Drugs = 51
Blip.Store = 52
Blip.PoliceCar = 56
Blip.PolicePlayer = 58
Blip.PoliceStation = 60
Blip.Hospital = 61
Blip.Helicopter = 64
Blip.StrangersAndFreaks = 65
Blip.ArmoredTruck = 66
Blip.TowTruck = 68
Blip.Barber = 71
Blip.LosSantosCustoms = 72
Blip.Clothes = 73
Blip.TattooParlor = 75
Blip.Simeon = 76
Blip.Lester = 77
Blip.Michael = 78
Blip.Trevor = 79
Blip.Rampage = 84
Blip.VinewoodTours = 85
Blip.Lamar = 86
Blip.Franklin = 88
Blip.Chinese = 89
Blip.Airport = 90
Blip.Bar = 93
Blip.BaseJump = 94
Blip.CarWash = 100
Blip.ComedyClub = 102
Blip.Dart = 103
Blip.FIB = 106
Blip.DollarSign = 108
Blip.Golf = 109
Blip.AmmuNation = 110
Blip.Exile = 112
Blip.ShootingRange = 119
Blip.Solomon = 120
Blip.StripClub = 121
Blip.Tennis = 122
Blip.Triathlon = 126
Blip.OffRoadRaceFinish = 127
Blip.Key = 134
Blip.MovieTheater = 135
Blip.Music = 136
Blip.Marijuana = 140
Blip.Hunting = 141
Blip.ArmsTraffickingGround = 147
Blip.Nigel = 149
Blip.AssaultRifle = 150
Blip.Bat = 151
Blip.Grenade = 152
Blip.Health = 153
Blip.Knife = 154
Blip.Molotov = 155
Blip.Pistol = 156
Blip.RPG = 157
Blip.Shotgun = 158
Blip.SMG = 159
Blip.Sniper = 160
Blip.SonicWave = 161
Blip.PointOfInterest = 162
Blip.GTAOPassive = 163
Blip.GTAOUsingMenu = 164
Blip.Link = 171
Blip.Minigun = 173
Blip.GrenadeLauncher = 174
Blip.Armor = 175
Blip.Castle = 176
Blip.Camera = 184
Blip.Handcuffs = 188
Blip.Yoga = 197
Blip.Cab = 198
Blip.Number11 = 199
Blip.Number12 = 200
Blip.Number13 = 201
Blip.Number14 = 202
Blip.Number15 = 203
Blip.Number16 = 204
Blip.Shrink = 205
Blip.Epsilon = 206
Blip.PersonalVehicleCar = 225
Blip.PersonalVehicleBike = 226
Blip.Custody = 237
Blip.ArmsTraffickingAir = 251
Blip.Fairground = 266
Blip.PropertyManagement = 267
Blip.Altruist = 269
Blip.Enemy = 270
Blip.Chop = 273
Blip.Dead = 274
Blip.Hooker = 279
Blip.Friend = 280
Blip.BountyHit = 303
Blip.GTAOMission = 304
Blip.GTAOSurvival = 305
Blip.CrateDrop = 306
Blip.PlaneDrop = 307
Blip.Sub = 308
Blip.Race = 309
Blip.Deathmatch = 310
Blip.ArmWrestling = 311
Blip.AmmuNationShootingRange = 313
Blip.RaceAir = 314
Blip.RaceCar = 315
Blip.RaceSea = 316
Blip.GarbageTruck = 318
Blip.SafehouseForSale = 350
Blip.Package = 351
Blip.MartinMadrazo = 352
Blip.EnemyHelicopter = 353
Blip.Boost = 354
Blip.Devin = 355
Blip.Marina = 356
Blip.Garage = 357
Blip.GolfFlag = 358
Blip.Hangar = 359
Blip.Helipad = 360
Blip.JerryCan = 361
Blip.Masks = 362
Blip.HeistSetup = 363
Blip.Incapacitated = 364
Blip.PickupSpawn = 365
Blip.BoilerSuit = 366
Blip.Completed = 367
Blip.Rockets = 368
Blip.GarageForSale = 369
Blip.HelipadForSale = 370
Blip.MarinaForSale = 371
Blip.HangarForSale = 372
Blip.Business = 374
Blip.BusinessForSale = 375
Blip.RaceBike = 376
Blip.Parachute = 377
Blip.TeamDeathmatch = 378
Blip.RaceFoot = 379
Blip.VehicleDeathmatch = 380
Blip.Barry = 381
Blip.Dom = 382
Blip.MaryAnn = 383
Blip.Cletus = 384
Blip.Josh = 385
Blip.Minute = 386
Blip.Omega = 387
Blip.Tonya = 388
Blip.Paparazzo = 389
Blip.Crosshair = 390
Blip.Creator = 398
Blip.CreatorDirection = 399
Blip.Abigail = 400
Blip.Blimp = 401
Blip.Repair = 402
Blip.Testosterone = 403
Blip.Dinghy = 404
Blip.Fanatic = 405
Blip.Information = 407
Blip.CaptureBriefcase = 408
Blip.LastTeamStanding = 409
Blip.Boat = 410
Blip.CaptureHouse = 411
Blip.JerryCan2 = 415
Blip.RP = 416
Blip.GTAOPlayerSafehouse = 417
Blip.GTAOPlayerSafehouseDead = 418
Blip.CaptureAmericanFlag = 419
Blip.CaptureFlag = 420
Blip.Tank = 421
Blip.HelicopterAnimated = 422
Blip.Plane = 423
Blip.PlayerNoColor = 425
Blip.GunCar = 426
Blip.Speedboat = 427
Blip.Heist = 428
Blip.Stopwatch = 430
Blip.DollarSignCircled = 431
Blip.Crosshair2 = 432
Blip.DollarSignSquared = 434