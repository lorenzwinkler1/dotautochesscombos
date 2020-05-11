module TypesAndFunctions

open System
open DotaAutochessCombosData
open System.Linq
open GeneticSharp.Domain
open GeneticSharp.Domain.Chromosomes


let comboSize=10;

let evaluateSpeciesPerks comp =
    Enum.GetValues(typeof<Species>):?> (Species [])
    |> Seq.filter (fun item -> speciesRules.[item] comp)

let evaluateTraitPerks comp =
    Enum.GetValues(typeof<Traits>):?> (Traits [])
    |> Seq.filter (fun item -> traitRules.[item] (comp))


let evaluatePerks comp =
   (evaluateSpeciesPerks comp).Count() + (evaluateTraitPerks comp).Count()

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

type DotaAutochessChromosome() as this=
    inherit GeneticSharp.Domain.Chromosomes.ChromosomeBase(comboSize)
    let comp = generateRandomComposition comboSize

    do this.CreateGenes()
    override x.GenerateGene (geneIndex:int)= Chromosomes.Gene(comp.[geneIndex]) 
    override x.CreateNew () = DotaAutochessChromosome():>Chromosomes.IChromosome


type ComboFitness() =
    interface GeneticSharp.Domain.Fitnesses.IFitness with 
    member this.Evaluate (chromosome:Chromosomes.IChromosome) =
        chromosome.GetGenes()
        |> Seq.map (fun item -> item.Value :?> (string * Species list * Traits list *int) )
        |> Seq.toList
        |> evaluatePerks
        |> float

type DotaAutochessMutation() =
    inherit Mutations.MutationBase()
    override x.PerformMutate ((chromosome:IChromosome), (mutationProbability:float32)) = 
        if random.NextDouble() < (mutationProbability |> float)
        then chromosome.ReplaceGene(random.Next(comboSize), Chromosomes.Gene(units.[random.Next(units.Length)]))
