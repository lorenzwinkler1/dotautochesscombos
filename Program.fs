// Learn more about F# at http://fsharp.org

open System
open System.Linq;

    type Classes = Elf=0| Human =1|Orc=2|Beast=3|Troll=4|Undead=5|Dragon=6|Goblin=7|Elemental=8|God=9|Dwarf=10|Ogre=11|Naga=12|Demon=13|Aqir=14
    type Traits= Mage=0|Warrior=1|Druid=2|DemonHunter=3|Wizard=4|Shaman=5|Warlock=6|Hunter=7|Assassin=8|Mech=9|Knight=10|Priest=11

[<EntryPoint>]
let main argv =

    printfn "Hello World from F#!"
    let units=[
        ("Crystal Maiden", [Classes.Human], [Traits.Mage],1);
        ("Axe",[Classes.Orc],[Traits.Warrior],1);
        ("Enchantress",[Classes.Beast],[Traits.Druid],1);
        ("Tusk",[Classes.Beast],[Traits.Warrior],1);
        ("Anti-mage",[Classes.Elf],[Traits.DemonHunter],1);
        ("Dark Willow",[Classes.Elf],[Traits.Wizard],1);
        ("Shadow Shaman",[Classes.Troll],[Traits.Shaman],1);
        ("Witch Doctor",[Classes.Troll],[Traits.Warlock],1);
        ("Drow Ranger",[Classes.Undead],[Traits.Hunter],1);
        ("Winter Wyvern",[Classes.Undead; Classes.Dragon],[Traits.Mage],1);
        ("Bounty Hunter",[Classes.Goblin],[Traits.Assassin],1);
        ("Clockwork",[Classes.Goblin],[Traits.Mech],1);
        ("Tinker",[Classes.Goblin],[Traits.Mech],1);
        ("Tiny",[Classes.Elemental],[Traits.Warrior],1);
        ("Mars",[Classes.God],[Traits.Warrior],1);
        
        ("Beastmaster",[Classes.Orc],[Traits.Hunter],2);
        ("Juggernaut",[Classes.Orc],[Traits.Warrior],2);
        ("Bloodseeker",[Classes.Orc],[Traits.Shaman],2);
        ("Ogre Magi",[Classes.Ogre],[Traits.Mage],2);
        ("Sniper",[Classes.Dwarf],[Traits.Hunter],2);
        ("Furion",[Classes.Elf],[Traits.Druid],2);
        ("Mirana",[Classes.Elf],[Traits.Hunter],2);
        ("Batrider",[Classes.Troll],[Traits.Knight],2);
        ("Abbadon",[Classes.Undead],[Traits.Knight],2);
        ("Timbersaw",[Classes.Goblin],[Traits.Mech],2);
        ("Morphling",[Classes.Elemental],[Traits.Warrior],2);
        ("Oracle",[Classes.God],[Traits.Priest],2);
        ("Slark",[Classes.Naga],[Traits.Assassin],2);
        ("Chaos Knight",[Classes.Demon],[Traits.Knight],2)
    ]

    let generateCompositions len=
        let rec getComposition (comp:((string * Classes list * Traits list *int)list)) (itemstopick:((string * Classes list * Traits list*int)list)) =
            if comp.Length >= len
            then [comp]
            else
                itemstopick.AsParallel()
                |>Seq.mapi (fun i item -> item, i )
                |>Seq.filter (fun (_,index)-> index < itemstopick.Length-(len-comp.Length-1))
                |>Seq.collect (fun (item, index)-> getComposition (List.append comp [itemstopick.[index]]) (Seq.toList(Seq.skip (index+1) itemstopick)) )
                |>Seq.toList

        getComposition [] units
        
    let comps = generateCompositions 6
    printfn "%A" comps.Length
    printfn "%A" (Set.ofList(comps).Count)
    

    
    Console.ReadKey()
    |>ignore
    0 // return an integer exit code
