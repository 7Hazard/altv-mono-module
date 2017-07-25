<a name='contents'></a>
# Contents [#](#contents 'Go To Here')

- [Blip](#T-SharpOrange-Objects-Blip 'SharpOrange.Objects.Blip')
  - [#ctor(name,position,scale,color,sprite)](#M-SharpOrange-Objects-Blip-#ctor-System-String,SharpOrange-Objects-Vector3,SharpOrange-Objects-RGB,System-Single,System-Int32- 'SharpOrange.Objects.Blip.#ctor(System.String,SharpOrange.Objects.Vector3,SharpOrange.Objects.RGB,System.Single,System.Int32)')
  - [#ctor(name,player,position,color,scale,sprite)](#M-SharpOrange-Objects-Blip-#ctor-System-String,SharpOrange-Objects-Player,SharpOrange-Objects-Vector3,SharpOrange-Objects-RGB,System-Single,System-Int32- 'SharpOrange.Objects.Blip.#ctor(System.String,SharpOrange.Objects.Player,SharpOrange.Objects.Vector3,SharpOrange.Objects.RGB,System.Single,System.Int32)')
  - [Color](#P-SharpOrange-Objects-Blip-Color 'SharpOrange.Objects.Blip.Color')
  - [IsShortRange](#P-SharpOrange-Objects-Blip-IsShortRange 'SharpOrange.Objects.Blip.IsShortRange')
  - [Name](#P-SharpOrange-Objects-Blip-Name 'SharpOrange.Objects.Blip.Name')
  - [Player](#P-SharpOrange-Objects-Blip-Player 'SharpOrange.Objects.Blip.Player')
  - [Route](#P-SharpOrange-Objects-Blip-Route 'SharpOrange.Objects.Blip.Route')
  - [Sprite](#P-SharpOrange-Objects-Blip-Sprite 'SharpOrange.Objects.Blip.Sprite')
  - [Vehicle](#P-SharpOrange-Objects-Blip-Vehicle 'SharpOrange.Objects.Blip.Vehicle')
  - [Dispose()](#M-SharpOrange-Objects-Blip-Dispose 'SharpOrange.Objects.Blip.Dispose')
- [Client](#T-SharpOrange-Client 'SharpOrange.Client')
  - [TriggerEvent(playerid,name,args)](#M-SharpOrange-Client-TriggerEvent-System-Int64,System-String,System-Object[]- 'SharpOrange.Client.TriggerEvent(System.Int64,System.String,System.Object[])')
- [GTAObject](#T-SharpOrange-Objects-GTAObject 'SharpOrange.Objects.GTAObject')
  - [#ctor(model,position,rotation)](#M-SharpOrange-Objects-GTAObject-#ctor-System-String,SharpOrange-Objects-Vector3,SharpOrange-Objects-Vector3- 'SharpOrange.Objects.GTAObject.#ctor(System.String,SharpOrange.Objects.Vector3,SharpOrange.Objects.Vector3)')
  - [ID](#P-SharpOrange-Objects-GTAObject-ID 'SharpOrange.Objects.GTAObject.ID')
  - [Dispose()](#M-SharpOrange-Objects-GTAObject-Dispose 'SharpOrange.Objects.GTAObject.Dispose')
- [HoloText](#T-SharpOrange-Objects-HoloText 'SharpOrange.Objects.HoloText')
  - [#ctor(text,position,color,fontSize)](#M-SharpOrange-Objects-HoloText-#ctor-System-String,SharpOrange-Objects-Vector3,SharpOrange-Objects-RGB,System-Single- 'SharpOrange.Objects.HoloText.#ctor(System.String,SharpOrange.Objects.Vector3,SharpOrange.Objects.RGB,System.Single)')
  - [#ctor(text,player,position,color,outline)](#M-SharpOrange-Objects-HoloText-#ctor-System-String,SharpOrange-Objects-Player,SharpOrange-Objects-Vector3,SharpOrange-Objects-RGB,SharpOrange-Objects-RGB- 'SharpOrange.Objects.HoloText.#ctor(System.String,SharpOrange.Objects.Player,SharpOrange.Objects.Vector3,SharpOrange.Objects.RGB,SharpOrange.Objects.RGB)')
  - [ID](#P-SharpOrange-Objects-HoloText-ID 'SharpOrange.Objects.HoloText.ID')
  - [AttachToPlayer()](#M-SharpOrange-Objects-HoloText-AttachToPlayer-SharpOrange-Objects-Player,SharpOrange-Objects-Vector3- 'SharpOrange.Objects.HoloText.AttachToPlayer(SharpOrange.Objects.Player,SharpOrange.Objects.Vector3)')
  - [AttachToVehicle()](#M-SharpOrange-Objects-HoloText-AttachToVehicle-SharpOrange-Objects-Vehicle,SharpOrange-Objects-Vector3- 'SharpOrange.Objects.HoloText.AttachToVehicle(SharpOrange.Objects.Vehicle,SharpOrange.Objects.Vector3)')
  - [Dispose()](#M-SharpOrange-Objects-HoloText-Dispose 'SharpOrange.Objects.HoloText.Dispose')
- [Marker](#T-SharpOrange-Objects-Marker 'SharpOrange.Objects.Marker')
  - [#ctor(position,height,radius)](#M-SharpOrange-Objects-Marker-#ctor-SharpOrange-Objects-Vector3,System-Single,System-Single- 'SharpOrange.Objects.Marker.#ctor(SharpOrange.Objects.Vector3,System.Single,System.Single)')
  - [#ctor(player,position,height,radius)](#M-SharpOrange-Objects-Marker-#ctor-SharpOrange-Objects-Player,SharpOrange-Objects-Vector3,System-Single,System-Single- 'SharpOrange.Objects.Marker.#ctor(SharpOrange.Objects.Player,SharpOrange.Objects.Vector3,System.Single,System.Single)')
  - [ID](#P-SharpOrange-Objects-Marker-ID 'SharpOrange.Objects.Marker.ID')
  - [Dispose()](#M-SharpOrange-Objects-Marker-Dispose 'SharpOrange.Objects.Marker.Dispose')
- [Pickup](#T-SharpOrange-Objects-Pickup 'SharpOrange.Objects.Pickup')
  - [Create(pickup,position,scale)](#M-SharpOrange-Objects-Pickup-Create-SharpOrange-Objects-PickupHash,SharpOrange-Objects-Vector3,System-Single- 'SharpOrange.Objects.Pickup.Create(SharpOrange.Objects.PickupHash,SharpOrange.Objects.Vector3,System.Single)')
- [PickupHash](#T-SharpOrange-Objects-PickupHash 'SharpOrange.Objects.PickupHash')
- [Player](#T-SharpOrange-Objects-Player 'SharpOrange.Objects.Player')
  - [Armor](#P-SharpOrange-Objects-Player-Armor 'SharpOrange.Objects.Player.Armor')
  - [ClientID](#P-SharpOrange-Objects-Player-ClientID 'SharpOrange.Objects.Player.ClientID')
  - [HasInfoMessage](#P-SharpOrange-Objects-Player-HasInfoMessage 'SharpOrange.Objects.Player.HasInfoMessage')
  - [Health](#P-SharpOrange-Objects-Player-Health 'SharpOrange.Objects.Player.Health')
  - [ID](#P-SharpOrange-Objects-Player-ID 'SharpOrange.Objects.Player.ID')
  - [InfoMessage](#P-SharpOrange-Objects-Player-InfoMessage 'SharpOrange.Objects.Player.InfoMessage')
  - [IsAlive](#P-SharpOrange-Objects-Player-IsAlive 'SharpOrange.Objects.Player.IsAlive')
  - [IsHUDEnabled](#P-SharpOrange-Objects-Player-IsHUDEnabled 'SharpOrange.Objects.Player.IsHUDEnabled')
  - [IsInVehicle](#P-SharpOrange-Objects-Player-IsInVehicle 'SharpOrange.Objects.Player.IsInVehicle')
  - [Model](#P-SharpOrange-Objects-Player-Model 'SharpOrange.Objects.Player.Model')
  - [Money](#P-SharpOrange-Objects-Player-Money 'SharpOrange.Objects.Player.Money')
  - [Name](#P-SharpOrange-Objects-Player-Name 'SharpOrange.Objects.Player.Name')
  - [Position](#P-SharpOrange-Objects-Player-Position 'SharpOrange.Objects.Player.Position')
  - [Rotation](#P-SharpOrange-Objects-Player-Rotation 'SharpOrange.Objects.Player.Rotation')
  - [Vehicle](#P-SharpOrange-Objects-Player-Vehicle 'SharpOrange.Objects.Player.Vehicle')
  - [Dispose()](#M-SharpOrange-Objects-Player-Dispose 'SharpOrange.Objects.Player.Dispose')
  - [GiveAmmo(weapon,ammo)](#M-SharpOrange-Objects-Player-GiveAmmo-SharpOrange-Objects-WeaponHash,System-Int64- 'SharpOrange.Objects.Player.GiveAmmo(SharpOrange.Objects.WeaponHash,System.Int64)')
  - [GiveMoney(money)](#M-SharpOrange-Objects-Player-GiveMoney-System-Int64- 'SharpOrange.Objects.Player.GiveMoney(System.Int64)')
  - [GiveWeapon(weapon,ammo)](#M-SharpOrange-Objects-Player-GiveWeapon-SharpOrange-Objects-WeaponHash,System-Int64- 'SharpOrange.Objects.Player.GiveWeapon(SharpOrange.Objects.WeaponHash,System.Int64)')
  - [Kick()](#M-SharpOrange-Objects-Player-Kick 'SharpOrange.Objects.Player.Kick')
  - [Kick(reason)](#M-SharpOrange-Objects-Player-Kick-System-String- 'SharpOrange.Objects.Player.Kick(System.String)')
  - [PutInVehicle(vehicle,seat)](#M-SharpOrange-Objects-Player-PutInVehicle-SharpOrange-Objects-Vehicle,System-Char- 'SharpOrange.Objects.Player.PutInVehicle(SharpOrange.Objects.Vehicle,System.Char)')
  - [RemoveWeapons()](#M-SharpOrange-Objects-Player-RemoveWeapons 'SharpOrange.Objects.Player.RemoveWeapons')
  - [ResetMoney()](#M-SharpOrange-Objects-Player-ResetMoney 'SharpOrange.Objects.Player.ResetMoney')
  - [SendNotification(message)](#M-SharpOrange-Objects-Player-SendNotification-System-String- 'SharpOrange.Objects.Player.SendNotification(System.String)')
  - [ToggleHUD()](#M-SharpOrange-Objects-Player-ToggleHUD 'SharpOrange.Objects.Player.ToggleHUD')
  - [TriggerEvent(name,args)](#M-SharpOrange-Objects-Player-TriggerEvent-System-String,System-Object[]- 'SharpOrange.Objects.Player.TriggerEvent(System.String,System.Object[])')
- [RGB](#T-SharpOrange-Objects-RGB 'SharpOrange.Objects.RGB')
  - [#ctor(r,g,b)](#M-SharpOrange-Objects-RGB-#ctor-System-Byte,System-Byte,System-Byte- 'SharpOrange.Objects.RGB.#ctor(System.Byte,System.Byte,System.Byte)')
- [Server](#T-SharpOrange-Server 'SharpOrange.Server')
  - [Vehicles](#F-SharpOrange-Server-Vehicles 'SharpOrange.Server.Vehicles')
  - [Blips](#P-SharpOrange-Server-Blips 'SharpOrange.Server.Blips')
  - [GTAObjects](#P-SharpOrange-Server-GTAObjects 'SharpOrange.Server.GTAObjects')
  - [HoloTexts](#P-SharpOrange-Server-HoloTexts 'SharpOrange.Server.HoloTexts')
  - [Markers](#P-SharpOrange-Server-Markers 'SharpOrange.Server.Markers')
  - [Players](#P-SharpOrange-Server-Players 'SharpOrange.Server.Players')
  - [Plugins](#P-SharpOrange-Server-Plugins 'SharpOrange.Server.Plugins')
  - [Resources](#P-SharpOrange-Server-Resources 'SharpOrange.Server.Resources')
  - [Hash(text)](#M-SharpOrange-Server-Hash-System-String- 'SharpOrange.Server.Hash(System.String)')
  - [LoadPlugin(pluginName)](#M-SharpOrange-Server-LoadPlugin-System-String- 'SharpOrange.Server.LoadPlugin(System.String)')
  - [LoadResource(resourceName)](#M-SharpOrange-Server-LoadResource-System-String- 'SharpOrange.Server.LoadResource(System.String)')
  - [Print(text)](#M-SharpOrange-Server-Print-System-String- 'SharpOrange.Server.Print(System.String)')
  - [Shutdown()](#M-SharpOrange-Server-Shutdown 'SharpOrange.Server.Shutdown')
  - [TriggerEvent(name,args)](#M-SharpOrange-Server-TriggerEvent-System-String,System-Object[]- 'SharpOrange.Server.TriggerEvent(System.String,System.Object[])')
- [Vector3](#T-SharpOrange-Objects-Vector3 'SharpOrange.Objects.Vector3')
  - [#ctor(x,y,z)](#M-SharpOrange-Objects-Vector3-#ctor-System-Single,System-Single,System-Single- 'SharpOrange.Objects.Vector3.#ctor(System.Single,System.Single,System.Single)')
- [Vehicle](#T-SharpOrange-Objects-Vehicle 'SharpOrange.Objects.Vehicle')
  - [#ctor(vehicle,position)](#M-SharpOrange-Objects-Vehicle-#ctor-SharpOrange-Objects-VehicleHash,SharpOrange-Objects-Vector3- 'SharpOrange.Objects.Vehicle.#ctor(SharpOrange.Objects.VehicleHash,SharpOrange.Objects.Vector3)')
  - [BulletproofTires](#P-SharpOrange-Objects-Vehicle-BulletproofTires 'SharpOrange.Objects.Vehicle.BulletproofTires')
  - [Driver](#P-SharpOrange-Objects-Vehicle-Driver 'SharpOrange.Objects.Vehicle.Driver')
  - [Health](#P-SharpOrange-Objects-Vehicle-Health 'SharpOrange.Objects.Vehicle.Health')
  - [ID](#P-SharpOrange-Objects-Vehicle-ID 'SharpOrange.Objects.Vehicle.ID')
  - [Lights](#P-SharpOrange-Objects-Vehicle-Lights 'SharpOrange.Objects.Vehicle.Lights')
  - [Locked](#P-SharpOrange-Objects-Vehicle-Locked 'SharpOrange.Objects.Vehicle.Locked')
  - [Model](#P-SharpOrange-Objects-Vehicle-Model 'SharpOrange.Objects.Vehicle.Model')
  - [Passengers](#P-SharpOrange-Objects-Vehicle-Passengers 'SharpOrange.Objects.Vehicle.Passengers')
  - [Plate](#P-SharpOrange-Objects-Vehicle-Plate 'SharpOrange.Objects.Vehicle.Plate')
  - [PlateStyle](#P-SharpOrange-Objects-Vehicle-PlateStyle 'SharpOrange.Objects.Vehicle.PlateStyle')
  - [Position](#P-SharpOrange-Objects-Vehicle-Position 'SharpOrange.Objects.Vehicle.Position')
  - [PrimaryColor](#P-SharpOrange-Objects-Vehicle-PrimaryColor 'SharpOrange.Objects.Vehicle.PrimaryColor')
  - [Rotation](#P-SharpOrange-Objects-Vehicle-Rotation 'SharpOrange.Objects.Vehicle.Rotation')
  - [SecondaryColor](#P-SharpOrange-Objects-Vehicle-SecondaryColor 'SharpOrange.Objects.Vehicle.SecondaryColor')
  - [Sirens](#P-SharpOrange-Objects-Vehicle-Sirens 'SharpOrange.Objects.Vehicle.Sirens')
  - [Dispose()](#M-SharpOrange-Objects-Vehicle-Dispose 'SharpOrange.Objects.Vehicle.Dispose')
- [VehicleHash](#T-SharpOrange-Objects-VehicleHash 'SharpOrange.Objects.VehicleHash')
- [VehicleHealth](#T-SharpOrange-Objects-VehicleHealth 'SharpOrange.Objects.VehicleHealth')
  - [#ctor(body,engine,tank)](#M-SharpOrange-Objects-VehicleHealth-#ctor-System-Single,System-Single,System-Single- 'SharpOrange.Objects.VehicleHealth.#ctor(System.Single,System.Single,System.Single)')
- [WeaponHash](#T-SharpOrange-Objects-WeaponHash 'SharpOrange.Objects.WeaponHash')

<a name='assembly'></a>
# SharpOrange [#](#assembly 'Go To Here') [=](#contents 'Back To Contents')

<a name='T-SharpOrange-Objects-Blip'></a>
## Blip [#](#T-SharpOrange-Objects-Blip 'Go To Here') [=](#contents 'Back To Contents')

##### Namespace

SharpOrange.Objects

<a name='M-SharpOrange-Objects-Blip-#ctor-System-String,SharpOrange-Objects-Vector3,SharpOrange-Objects-RGB,System-Single,System-Int32-'></a>
### #ctor(name,position,scale,color,sprite) `constructor` [#](#M-SharpOrange-Objects-Blip-#ctor-System-String,SharpOrange-Objects-Vector3,SharpOrange-Objects-RGB,System-Single,System-Int32- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Create blip for all player

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| name | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| position | [SharpOrange.Objects.Vector3](#T-SharpOrange-Objects-Vector3 'SharpOrange.Objects.Vector3') |  |
| scale | [SharpOrange.Objects.RGB](#T-SharpOrange-Objects-RGB 'SharpOrange.Objects.RGB') |  |
| color | [System.Single](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Single 'System.Single') |  |
| sprite | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') |  |

<a name='M-SharpOrange-Objects-Blip-#ctor-System-String,SharpOrange-Objects-Player,SharpOrange-Objects-Vector3,SharpOrange-Objects-RGB,System-Single,System-Int32-'></a>
### #ctor(name,player,position,color,scale,sprite) `constructor` [#](#M-SharpOrange-Objects-Blip-#ctor-System-String,SharpOrange-Objects-Player,SharpOrange-Objects-Vector3,SharpOrange-Objects-RGB,System-Single,System-Int32- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Create Blip for specified player

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| name | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| player | [SharpOrange.Objects.Player](#T-SharpOrange-Objects-Player 'SharpOrange.Objects.Player') |  |
| position | [SharpOrange.Objects.Vector3](#T-SharpOrange-Objects-Vector3 'SharpOrange.Objects.Vector3') |  |
| color | [SharpOrange.Objects.RGB](#T-SharpOrange-Objects-RGB 'SharpOrange.Objects.RGB') |  |
| scale | [System.Single](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Single 'System.Single') |  |
| sprite | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') |  |

<a name='P-SharpOrange-Objects-Blip-Color'></a>
### Color `property` [#](#P-SharpOrange-Objects-Blip-Color 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Set color of Blip

<a name='P-SharpOrange-Objects-Blip-IsShortRange'></a>
### IsShortRange `property` [#](#P-SharpOrange-Objects-Blip-IsShortRange 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Set to Short Range Blip

<a name='P-SharpOrange-Objects-Blip-Name'></a>
### Name `property` [#](#P-SharpOrange-Objects-Blip-Name 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Set name of Blip

<a name='P-SharpOrange-Objects-Blip-Player'></a>
### Player `property` [#](#P-SharpOrange-Objects-Blip-Player 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Attach Blip to player

<a name='P-SharpOrange-Objects-Blip-Route'></a>
### Route `property` [#](#P-SharpOrange-Objects-Blip-Route 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Set if Blip is routed

<a name='P-SharpOrange-Objects-Blip-Sprite'></a>
### Sprite `property` [#](#P-SharpOrange-Objects-Blip-Sprite 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Set Blip Sprite

<a name='P-SharpOrange-Objects-Blip-Vehicle'></a>
### Vehicle `property` [#](#P-SharpOrange-Objects-Blip-Vehicle 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Attach Blip to Vehicle

<a name='M-SharpOrange-Objects-Blip-Dispose'></a>
### Dispose() `method` [#](#M-SharpOrange-Objects-Blip-Dispose 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Dispose the Blip

##### Parameters

This method has no parameters.

<a name='T-SharpOrange-Client'></a>
## Client [#](#T-SharpOrange-Client 'Go To Here') [=](#contents 'Back To Contents')

##### Namespace

SharpOrange

<a name='M-SharpOrange-Client-TriggerEvent-System-Int64,System-String,System-Object[]-'></a>
### TriggerEvent(playerid,name,args) `method` [#](#M-SharpOrange-Client-TriggerEvent-System-Int64,System-String,System-Object[]- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Trigger Client event

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| playerid | [System.Int64](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int64 'System.Int64') |  |
| name | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| args | [System.Object[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object[] 'System.Object[]') |  |

<a name='T-SharpOrange-Objects-GTAObject'></a>
## GTAObject [#](#T-SharpOrange-Objects-GTAObject 'Go To Here') [=](#contents 'Back To Contents')

##### Namespace

SharpOrange.Objects

<a name='M-SharpOrange-Objects-GTAObject-#ctor-System-String,SharpOrange-Objects-Vector3,SharpOrange-Objects-Vector3-'></a>
### #ctor(model,position,rotation) `constructor` [#](#M-SharpOrange-Objects-GTAObject-#ctor-System-String,SharpOrange-Objects-Vector3,SharpOrange-Objects-Vector3- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Create GTA Object with object name

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| model | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| position | [SharpOrange.Objects.Vector3](#T-SharpOrange-Objects-Vector3 'SharpOrange.Objects.Vector3') |  |
| rotation | [SharpOrange.Objects.Vector3](#T-SharpOrange-Objects-Vector3 'SharpOrange.Objects.Vector3') |  |

<a name='P-SharpOrange-Objects-GTAObject-ID'></a>
### ID `property` [#](#P-SharpOrange-Objects-GTAObject-ID 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

GUID of object

<a name='M-SharpOrange-Objects-GTAObject-Dispose'></a>
### Dispose() `method` [#](#M-SharpOrange-Objects-GTAObject-Dispose 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Dispose the GTA Object

##### Parameters

This method has no parameters.

<a name='T-SharpOrange-Objects-HoloText'></a>
## HoloText [#](#T-SharpOrange-Objects-HoloText 'Go To Here') [=](#contents 'Back To Contents')

##### Namespace

SharpOrange.Objects

<a name='M-SharpOrange-Objects-HoloText-#ctor-System-String,SharpOrange-Objects-Vector3,SharpOrange-Objects-RGB,System-Single-'></a>
### #ctor(text,position,color,fontSize) `constructor` [#](#M-SharpOrange-Objects-HoloText-#ctor-System-String,SharpOrange-Objects-Vector3,SharpOrange-Objects-RGB,System-Single- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Create Holo Text for all players

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| text | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| position | [SharpOrange.Objects.Vector3](#T-SharpOrange-Objects-Vector3 'SharpOrange.Objects.Vector3') |  |
| color | [SharpOrange.Objects.RGB](#T-SharpOrange-Objects-RGB 'SharpOrange.Objects.RGB') |  |
| fontSize | [System.Single](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Single 'System.Single') |  |

<a name='M-SharpOrange-Objects-HoloText-#ctor-System-String,SharpOrange-Objects-Player,SharpOrange-Objects-Vector3,SharpOrange-Objects-RGB,SharpOrange-Objects-RGB-'></a>
### #ctor(text,player,position,color,outline) `constructor` [#](#M-SharpOrange-Objects-HoloText-#ctor-System-String,SharpOrange-Objects-Player,SharpOrange-Objects-Vector3,SharpOrange-Objects-RGB,SharpOrange-Objects-RGB- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Create Holo Text for specified player

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| text | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| player | [SharpOrange.Objects.Player](#T-SharpOrange-Objects-Player 'SharpOrange.Objects.Player') |  |
| position | [SharpOrange.Objects.Vector3](#T-SharpOrange-Objects-Vector3 'SharpOrange.Objects.Vector3') |  |
| color | [SharpOrange.Objects.RGB](#T-SharpOrange-Objects-RGB 'SharpOrange.Objects.RGB') |  |
| outline | [SharpOrange.Objects.RGB](#T-SharpOrange-Objects-RGB 'SharpOrange.Objects.RGB') |  |

<a name='P-SharpOrange-Objects-HoloText-ID'></a>
### ID `property` [#](#P-SharpOrange-Objects-HoloText-ID 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

3D Holo Text Unique ID

<a name='M-SharpOrange-Objects-HoloText-AttachToPlayer-SharpOrange-Objects-Player,SharpOrange-Objects-Vector3-'></a>
### AttachToPlayer() `method` [#](#M-SharpOrange-Objects-HoloText-AttachToPlayer-SharpOrange-Objects-Player,SharpOrange-Objects-Vector3- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Attach Holo Text to Player

##### Parameters

This method has no parameters.

<a name='M-SharpOrange-Objects-HoloText-AttachToVehicle-SharpOrange-Objects-Vehicle,SharpOrange-Objects-Vector3-'></a>
### AttachToVehicle() `method` [#](#M-SharpOrange-Objects-HoloText-AttachToVehicle-SharpOrange-Objects-Vehicle,SharpOrange-Objects-Vector3- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Attach Holo Text to Vehicle

##### Parameters

This method has no parameters.

<a name='M-SharpOrange-Objects-HoloText-Dispose'></a>
### Dispose() `method` [#](#M-SharpOrange-Objects-HoloText-Dispose 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Dispose Holo Text

##### Parameters

This method has no parameters.

<a name='T-SharpOrange-Objects-Marker'></a>
## Marker [#](#T-SharpOrange-Objects-Marker 'Go To Here') [=](#contents 'Back To Contents')

##### Namespace

SharpOrange.Objects

##### Summary

Marker for the normal GTA V Map

<a name='M-SharpOrange-Objects-Marker-#ctor-SharpOrange-Objects-Vector3,System-Single,System-Single-'></a>
### #ctor(position,height,radius) `constructor` [#](#M-SharpOrange-Objects-Marker-#ctor-SharpOrange-Objects-Vector3,System-Single,System-Single- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Create map marker visible for all players

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| position | [SharpOrange.Objects.Vector3](#T-SharpOrange-Objects-Vector3 'SharpOrange.Objects.Vector3') |  |
| height | [System.Single](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Single 'System.Single') |  |
| radius | [System.Single](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Single 'System.Single') |  |

<a name='M-SharpOrange-Objects-Marker-#ctor-SharpOrange-Objects-Player,SharpOrange-Objects-Vector3,System-Single,System-Single-'></a>
### #ctor(player,position,height,radius) `constructor` [#](#M-SharpOrange-Objects-Marker-#ctor-SharpOrange-Objects-Player,SharpOrange-Objects-Vector3,System-Single,System-Single- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Create map marker visible for the specified

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| player | [SharpOrange.Objects.Player](#T-SharpOrange-Objects-Player 'SharpOrange.Objects.Player') |  |
| position | [SharpOrange.Objects.Vector3](#T-SharpOrange-Objects-Vector3 'SharpOrange.Objects.Vector3') |  |
| height | [System.Single](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Single 'System.Single') |  |
| radius | [System.Single](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Single 'System.Single') |  |

<a name='P-SharpOrange-Objects-Marker-ID'></a>
### ID `property` [#](#P-SharpOrange-Objects-Marker-ID 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

The unique ID of the marker

<a name='M-SharpOrange-Objects-Marker-Dispose'></a>
### Dispose() `method` [#](#M-SharpOrange-Objects-Marker-Dispose 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Proper method for disposing the Marker

##### Parameters

This method has no parameters.

<a name='T-SharpOrange-Objects-Pickup'></a>
## Pickup [#](#T-SharpOrange-Objects-Pickup 'Go To Here') [=](#contents 'Back To Contents')

##### Namespace

SharpOrange.Objects

<a name='M-SharpOrange-Objects-Pickup-Create-SharpOrange-Objects-PickupHash,SharpOrange-Objects-Vector3,System-Single-'></a>
### Create(pickup,position,scale) `method` [#](#M-SharpOrange-Objects-Pickup-Create-SharpOrange-Objects-PickupHash,SharpOrange-Objects-Vector3,System-Single- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Create a pickup

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| pickup | [SharpOrange.Objects.PickupHash](#T-SharpOrange-Objects-PickupHash 'SharpOrange.Objects.PickupHash') |  |
| position | [SharpOrange.Objects.Vector3](#T-SharpOrange-Objects-Vector3 'SharpOrange.Objects.Vector3') |  |
| scale | [System.Single](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Single 'System.Single') |  |

<a name='T-SharpOrange-Objects-PickupHash'></a>
## PickupHash [#](#T-SharpOrange-Objects-PickupHash 'Go To Here') [=](#contents 'Back To Contents')

##### Namespace

SharpOrange.Objects

##### Summary

Enum for Pickup Hashes

<a name='T-SharpOrange-Objects-Player'></a>
## Player [#](#T-SharpOrange-Objects-Player 'Go To Here') [=](#contents 'Back To Contents')

##### Namespace

SharpOrange.Objects

<a name='P-SharpOrange-Objects-Player-Armor'></a>
### Armor `property` [#](#P-SharpOrange-Objects-Player-Armor 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Get/Set the player's armor

<a name='P-SharpOrange-Objects-Player-ClientID'></a>
### ClientID `property` [#](#P-SharpOrange-Objects-Player-ClientID 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

The Client GUID

<a name='P-SharpOrange-Objects-Player-HasInfoMessage'></a>
### HasInfoMessage `property` [#](#P-SharpOrange-Objects-Player-HasInfoMessage 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

If player has the info message set

<a name='P-SharpOrange-Objects-Player-Health'></a>
### Health `property` [#](#P-SharpOrange-Objects-Player-Health 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Get/Set the player's health

<a name='P-SharpOrange-Objects-Player-ID'></a>
### ID `property` [#](#P-SharpOrange-Objects-Player-ID 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

The unique ID of the player for it's current session

<a name='P-SharpOrange-Objects-Player-InfoMessage'></a>
### InfoMessage `property` [#](#P-SharpOrange-Objects-Player-InfoMessage 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Set InfoMessage, set to null, string.Empty or "" to Unset

<a name='P-SharpOrange-Objects-Player-IsAlive'></a>
### IsAlive `property` [#](#P-SharpOrange-Objects-Player-IsAlive 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

If player is alive

<a name='P-SharpOrange-Objects-Player-IsHUDEnabled'></a>
### IsHUDEnabled `property` [#](#P-SharpOrange-Objects-Player-IsHUDEnabled 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

If player's HUD is enabled

<a name='P-SharpOrange-Objects-Player-IsInVehicle'></a>
### IsInVehicle `property` [#](#P-SharpOrange-Objects-Player-IsInVehicle 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

If player is in a vehicle

<a name='P-SharpOrange-Objects-Player-Model'></a>
### Model `property` [#](#P-SharpOrange-Objects-Player-Model 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Get/Set the model of the player using the Model name (http://slice.wikidot.com/)

<a name='P-SharpOrange-Objects-Player-Money'></a>
### Money `property` [#](#P-SharpOrange-Objects-Player-Money 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Get/Set money of player (check below for alternative methods)

<a name='P-SharpOrange-Objects-Player-Name'></a>
### Name `property` [#](#P-SharpOrange-Objects-Player-Name 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Get/Set the name of the player

<a name='P-SharpOrange-Objects-Player-Position'></a>
### Position `property` [#](#P-SharpOrange-Objects-Player-Position 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Get/Set position of the player

<a name='P-SharpOrange-Objects-Player-Rotation'></a>
### Rotation `property` [#](#P-SharpOrange-Objects-Player-Rotation 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Get/Set the Z rotation/heading of the player

<a name='P-SharpOrange-Objects-Player-Vehicle'></a>
### Vehicle `property` [#](#P-SharpOrange-Objects-Player-Vehicle 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Get the vehicle of the player

<a name='M-SharpOrange-Objects-Player-Dispose'></a>
### Dispose() `method` [#](#M-SharpOrange-Objects-Player-Dispose 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

USE KICK METHOD AND NOT THIS!

##### Parameters

This method has no parameters.

<a name='M-SharpOrange-Objects-Player-GiveAmmo-SharpOrange-Objects-WeaponHash,System-Int64-'></a>
### GiveAmmo(weapon,ammo) `method` [#](#M-SharpOrange-Objects-Player-GiveAmmo-SharpOrange-Objects-WeaponHash,System-Int64- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Give ammo of a specific weapon to the player

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| weapon | [SharpOrange.Objects.WeaponHash](#T-SharpOrange-Objects-WeaponHash 'SharpOrange.Objects.WeaponHash') |  |
| ammo | [System.Int64](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int64 'System.Int64') |  |

<a name='M-SharpOrange-Objects-Player-GiveMoney-System-Int64-'></a>
### GiveMoney(money) `method` [#](#M-SharpOrange-Objects-Player-GiveMoney-System-Int64- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Add money to what the player currently already has

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| money | [System.Int64](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int64 'System.Int64') |  |

<a name='M-SharpOrange-Objects-Player-GiveWeapon-SharpOrange-Objects-WeaponHash,System-Int64-'></a>
### GiveWeapon(weapon,ammo) `method` [#](#M-SharpOrange-Objects-Player-GiveWeapon-SharpOrange-Objects-WeaponHash,System-Int64- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Give a weapon to the player

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| weapon | [SharpOrange.Objects.WeaponHash](#T-SharpOrange-Objects-WeaponHash 'SharpOrange.Objects.WeaponHash') |  |
| ammo | [System.Int64](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int64 'System.Int64') |  |

<a name='M-SharpOrange-Objects-Player-Kick'></a>
### Kick() `method` [#](#M-SharpOrange-Objects-Player-Kick 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Kick the player

##### Parameters

This method has no parameters.

<a name='M-SharpOrange-Objects-Player-Kick-System-String-'></a>
### Kick(reason) `method` [#](#M-SharpOrange-Objects-Player-Kick-System-String- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Kick the player with a reason

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| reason | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='M-SharpOrange-Objects-Player-PutInVehicle-SharpOrange-Objects-Vehicle,System-Char-'></a>
### PutInVehicle(vehicle,seat) `method` [#](#M-SharpOrange-Objects-Player-PutInVehicle-SharpOrange-Objects-Vehicle,System-Char- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Put player in a vehicle

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| vehicle | [SharpOrange.Objects.Vehicle](#T-SharpOrange-Objects-Vehicle 'SharpOrange.Objects.Vehicle') |  |
| seat | [System.Char](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Char 'System.Char') |  |

<a name='M-SharpOrange-Objects-Player-RemoveWeapons'></a>
### RemoveWeapons() `method` [#](#M-SharpOrange-Objects-Player-RemoveWeapons 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Remove all weapons of the player

##### Parameters

This method has no parameters.

<a name='M-SharpOrange-Objects-Player-ResetMoney'></a>
### ResetMoney() `method` [#](#M-SharpOrange-Objects-Player-ResetMoney 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Totally resets the money of the player

##### Parameters

This method has no parameters.

<a name='M-SharpOrange-Objects-Player-SendNotification-System-String-'></a>
### SendNotification(message) `method` [#](#M-SharpOrange-Objects-Player-SendNotification-System-String- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Send a notification to the player

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| message | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='M-SharpOrange-Objects-Player-ToggleHUD'></a>
### ToggleHUD() `method` [#](#M-SharpOrange-Objects-Player-ToggleHUD 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Toggle the player's HUD

##### Parameters

This method has no parameters.

<a name='M-SharpOrange-Objects-Player-TriggerEvent-System-String,System-Object[]-'></a>
### TriggerEvent(name,args) `method` [#](#M-SharpOrange-Objects-Player-TriggerEvent-System-String,System-Object[]- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Trigger a client event for the player

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| name | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| args | [System.Object[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object[] 'System.Object[]') |  |

<a name='T-SharpOrange-Objects-RGB'></a>
## RGB [#](#T-SharpOrange-Objects-RGB 'Go To Here') [=](#contents 'Back To Contents')

##### Namespace

SharpOrange.Objects

<a name='M-SharpOrange-Objects-RGB-#ctor-System-Byte,System-Byte,System-Byte-'></a>
### #ctor(r,g,b) `constructor` [#](#M-SharpOrange-Objects-RGB-#ctor-System-Byte,System-Byte,System-Byte- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Create an RGB color object

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| r | [System.Byte](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Byte 'System.Byte') |  |
| g | [System.Byte](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Byte 'System.Byte') |  |
| b | [System.Byte](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Byte 'System.Byte') |  |

<a name='T-SharpOrange-Server'></a>
## Server [#](#T-SharpOrange-Server 'Go To Here') [=](#contents 'Back To Contents')

##### Namespace

SharpOrange

<a name='F-SharpOrange-Server-Vehicles'></a>
### Vehicles `constants` [#](#F-SharpOrange-Server-Vehicles 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Dictionary/Map of Vehicles

<a name='P-SharpOrange-Server-Blips'></a>
### Blips `property` [#](#P-SharpOrange-Server-Blips 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Dictionary of Blips

<a name='P-SharpOrange-Server-GTAObjects'></a>
### GTAObjects `property` [#](#P-SharpOrange-Server-GTAObjects 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Dictionary of holo texts

<a name='P-SharpOrange-Server-HoloTexts'></a>
### HoloTexts `property` [#](#P-SharpOrange-Server-HoloTexts 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Dictionary of holo texts

<a name='P-SharpOrange-Server-Markers'></a>
### Markers `property` [#](#P-SharpOrange-Server-Markers 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Dictionary/Map of markers for the GTA V map

<a name='P-SharpOrange-Server-Players'></a>
### Players `property` [#](#P-SharpOrange-Server-Players 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Dictionary/Map of the currently connected Players

<a name='P-SharpOrange-Server-Plugins'></a>
### Plugins `property` [#](#P-SharpOrange-Server-Plugins 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

List of loaded addons

<a name='P-SharpOrange-Server-Resources'></a>
### Resources `property` [#](#P-SharpOrange-Server-Resources 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

List of loaded resources

<a name='M-SharpOrange-Server-Hash-System-String-'></a>
### Hash(text) `method` [#](#M-SharpOrange-Server-Hash-System-String- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Text (string) to hash (long)

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| text | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='M-SharpOrange-Server-LoadPlugin-System-String-'></a>
### LoadPlugin(pluginName) `method` [#](#M-SharpOrange-Server-LoadPlugin-System-String- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Load a plugin by name

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| pluginName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='M-SharpOrange-Server-LoadResource-System-String-'></a>
### LoadResource(resourceName) `method` [#](#M-SharpOrange-Server-LoadResource-System-String- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Load a resource by name

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| resourceName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='M-SharpOrange-Server-Print-System-String-'></a>
### Print(text) `method` [#](#M-SharpOrange-Server-Print-System-String- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Print a server message

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| text | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='M-SharpOrange-Server-Shutdown'></a>
### Shutdown() `method` [#](#M-SharpOrange-Server-Shutdown 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Shut down the server

##### Parameters

This method has no parameters.

<a name='M-SharpOrange-Server-TriggerEvent-System-String,System-Object[]-'></a>
### TriggerEvent(name,args) `method` [#](#M-SharpOrange-Server-TriggerEvent-System-String,System-Object[]- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Trigger a server event

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| name | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| args | [System.Object[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object[] 'System.Object[]') |  |

<a name='T-SharpOrange-Objects-Vector3'></a>
## Vector3 [#](#T-SharpOrange-Objects-Vector3 'Go To Here') [=](#contents 'Back To Contents')

##### Namespace

SharpOrange.Objects

<a name='M-SharpOrange-Objects-Vector3-#ctor-System-Single,System-Single,System-Single-'></a>
### #ctor(x,y,z) `constructor` [#](#M-SharpOrange-Objects-Vector3-#ctor-System-Single,System-Single,System-Single- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Create a 3 value Vector, primarily used for positions and rotations

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| x | [System.Single](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Single 'System.Single') |  |
| y | [System.Single](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Single 'System.Single') |  |
| z | [System.Single](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Single 'System.Single') |  |

<a name='T-SharpOrange-Objects-Vehicle'></a>
## Vehicle [#](#T-SharpOrange-Objects-Vehicle 'Go To Here') [=](#contents 'Back To Contents')

##### Namespace

SharpOrange.Objects

<a name='M-SharpOrange-Objects-Vehicle-#ctor-SharpOrange-Objects-VehicleHash,SharpOrange-Objects-Vector3-'></a>
### #ctor(vehicle,position) `constructor` [#](#M-SharpOrange-Objects-Vehicle-#ctor-SharpOrange-Objects-VehicleHash,SharpOrange-Objects-Vector3- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Creates a new Vehicle

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| vehicle | [SharpOrange.Objects.VehicleHash](#T-SharpOrange-Objects-VehicleHash 'SharpOrange.Objects.VehicleHash') |  |
| position | [SharpOrange.Objects.Vector3](#T-SharpOrange-Objects-Vector3 'SharpOrange.Objects.Vector3') |  |

<a name='P-SharpOrange-Objects-Vehicle-BulletproofTires'></a>
### BulletproofTires `property` [#](#P-SharpOrange-Objects-Vehicle-BulletproofTires 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Get/Set bulletproof tires to vehicle

<a name='P-SharpOrange-Objects-Vehicle-Driver'></a>
### Driver `property` [#](#P-SharpOrange-Objects-Vehicle-Driver 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Get/Set the vehicle driver

<a name='P-SharpOrange-Objects-Vehicle-Health'></a>
### Health `property` [#](#P-SharpOrange-Objects-Vehicle-Health 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Get/Set health of vehicle

<a name='P-SharpOrange-Objects-Vehicle-ID'></a>
### ID `property` [#](#P-SharpOrange-Objects-Vehicle-ID 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Vehicle ID used for unmanaged usage

<a name='P-SharpOrange-Objects-Vehicle-Lights'></a>
### Lights `property` [#](#P-SharpOrange-Objects-Vehicle-Lights 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Get/Set vehicle lights state

<a name='P-SharpOrange-Objects-Vehicle-Locked'></a>
### Locked `property` [#](#P-SharpOrange-Objects-Vehicle-Locked 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Get/Set lock state of vehicle

<a name='P-SharpOrange-Objects-Vehicle-Model'></a>
### Model `property` [#](#P-SharpOrange-Objects-Vehicle-Model 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Model of the vehicle

<a name='P-SharpOrange-Objects-Vehicle-Passengers'></a>
### Passengers `property` [#](#P-SharpOrange-Objects-Vehicle-Passengers 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Returns passengers in a List of Players

<a name='P-SharpOrange-Objects-Vehicle-Plate'></a>
### Plate `property` [#](#P-SharpOrange-Objects-Vehicle-Plate 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Get/Set license/number plate content of vehicle

<a name='P-SharpOrange-Objects-Vehicle-PlateStyle'></a>
### PlateStyle `property` [#](#P-SharpOrange-Objects-Vehicle-PlateStyle 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Get/Set license/number plate style of vehicle

<a name='P-SharpOrange-Objects-Vehicle-Position'></a>
### Position `property` [#](#P-SharpOrange-Objects-Vehicle-Position 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Get/Set Vehicle position

<a name='P-SharpOrange-Objects-Vehicle-PrimaryColor'></a>
### PrimaryColor `property` [#](#P-SharpOrange-Objects-Vehicle-PrimaryColor 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Get/Set primary color of vehicle

<a name='P-SharpOrange-Objects-Vehicle-Rotation'></a>
### Rotation `property` [#](#P-SharpOrange-Objects-Vehicle-Rotation 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Set Pitch, Yaw and Roll

<a name='P-SharpOrange-Objects-Vehicle-SecondaryColor'></a>
### SecondaryColor `property` [#](#P-SharpOrange-Objects-Vehicle-SecondaryColor 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Get/Set secondary color of vehicle

<a name='P-SharpOrange-Objects-Vehicle-Sirens'></a>
### Sirens `property` [#](#P-SharpOrange-Objects-Vehicle-Sirens 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Get/Set siren state On/Off (True/False)

<a name='M-SharpOrange-Objects-Vehicle-Dispose'></a>
### Dispose() `method` [#](#M-SharpOrange-Objects-Vehicle-Dispose 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Proper vehicle disposition, prevents garbage collector to wrongfully dispose it

##### Parameters

This method has no parameters.

<a name='T-SharpOrange-Objects-VehicleHash'></a>
## VehicleHash [#](#T-SharpOrange-Objects-VehicleHash 'Go To Here') [=](#contents 'Back To Contents')

##### Namespace

SharpOrange.Objects

##### Summary

Enum for Vehicle hashes

<a name='T-SharpOrange-Objects-VehicleHealth'></a>
## VehicleHealth [#](#T-SharpOrange-Objects-VehicleHealth 'Go To Here') [=](#contents 'Back To Contents')

##### Namespace

SharpOrange.Objects

<a name='M-SharpOrange-Objects-VehicleHealth-#ctor-System-Single,System-Single,System-Single-'></a>
### #ctor(body,engine,tank) `constructor` [#](#M-SharpOrange-Objects-VehicleHealth-#ctor-System-Single,System-Single,System-Single- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Create a VehicleHealth info object

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| body | [System.Single](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Single 'System.Single') |  |
| engine | [System.Single](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Single 'System.Single') |  |
| tank | [System.Single](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Single 'System.Single') |  |

<a name='T-SharpOrange-Objects-WeaponHash'></a>
## WeaponHash [#](#T-SharpOrange-Objects-WeaponHash 'Go To Here') [=](#contents 'Back To Contents')

##### Namespace

SharpOrange.Objects

##### Summary

Enum for Weapon hashes
