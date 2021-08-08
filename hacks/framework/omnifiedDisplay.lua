-- Omnified Display
-- Written By: Matt Weber (https://badecho.com) (https://twitch.tv/omni)
-- Copyright 2021 Bad Echo LLC
-- These functions will mostly be replaced by Vision infrastructure when that is ready.

require("omnified")

function FloorIt(number)
	if number ~= nil then
		return math.floor(number)
	end

	return nil
end

function activateLoggers()	

	if loggersTimer == nil then
		loggersTimer = createTimer(getMainForm())
	end

	loggersTimer.Interval = 400
	loggersTimer.OnTimer = function()


		local playerHealth = readFloat(playerHealthAddress)
		playerHealth = FloorIt(playerHealth)
		local playerMaxHealth = readFloat(playerMaxHealthAddress)        
		playerMaxHealth = FloorIt(playerMaxHealth)
		local enemyHealth = readFloat("lastEnemyHealthValue")

		enemyHealth = FloorIt(enemyHealth)
		
		local deathcounter = assert(io.open("\\\\parsec\\c$\\streamData\\deathcount-synced.txt","w"))		
		
		local playerDeaths = readInteger("playerDeaths")
		
		if playerDeaths ~= nil then
			deathcounter:write("Deaths: ", playerDeaths)
		end
		
		deathcounter:close()	
		
		local lastDamageToPlayer = toInt(readFloat("lastDamageToPlayer"))
		local maxDamageToPlayer = toInt(readFloat("maxDamageToPlayer"))
		local lastDamageByPlayer = toInt(readFloat("lastDamageByPlayer"))
		local maxDamageByPlayer = toInt(readFloat("maxDamageByPlayer"))
		local totalDamageByPlayer = toInt(readFloat("totalDamageByPlayer"))

		lastDamageToPlayer = FloorIt(lastDamageToPlayer)
		maxDamageToPlayer = FloorIt(maxDamageToPlayer)
		lastDamageByPlayer = FloorIt(lastDamageByPlayer)
		maxDamageByPlayer = FloorIt(maxDamageByPlayer)
		totalDamageByPlayer = FloorIt(totalDamageByPlayer)

		local log = assert(io.open("log.txt", "a"))

		local ts = os.time()
		local timestamp = os.date('%H:%M-', ts)

		local logEntryEnemyRoll = "Enemy rolls a"
		local logEntryPlayerData
			= "damage!\nPlayer now has"

		local logApocalypse
			= readInteger("logApocalypse")

		local apocalypseResult
			= readInteger("apocalypseResult")

		local riskOfMurderResult
			= readInteger("riskOfMurderResult")
			
		local fatalisResult
			= readInteger("fatalisResult")
			
		local fatalisResultUpper
			= readInteger("fatalisResultUpper")
			
		local fatalisState
			= readInteger("fatalisState")

		local extraDamageX
			= readFloat("extraDamageX")
			
		local lastVerticalDisplacement
			= readFloat("lastVerticalDisplacement")
			
		if fatalisState == 2 then
			log:write(timestamp, "Miraculously, the player has been cured of Fatalis!\n")
			playSound(findTableFile('fatalisCured.wav'))
			writeInteger("fatalisState", 0)
		end

		if logApocalypse == 1 and apocalypseResult ~= nil
							  and lastDamageToPlayer ~= nil
							  and playerHealth ~= nil
							  and timestamp ~= nil
							  and extraDamageX ~= nil
							  and fatalisResult ~= nil
							  and fatalisResultUpper ~= nil
							  and fatalisState ~= nil
							  then
		
			if fatalisState == 1 and fatalisResult == 0 then
				log:write(timestamp, "The player, afflicted with Fatalis, dies immediately from the enemy attack!\n")

				local randomFatalis = {
					{"wilhelm.wav", 1},
					{"fatalisDeath.wav", 2},
					{"haha.wav", 1}
				}

				local fatalisSound = randomize(randomFatalis)

				playSound(findTableFile(fatalisSound))						
			else
				local apocalypseEnemyRoll =
					string.format("%s%s %i: ", timestamp,
											   logEntryEnemyRoll,
											   apocalypseResult)

				local apocalypseDamagedHealth =
					string.format("%.0f %s %.0f health.\n", lastDamageToPlayer,
															logEntryPlayerData,
															playerHealth)

				if apocalypseResult >= 1 and apocalypseResult <= 4 then
					log:write(apocalypseEnemyRoll,
							  extraDamageX,
							  "x DAMAGE causing ",
							  apocalypseDamagedHealth)
				elseif apocalypseResult == 5 or apocalypseResult == 6 then
					log:write(apocalypseEnemyRoll,
							  "SUDDEN TELEPORTITIS (",
							  lastVerticalDisplacement,
							  ") causing ",
							  apocalypseDamagedHealth)
					if lastVerticalDisplacement > freeFallThreshold then
						playSound(findTableFile('freefallin.wav'))
					end	
				elseif apocalypseResult >= 7 and apocalypseResult <= 9 then
					log:write(apocalypseEnemyRoll,
							  "RISK OF MURDER!\n")

					local riskOfMurderEnemyRoll =
						string.format("%s%s %i: ", timestamp,
												   logEntryEnemyRoll,
												   riskOfMurderResult)

					if riskOfMurderResult <= 3 then
						log:write(riskOfMurderEnemyRoll,
								  "WHEW! Just normal damage causing ",
								  apocalypseDamagedHealth)
						if fatalisResult == fatalisResultUpper then
							log:write(timestamp, "Unfortunately the player has been stricken with Fatalis for the next ten minutes...\n")						
							playSound(findTableFile('fatalisAfflication.wav'))
							writeInteger("fatalisResult",0)
						end								  
					else
						log:write(riskOfMurderEnemyRoll,
								  "HOLY SHIT! Player has been SIXTY NINED causing ",
								  apocalypseDamagedHealth)

								  local randomSixtyNine = {									  
									  {"headshot.wav", 2},
									  {"Holyshit.wav", 2},
									  {"vincentLaugh.wav", 1}
								  }

								  local sixtyNineSound = randomize(randomSixtyNine)

								  playSound(findTableFile(sixtyNineSound))
					end
				else				
						log:write(apocalypseEnemyRoll,
								  "WOW! Player achieves orgasm!\nPlayer is healed fully to ",
								  playerHealth,
								  " health.\n")

								  local randomOrgasm = {
									  {"tuturu.wav", 1},
									  {"Wow.wav", 1}
								  }

								  local orgasmSound = randomize(randomOrgasm)

								  playSound(findTableFile(orgasmSound))
				end

			end

			writeInteger("logApocalypse", 0)				

		end

		local logPlayerCrit = readInteger("logPlayerCrit")

		if logPlayerCrit == 1 and lastDamageByPlayer ~= nil then		

			local playerCritDamageResult = readInteger("playerCritDamageResult")
			local playerCritDamageResultUpper = readInteger("playerCritDamageResultUpper")
			local playerCritDamageResultLower = readInteger("playerCritDamageResultLower")

			if areNotNil(playerCritDamageResult, playerCritDamageResultUpper, playerCritDamageResultLower) then
				log:write(timestamp,
						  "Enemy has been critically hit (",
						  playerCritDamageResult/10.0,
						  "x) for ",
						  lastDamageByPlayer,
						  " damage!\n")
				
				local critSound = nil

				local critDamageRange = playerCritDamageResultUpper - playerCritDamageResultLower

				local critHighDamageMinimum = playerCritDamageResultUpper - (critDamageRange * (1/3))

				if (playerCritDamageResult >= critHighDamageMinimum) then
					critSound = "mudboneCrit.wav"
				else
					local randomLowCrit = {
						{"chocobo.wav", 2},
						{"comboBreaker.wav", 1}
					}

					critSound = randomize(randomLowCrit)
				end

				playSound(findTableFile(critSound))
			end
			
			writeInteger("logPlayerCrit", 0)
		end

		local logKamehameha = readInteger("logKamehameha")
		local gokuDamageX = readFloat("gokuDamageX")

		if logKamehameha == 1 and lastDamageByPlayer ~= nil
							  and timestamp ~= nil then
			log:write(timestamp,
					  "Player has unlocked his inner Goku and performs a devastating KAMEHAMEHAAAAA attack causing ",
					  gokuDamageX,
					  "x extra damage for a total of ",
					  lastDamageByPlayer,
						" damage!\n")
				playSound(findTableFile('kame.wav'))
				writeInteger("logKamehameha", 0)
		end

		log:close()
	end

end

function deactivateLoggers()
  if loggersTimer ~= nil then
	loggersTimer.Enabled = false
	loggersTimer.Destroy()
	loggersTimer = nil
  end

end