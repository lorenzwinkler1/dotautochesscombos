// Learn more about F# at http://fsharp.org

open System

    type Classes = Elf=0| Human =1|Orc=2|Beast=3|Troll=4|Undead=5|Dragon=6|Goblin=7|Elemental=8|God=9|Dwarf=10|Ogre=11|Naga=12|Demon=13|Aqir=14
    type Traits= Mage=0|Warrior=1|Druid=2|DemonHunter=3|Wizard=4|Shaman=5|Warlock=6|Hunter=7|Assassin=8|Mech=9|Knight=10|Priest=11

[<EntryPoint>]
let main argv =

    printfn "Hello World from F#!"
    let units=[
        ("Crystal Maiden", [Classes.Human], [Traits.Mage],1),
        ("Axe",[Classes.Orc],[Traits.Warrior],1),
        ("Enchantress",[Classes.Beast],[Traits.Druid],1),
        ("Tusk",[],[],1),
        ("Anti-mage",[],[],1),
        ("Dark Willow",[],[],1),
        ("Shadow Shaman",[],[],1),
        ("Witch Doctor",[],[],1),
        ("Drow Ranger",[],[],1),
        ("Winter Wyvern",[],[],1),
        ("Bounty Hunter",[],[],1),
        ("Clockwork",[],[],1),
        ("Tinker",[],[],1),
        ("Tiny",[],[],1),
        ("Mars",[],[],1),
        
        ("Beastmaster",[],[],2),
        ("Juggernaut",[],[],2),
        ("Bloodseeker",[],[],2),
        ("Ogre Magi",[],[],2),
        ("Sniper",[],[],2),
        ("Furion",[],[],2),
        ("Mirana",[],[],2),
        ("Batrider",[],[],2),
        ("Abbadon",[],[],2),
        ("Timbersaw",[],[],2),
        ("Morphling",[],[],2),
        ("Oracle",[],[],2),
        ("Slark",[],[],2),
        ("Chaos Knight",[],[],2)
    ]


    0 // return an integer exit code
