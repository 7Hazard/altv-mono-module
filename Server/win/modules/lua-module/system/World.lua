World = {}

function World:GetDistance(x1, y1, z1, x2, y2, z2)
	if not y2 then
		return math.sqrt((z1-x1)^2+(x2-y1)^2)
	else
		return math.sqrt((x2-x1)^2+(y2-y1)^2+(z2-z1)^2)
	end
end