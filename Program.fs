// Learn more about F# at http://fsharp.org

open System
open System.Linq;

    type Classes = Elf=0| Human =1|Orc=2|Beast=3|Troll=4|Undead=5|Dragon=6|Goblin=7|Elemental=8|God=9|Dwarf=10|Ogre=11|Naga=12|Demon=13|Aqir=14
    type Traits= Mage=0|Warrior=1|Druid=2|DemonHunter=3|Wizard=4|Shaman=5|Warlock=6|Hunter=7|Assassin=8|Mech=9|Knight=10|Priest=11


    let classRules = dict[
        Classes.Elf, (fun (combo:(string * Classes list * Traits list *int)list)-> 
            (combo|>Seq.filter (fun (name, classes, traits, cost) -> Seq.contains Classes.Elf classes)|> Seq.length)>=3);
        Classes.Human, (fun (combo:(string * Classes list * Traits list *int)list)-> 
            (combo|>Seq.filter (fun (name, classes, traits, cost) -> Seq.contains Classes.Human classes)|> Seq.length)>=3);
        Classes.Orc, (fun (combo:(string * Classes list * Traits list *int)list)-> 
            (combo|>Seq.filter (fun (name, classes, traits, cost) -> Seq.contains Classes.Orc classes)|> Seq.length)>=2);
        Classes.Beast, (fun (combo:(string * Classes list * Traits list *int)list)-> 
            (combo|>Seq.filter (fun (name, classes, traits, cost) -> Seq.contains Classes.Beast classes)|> Seq.length)>=2);
        Classes.Troll, (fun (combo:(string * Classes list * Traits list *int)list)-> 
            (combo|>Seq.filter (fun (name, classes, traits, cost) -> Seq.contains Classes.Troll classes)|> Seq.length)>=2);
        Classes.Undead, (fun (combo:(string * Classes list * Traits list *int)list)-> 
            (combo|>Seq.filter (fun (name, classes, traits, cost) -> Seq.contains Classes.Undead classes)|> Seq.length)>=2);
        Classes.Dragon, (fun (combo:(string * Classes list * Traits list *int)list)-> 
            (combo|>Seq.filter (fun (name, classes, traits, cost) -> Seq.contains Classes.Dragon classes)|> Seq.length)>=3);
        Classes.Goblin, (fun (combo:(string * Classes list * Traits list *int)list)-> 
            (combo|>Seq.filter (fun (name, classes, traits, cost) -> Seq.contains Classes.Goblin classes)|> Seq.length)>=3);
        Classes.Elemental, (fun (combo:(string * Classes list * Traits list *int)list)-> 
            (combo|>Seq.filter (fun (name, classes, traits, cost) -> Seq.contains Classes.Elemental classes)|> Seq.length)>=2);
        Classes.God, (fun (combo:(string * Classes list * Traits list *int)list)-> 
            (combo|>Seq.filter (fun (name, classes, traits, cost) -> Seq.contains Classes.God classes)|> Seq.length)>=2);
        Classes.Dwarf, (fun (combo:(string * Classes list * Traits list *int)list)-> 
            (combo|>Seq.filter (fun (name, classes, traits, cost) -> Seq.contains Classes.Dwarf classes)|> Seq.length)>=1);
        Classes.Ogre, (fun (combo:(string * Classes list * Traits list *int)list)-> 
            (combo|>Seq.filter (fun (name, classes, traits, cost) -> Seq.contains Classes.Ogre classes)|> Seq.length)>=2);
        Classes.Naga, (fun (combo:(string * Classes list * Traits list *int)list)-> 
            (combo|>Seq.filter (fun (name, classes, traits, cost) -> Seq.contains Classes.Naga classes)|> Seq.length)>=2);

        Classes.Demon, (fun (combo:(string * Classes list * Traits list *int)list)-> 
            let demoncount=(combo|>Seq.filter (fun (name, classes, traits, cost) -> Seq.contains Classes.Demon classes)|> Seq.length)
            let demonhuntercount=(combo|>Seq.filter (fun (name, classes, traits, cost) -> Seq.contains Traits.DemonHunter traits)|> Seq.length)
            demoncount=1 || (demoncount>=1 && demonhuntercount>=2)
        );        
        
        Classes.Aqir, (fun (combo:(string * Classes list * Traits list *int)list)-> 
            (combo|>Seq.filter (fun (name, classes, traits, cost) -> Seq.contains Classes.Aqir classes)|> Seq.length)>=2);
    ]

    let traitRules= dict[
        Traits.Assassin, (fun (combo:(string * Classes list * Traits list *int)list)-> 
            (combo|>Seq.filter (fun (name, classes, traits, cost) -> Seq.contains Traits.Assassin traits)|> Seq.length)>=3);
        Traits.DemonHunter, (fun (combo:(string * Classes list * Traits list *int)list)-> 
            (combo|>Seq.filter (fun (name, classes, traits, cost) -> Seq.contains Traits.DemonHunter traits)|> Seq.length)>=1);
        Traits.Druid, (fun (combo:(string * Classes list * Traits list *int)list)-> 
            (combo|>Seq.filter (fun (name, classes, traits, cost) -> Seq.contains Traits.Druid traits)|> Seq.length)>=2);
        Traits.Hunter, (fun (combo:(string * Classes list * Traits list *int)list)-> 
            (combo|>Seq.filter (fun (name, classes, traits, cost) -> Seq.contains Traits.Hunter traits)|> Seq.length)>=3);
        Traits.Knight, (fun (combo:(string * Classes list * Traits list *int)list)-> 
            (combo|>Seq.filter (fun (name, classes, traits, cost) -> Seq.contains Traits.Knight traits)|> Seq.length)>=2);
        Traits.Mage, (fun (combo:(string * Classes list * Traits list *int)list)-> 
            (combo|>Seq.filter (fun (name, classes, traits, cost) -> Seq.contains Traits.Mage traits)|> Seq.length)>=3);
        Traits.Mech, (fun (combo:(string * Classes list * Traits list *int)list)-> 
            (combo|>Seq.filter (fun (name, classes, traits, cost) -> Seq.contains Traits.Mech traits)|> Seq.length)>=3);
        Traits.Priest, (fun (combo:(string * Classes list * Traits list *int)list)-> 
            (combo|>Seq.filter (fun (name, classes, traits, cost) -> Seq.contains Traits.Priest traits)|> Seq.length)>=1);
        Traits.Shaman, (fun (combo:(string * Classes list * Traits list *int)list)-> 
            (combo|>Seq.filter (fun (name, classes, traits, cost) -> Seq.contains Traits.Shaman traits)|> Seq.length)>=2);
        Traits.Warlock, (fun (combo:(string * Classes list * Traits list *int)list)-> 
            (combo|>Seq.filter (fun (name, classes, traits, cost) -> Seq.contains Traits.Warlock traits)|> Seq.length)>=2);
        Traits.Warrior, (fun (combo:(string * Classes list * Traits list *int)list)-> 
            (combo|>Seq.filter (fun (name, classes, traits, cost) -> Seq.contains Traits.Warrior traits)|> Seq.length)>=3);
        Traits.Wizard, (fun (combo:(string * Classes list * Traits list *int)list)-> 
            (combo|>Seq.filter (fun (name, classes, traits, cost) -> Seq.contains Traits.Wizard traits)|> Seq.length)>=2);

    ]
    

let random=Random()

let shuffle seq =
    let array = seq |> Seq.toArray
    let random = Random()
    for i in 0 .. array.Length - 1 do
        let j = random.Next(i, array.Length)
        let pom = array.[i]
        array.[i] <- array.[j]
        array.[j] <- pom

    array |> Array.toList

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
        ("Chaos Knight",[Classes.Demon],[Traits.Knight],2);

        ("",[],[],3);

    ]

    let generateRandomComposition len=
        let rec getComposition (comp:((string * Classes list * Traits list *int)list)) (itemstopick:((string * Classes list * Traits list*int)list)) =
            if comp.Length >= len
            then comp
            else
                let index=random.Next(itemstopick.Length-(len-comp.Length)+1) 
                getComposition (List.append comp [itemstopick.[index]]) (List.skip (index+1) itemstopick)

        getComposition [] (shuffle units)
        

    for item in [1..100] do
        generateRandomComposition 6
        |> Seq.iter (fun (name, classes, traits, cost) -> printf "%A " name)
        |> printfn "%A"
        
        

    
    Console.ReadKey()
    |>ignore
    0 // return an integer exit code
