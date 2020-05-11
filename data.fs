module DotaAutochessCombosData
    type Species = Elf=0| Human =1|Orc=2|Beast=3|Troll=4|Undead=5|Dragon=6|Goblin=7|Elemental=8|God=9|Dwarf=10|Ogre=11|Naga=12|Demon=13|Aqir=14
    type Traits= Mage=0|Warrior=1|Druid=2|DemonHunter=3|Wizard=4|Shaman=5|Warlock=6|Hunter=7|Assassin=8|Mech=9|Knight=10|Priest=11


    let speciesRules = dict[
        Species.Elf, (fun (combo:(string * Species list * Traits list *int)list)-> 
            (combo|>Seq.filter (fun (name, species, traits, cost) -> Seq.contains Species.Elf species)|> Seq.length)>=3);
        Species.Human, (fun (combo:(string * Species list * Traits list *int)list)-> 
            (combo|>Seq.filter (fun (name, species, traits, cost) -> Seq.contains Species.Human species)|> Seq.length)>=3);
        Species.Orc, (fun (combo:(string * Species list * Traits list *int)list)-> 
            (combo|>Seq.filter (fun (name, species, traits, cost) -> Seq.contains Species.Orc species)|> Seq.length)>=2);
        Species.Beast, (fun (combo:(string * Species list * Traits list *int)list)-> 
            (combo|>Seq.filter (fun (name, species, traits, cost) -> Seq.contains Species.Beast species)|> Seq.length)>=2);
        Species.Troll, (fun (combo:(string * Species list * Traits list *int)list)-> 
            (combo|>Seq.filter (fun (name, species, traits, cost) -> Seq.contains Species.Troll species)|> Seq.length)>=2);
        Species.Undead, (fun (combo:(string * Species list * Traits list *int)list)-> 
            (combo|>Seq.filter (fun (name, species, traits, cost) -> Seq.contains Species.Undead species)|> Seq.length)>=2);
        Species.Dragon, (fun (combo:(string * Species list * Traits list *int)list)-> 
            (combo|>Seq.filter (fun (name, species, traits, cost) -> Seq.contains Species.Dragon species)|> Seq.length)>=3);
        Species.Goblin, (fun (combo:(string * Species list * Traits list *int)list)-> 
            (combo|>Seq.filter (fun (name, species, traits, cost) -> Seq.contains Species.Goblin species)|> Seq.length)>=3);
        Species.Elemental, (fun (combo:(string * Species list * Traits list *int)list)-> 
            (combo|>Seq.filter (fun (name, species, traits, cost) -> Seq.contains Species.Elemental species)|> Seq.length)>=2);
        Species.God, (fun (combo:(string * Species list * Traits list *int)list)-> 
            (combo|>Seq.filter (fun (name, species, traits, cost) -> Seq.contains Species.God species)|> Seq.length)>=2);
        Species.Dwarf, (fun (combo:(string * Species list * Traits list *int)list)-> 
            (combo|>Seq.filter (fun (name, species, traits, cost) -> Seq.contains Species.Dwarf species)|> Seq.length)>=1);
        Species.Ogre, (fun (combo:(string * Species list * Traits list *int)list)-> 
            (combo|>Seq.filter (fun (name, species, traits, cost) -> Seq.contains Species.Ogre species)|> Seq.length)>=2);
        Species.Naga, (fun (combo:(string * Species list * Traits list *int)list)-> 
            (combo|>Seq.filter (fun (name, species, traits, cost) -> Seq.contains Species.Naga species)|> Seq.length)>=2);

        Species.Demon, (fun (combo:(string * Species list * Traits list *int)list)-> 
            let demoncount=(combo|>Seq.filter (fun (name, species, traits, cost) -> Seq.contains Species.Demon species)|> Seq.length)
            let demonhuntercount=(combo|>Seq.filter (fun (name, species, traits, cost) -> Seq.contains Traits.DemonHunter traits)|> Seq.length)
            demoncount=1 || (demoncount>=1 && demonhuntercount>=2)
        );        
        
        Species.Aqir, (fun (combo:(string * Species list * Traits list *int)list)-> 
            (combo|>Seq.filter (fun (name, species, traits, cost) -> Seq.contains Species.Aqir species)|> Seq.length)>=2);
    ]

    let traitRules= dict[
        Traits.Assassin, (fun (combo:(string * Species list * Traits list *int)list)-> 
            (combo|>Seq.filter (fun (name, species, traits, cost) -> Seq.contains Traits.Assassin traits)|> Seq.length)>=3);
        Traits.DemonHunter, (fun (combo:(string * Species list * Traits list *int)list)-> 
            (combo|>Seq.filter (fun (name, species, traits, cost) -> Seq.contains Traits.DemonHunter traits)|> Seq.length)>=1);
        Traits.Druid, (fun (combo:(string * Species list * Traits list *int)list)-> 
            (combo|>Seq.filter (fun (name, species, traits, cost) -> Seq.contains Traits.Druid traits)|> Seq.length)>=2);
        Traits.Hunter, (fun (combo:(string * Species list * Traits list *int)list)-> 
            (combo|>Seq.filter (fun (name, species, traits, cost) -> Seq.contains Traits.Hunter traits)|> Seq.length)>=3);
        Traits.Knight, (fun (combo:(string * Species list * Traits list *int)list)-> 
            (combo|>Seq.filter (fun (name, species, traits, cost) -> Seq.contains Traits.Knight traits)|> Seq.length)>=2);
        Traits.Mage, (fun (combo:(string * Species list * Traits list *int)list)-> 
            (combo|>Seq.filter (fun (name, species, traits, cost) -> Seq.contains Traits.Mage traits)|> Seq.length)>=3);
        Traits.Mech, (fun (combo:(string * Species list * Traits list *int)list)-> 
            (combo|>Seq.filter (fun (name, species, traits, cost) -> Seq.contains Traits.Mech traits)|> Seq.length)>=3);
        Traits.Priest, (fun (combo:(string * Species list * Traits list *int)list)-> 
            (combo|>Seq.filter (fun (name, species, traits, cost) -> Seq.contains Traits.Priest traits)|> Seq.length)>=1);
        Traits.Shaman, (fun (combo:(string * Species list * Traits list *int)list)-> 
            (combo|>Seq.filter (fun (name, species, traits, cost) -> Seq.contains Traits.Shaman traits)|> Seq.length)>=2);
        Traits.Warlock, (fun (combo:(string * Species list * Traits list *int)list)-> 
            (combo|>Seq.filter (fun (name, species, traits, cost) -> Seq.contains Traits.Warlock traits)|> Seq.length)>=2);
        Traits.Warrior, (fun (combo:(string * Species list * Traits list *int)list)-> 
            (combo|>Seq.filter (fun (name, species, traits, cost) -> Seq.contains Traits.Warrior traits)|> Seq.length)>=3);
        Traits.Wizard, (fun (combo:(string * Species list * Traits list *int)list)-> 
            (combo|>Seq.filter (fun (name, species, traits, cost) -> Seq.contains Traits.Wizard traits)|> Seq.length)>=2);
    ]

    let units=[
        ("Crystal Maiden", [Species.Human], [Traits.Mage],1);
        ("Axe",[Species.Orc],[Traits.Warrior],1);
        ("Enchantress",[Species.Beast],[Traits.Druid],1);
        ("Tusk",[Species.Beast],[Traits.Warrior],1);
        ("Anti-mage",[Species.Elf],[Traits.DemonHunter],1);
        ("Dark Willow",[Species.Elf],[Traits.Wizard],1);
        ("Shadow Shaman",[Species.Troll],[Traits.Shaman],1);
        ("Witch Doctor",[Species.Troll],[Traits.Warlock],1);
        ("Drow Ranger",[Species.Undead],[Traits.Hunter],1);
        ("Winter Wyvern",[Species.Undead; Species.Dragon],[Traits.Mage],1);
        ("Bounty Hunter",[Species.Goblin],[Traits.Assassin],1);
        ("Clockwork",[Species.Goblin],[Traits.Mech],1);
        ("Tinker",[Species.Goblin],[Traits.Mech],1);
        ("Tiny",[Species.Elemental],[Traits.Warrior],1);
        ("Mars",[Species.God],[Traits.Warrior],1);
        
        ("Beastmaster",[Species.Orc],[Traits.Hunter],2);
        ("Juggernaut",[Species.Orc],[Traits.Warrior],2);
        ("Bloodseeker",[Species.Orc],[Traits.Shaman],2);
        ("Ogre Magi",[Species.Ogre],[Traits.Mage],2);
        ("Sniper",[Species.Dwarf],[Traits.Hunter],2);
        ("Furion",[Species.Elf],[Traits.Druid],2);
        ("Mirana",[Species.Elf],[Traits.Hunter],2);
        ("Batrider",[Species.Troll],[Traits.Knight],2);
        ("Abbadon",[Species.Undead],[Traits.Knight],2);
        ("Timbersaw",[Species.Goblin],[Traits.Mech],2);
        ("Morphling",[Species.Elemental],[Traits.Warrior],2);
        ("Oracle",[Species.God],[Traits.Priest],2);
        ("Slark",[Species.Naga],[Traits.Assassin],2);
        ("Chaos Knight",[Species.Demon],[Traits.Knight],2);

        ("Legion Commander", [Species.Human], [Traits.Knight], 3);
        ("Omniknight", [Species.Human], [Traits.Knight], 3);
        ("Lina", [Species.Human], [Traits.Mage], 3);
        ("Lycan", [Species.Human; Species.Beast], [Traits.Warrior], 3);
        ("Phantom Assasin", [Species.Elf], [Traits.Assassin], 3);
        ("Treant Protector", [Species.Elf], [Traits.Druid], 3);
        ("Dazzle", [Species.Troll], [Traits.Priest], 3);
        ("Pudge", [Species.Undead], [Traits.Warrior], 3);
        ("Visage", [Species.Dragon; Species.Undead], [Traits.Hunter], 3);
        ("Viper", [Species.Dragon], [Traits.Assassin], 3);
        ("Razor", [Species.Elemental], [Traits.Mage], 3);
        ("Rubick", [Species.God], [Traits.Wizard], 3);
        ("Slardar", [Species.Naga], [Traits.Warrior], 3);
        ("Terrorblade", [Species.Demon], [Traits.DemonHunter], 3);
        ("Sand King", [Species.Aqir], [Traits.Assassin], 3);
        ("Venomoancer", [Species.Aqir; Species.Beast], [Traits.Warlock], 3);

        ("Keeper of the Light", [Species.Human], [Traits.Mage], 4);
        ("Dragon Knight", [Species.Human; Species.Dragon], [Traits.Knight], 4);
        ("Chen", [Species.Orc], [Traits.Priest], 4);
        ("Lone Druid", [Species.Beast], [Traits.Druid], 4);
        ("Windranger", [Species.Elf], [Traits.Hunter], 4);
        ("Templar Assassin", [Species.Elf], [Traits.Assassin], 4);
        ("Troll Warlord", [Species.Troll], [Traits.Warrior], 4);
        ("Necrophos", [Species.Undead], [Traits.Warlock], 4);
        ("Alchemist", [Species.Goblin], [Traits.Warlock], 4);
        ("Medusa", [Species.Naga], [Traits.Hunter], 4);
        ("Doom", [Species.Demon], [Traits.Warrior], 4);
        ("Grimstroke", [Species.Demon], [Traits.Wizard], 4);
        ("Nyx Assassin", [Species.Aqir], [Traits.Assassin], 4);
        ("Broodmother", [Species.Aqir], [Traits.Hunter], 4);

        ("", [], [], 4);
        ("", [], [], 3);

    ]