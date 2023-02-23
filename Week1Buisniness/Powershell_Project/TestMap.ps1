
$global:playerCharacter = $null
$global:runGame         = $true

#Clear Console
Clear-Host

function Setup-Display() 
{
    $phost   = get-host
    $pWindow = $phost.ui.rawui
    $newsize = $pWindow.windowsize
    $newsize.height = 55
    $newsize.width  = 110
    $pWindow.windowsize = $newsize
}

function Title-Screen()
{
    Clear-Host
    Write-Host "                                                                                                                   "
    Write-Host "                                                                                                                   " 
    Write-Host "                                             Press Any Key to Play or Q to quit                                    "
    
    $continue = $host.UI.RawUI.ReadKey("NoEcho,IncludeKeyDown") 

    if($continue.Character -eq 'q')
    {
        $global:runGame = $false
    }
}  

function Character-Selection()
{
    [bool] $wait = $true
    do {
        #Clear Console
        Clear-Host

        Write-Host "                     @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@                    "
        Write-Host "                                                                                                              "
        Write-Host "                                           Character Selection                                                "
        Write-Host "                                                                                                              "   
        Write-Host "                                               A: Simon                                                       "
        Write-Host "                                               B: Peter                                                       "
        Write-Host "                                               C: Zanny                                                       "
        Write-Host "                                               D: Amara                                                       "
        Write-Host "                                                                                                              "
        Write-Host "                     @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@                    "
        Write-Host "                                                                                                              "
  
        $userResponse = Read-Host -Prompt "                                         Choose your character"

        Write-Host ""

        Switch ($userResponse) 
        { 
                A {$global:playerCharacter = "Simon"
                   $wait = $false}
                B {$global:playerCharacter = "Peter"
                   $wait = $false} 
                C {$global:playerCharacter = "Zanny"
                   $wait = $false} 
                D {$global:playerCharacter = "Amara"
                   $wait = $false} 
        }
    } until (!$wait)


    Write-Host "                                     You selected $global:playerCharacter, lets begin"

    Sleep 3
}

function Accept-TheQuest()
{
    #Clear Console
    clear-host

    #Dragon Slayer
    Write-Host "##############################################################################################################"
    Write-Host "#                                                                                                            #"
    Write-Host "# The King requests your help to slay the zombie horde in the north provinces.                               #"
    Write-Host "# They seem to have been woken from a deep slumber and has started terrorising the local villages.           #"
    Write-Host "# The people are scared and have started to leave the kingdom.                                               #"
    Write-Host "#                                                                                                            #"
    Write-Host "##############################################################################################################"
    Write-Host "                                                                                                              "
    
    do
    {
        $userResponse = Read-Host -Prompt "The King must protect his people, are you willing to help? (yes/no) "
    }
    while($userResponse -notlike "Yes" -and $userResponse -notlike "No")
    
    Write-Host ""

    Switch ($userResponse) 
    { 
        "Yes" {Write-Host "The King thanks you $global:playerCharacter, now start your quest!"; Sleep 4; return $true}
        "No"  {Write-Host "Your King is dissapointed and sends you on your way"; Sleep 4; return $false} 
    }
}

function Arrive-AtVillage()
{
    Clear-Host

    Write-Host ""
    Write-Host "After two day's ride you arrive at Florin, a small village on the outskirts of the kingdom."
    Write-Host ""
    Write-Host "You choose Florin to make your stand due to its remote location and nearby army detachment "
    Write-Host "camping nearby." 
    Write-Host ""
    Write-Host "On your arrival do you?"
    Write-Host ""
    Write-Host "A) Talk to the villagers"
    Write-Host "B) Talk to the commander in charge of the local detachment"
    Write-Host ""
    
    do
    {
        $userResponse = Read-Host -Prompt "Answer (A or B)"
    }
    while($userResponse -notlike "A" -and $userResponse -notlike "B")
       
    
    Write-Host ""

    Switch ($userResponse) 
    { 
        "A" {Village-Death}
        "B" {Army-Consript} 
    }
}

function Village-Death()
{
    Write-Host ""
    Write-Host "OI! Don't you owe me money!?!"
    Write-Host ""
    Write-Host "A loud bang as something hits your head "
    Write-Host "" 
    Write-Host " ... You are now dead"
    Write-Host ""
    Write-Host "A) Well that was short"
    Write-Host "B) Not again!"
    Write-Host ""
    do
    {
        $userResponse = Read-Host -Prompt "Answer (A or B)"
    }
    while($userResponse -notlike "A" -and $userResponse -notlike "B")
    
    Write-Host ""

    GameOver
}

function Army-Consript()
{

    Write-Host ""
    Write-Host "You walk along the path towards the army camp when all of a sudden..."
    Write-Host ""
    Write-Host " WATCH OUT!!! *THUNCK* "
    Write-Host "" 
    Write-Host " ... A stray crossbow bolt hits youin the head ... You are now dead"
    Write-Host ""
    Write-Host "A) Well that was short"
    Write-Host "B) Not again!"
    Write-Host ""
    do
    {
        $userResponse = Read-Host -Prompt "Answer (A or B)"
    }
    while($userResponse -notlike "A" -and $userResponse -notlike "B")
    
    Write-Host ""
    GameOver
}

function GameOver()
{
    $gameOverText = @'
      _____          __  __ ______    ______      ________ _____  _            
     / ____|   /\   |  \/  |  ____|  / __ \ \    / /  ____|  __ \| |           
    | |  __   /  \  | \  / | |__    | |  | \ \  / /| |__  | |__) | |           
    | | |_ | / /\ \ | |\/| |  __|   | |  | |\ \/ / |  __| |  _  /| |           
    | |__| |/ ____ \| |  | | |____  | |__| | \  /  | |____| | \ \|_|           
     \_____/_/    \_\_|  |_|______|  \____/   \/   |______|_|  \_(_)           
 ________________________________________________________________________ 
|________________________________________________________________________|
'@

    Write-Host $gameOverText -ForegroundColor Red

    Write-Host "                                             Press Any Key to Play Again or Q to quit                                    "
    
    $continue = $host.UI.RawUI.ReadKey("NoEcho,IncludeKeyDown") 

    if($continue.Character -like 'q')
    {
        $global:runGame = $false
    }
}



Setup-Display

while($true)
{
    
    Title-Screen

    if(!$global:runGame)
    {
        break
    }
    
    Character-Selection

    $accept = Accept-TheQuest
    if($accept -eq $true)
    {
        Arrive-AtVillage
    }
    else
    {
        #Player Quit
        Write-Host ""
        Write-Host "Thanks for Playing"
        Sleep 3
    }
}