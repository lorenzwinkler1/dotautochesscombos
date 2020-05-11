// Learn more about F# at http://fsharp.org

open System
open System.Linq;
open GeneticSharp.Domain;
open DotaAutochessCombosData;
open GeneticSharp.Domain.Chromosomes
open TypesAndFunctions



[<EntryPoint>]
let main argv =

    printfn "Hello World from F#!"
    


    let selection = GeneticSharp.Domain.Selections.EliteSelection()
    let crossover = GeneticSharp.Domain.Crossovers.VotingRecombinationCrossover()
    let mutation = DotaAutochessMutation()
    let fitness = ComboFitness()
    let chromosome = DotaAutochessChromosome()
    chromosome.GetGenes()
    |> Seq.map (fun item -> item.Value)
    |> printfn "%A"
    let population = Populations.Population(50, 500, chromosome)
        


    let ga=GeneticAlgorithm(population,fitness,selection,crossover,mutation)
    ga.Termination<-GeneticSharp.Domain.Terminations.GenerationNumberTermination(100)
    ga.GenerationRan.Add((fun item -> printfn "%A" ga.BestChromosome.Fitness))

    ga.Start()
    
    Console.ReadKey()
    |>ignore
    0 // return an integer exit code
