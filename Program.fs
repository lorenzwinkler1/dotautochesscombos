// Learn more about F# at http://fsharp.org

open System
open System.Linq;
open GeneticSharp.Domain;
open DotaAutochessCombosData;
    
let evaluateSpeciesPerks comp =
        Enum.GetValues(typeof<Species>):?> (Species [])
        |> Seq.filter (fun item -> speciesRules.[item] comp)

let evaluateTraitPerks comp =
        Enum.GetValues(typeof<Traits>):?> (Traits [])
        |> Seq.filter (fun item -> traitRules.[item] (comp))

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

let generateRandomComposition len=
        let rec getComposition (comp:((string * Species list * Traits list *int)list)) (itemstopick:((string * Species list * Traits list*int)list)) =
            if comp.Length >= len
            then comp
            else
                let index=random.Next(itemstopick.Length-(len-comp.Length)+1) 
                getComposition (List.append comp [itemstopick.[index]]) (List.skip (index+1) itemstopick)

        getComposition [] (shuffle units)

type DotaAutochessChromosome() =
    inherit GeneticSharp.Domain.Chromosomes.ChromosomeBase(10)
    override x.CreateNew ()=
            DotaAutochessChromosome ()
    override x.GenerateGene geneIndex =
            GeneticSharp.Domain.Chromosomes.Gene geneIndex
        




[<EntryPoint>]
let main argv =

    printfn "Hello World from F#!"
    

   
        

    for item in [1..50] do
        let comp=generateRandomComposition 10
        Console.Write("Units: ")
        comp
        |> Seq.iter (fun (name, species, traits, cost) -> printf "%A " name)
        Console.Write("\nSpecies Perks: ")
        evaluateSpeciesPerks comp
        |> Seq.iter (fun speciesPerk -> printf "%A " speciesPerk)
        Console.Write("\nTrait Perks: ")
        evaluateTraitPerks comp
        |> Seq.iter (fun traitPerk -> printf "%A " traitPerk)
        Console.WriteLine("\n\n")
        ()

    let ga=GeneticAlgorithm(null,null,null,null,null)

    
    
    Console.ReadKey()
    |>ignore
    0 // return an integer exit code
