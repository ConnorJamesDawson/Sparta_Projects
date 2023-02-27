# set-ExecutionPolicy -scope process -executionPolicy unrestricted execution policy change
[System.Console]::BackgroundColor = [System.ConsoleColor]::Black

enum Rarity {
    Common
    Uncommon
    Rare
    Elite
}

enum WeaponType {
    Unarmed
    Dagger
    Sword
}

enum Armour {
    None
    Leather
    Metal
}

enum PlayerRaces {
    Human
    Dwarf
    Elf
}

enum Foe {
    
}

class Entitys {
    # Properties of each entity
    [string] $NameOfEntity
    [ValidateRange(0, 40)] [int]  $Level
    [ValidateRange(0, 100)] [int] $HP
    [ValidateRange(0, 10)] [int]  $Atk
    [ValidateRange(0, 10)] [int]  $Dex
    [ValidateRange(0, 10)] [int]  $Str

    [int]    $Alive = $true
    [int]    $ID = (Get-Random) #For database storing purposes
    [int]    $XP
    [int]    $Money
    [string] $ObjectType = 'Entity'
    [System.Collections.ArrayList] $Inventory = @()
    [System.Collections.ArrayList] $Equipped = @()
    [string] $S
    [int]    $XCoord
    [int]    $YCoord
    $Color # Colour on map
    [bool]   $CanAttack = $true
}




function Initialise-Map{ #Initalise/Draw the map 

    param( #Define Map size as well as Objects Array
    $XMapSize = 20,
    $YMapSize = 9,
    $Objects
    )

    Clear-Host
    [console]::Out.Write("'n")

    foreach ($x in 0..$XMapSize) {
        foreach($y in 0..$YMapSize){
            if($x -eq 0 -or $x -eq $XMapSize -or $y -eq 0 -or $y -eq $YMapSize)
            {
                [System.Console]::BackgroundColor = [System.ConsoleColor]::Gray
                [Console]::Out.Write(' ')
                [System.Console]::BackgroundColor = [System.ConsoleColor]::Black
            }
            else{
            
            

            }
        }
    }
}