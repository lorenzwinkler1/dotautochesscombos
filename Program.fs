// Learn more about F# at http://fsharp.org

// Sorry for accidantly calling 'class' 'traits' :c didnt't want to change it after i recognized my mistake though

open System
open System.Linq;
open GeneticSharp.Domain;
open DotaAutochessCombosData;
open GeneticSharp.Domain.Chromosomes
open TypesAndFunctions

let printprogressevery = 100

[<EntryPoint>]
let main argv =

    printfn "Hello World from F#!"
    


    let selection = GeneticSharp.Domain.Selections.StochasticUniversalSamplingSelection()
    let crossover = GeneticSharp.Domain.Crossovers.TwoPointCrossover()
    let mutation = DotaAutochessMutation()
    let fitness = ComboFitness()
    let chromosome = DotaAutochessChromosome()
    chromosome.GetGenes()
    |> Seq.map (fun item -> item.Value)
    |> printfn "%A"
    let population = Populations.Population(1000, 10000, chromosome)


    let ga=GeneticAlgorithm(population,fitness,selection,crossover,mutation)
    ga.TaskExecutor <- GeneticSharp.Infrastructure.Framework.Threading.ParallelTaskExecutor()
    ga.Termination<-GeneticSharp.Domain.Terminations.GenerationNumberTermination(generationCount)

    let printResult ()=

        printfn "Found the following posibilities to achieve a Fitness of %A" (ga.BestChromosome.Fitness)

        let prettyPrintChromosome (chromosome:IChromosome)=
            let units=chromosome.GetGenes() |> Seq.map (fun item -> item.Value:?>(string * Species list * Traits list *int))
            let speciesPerks=evaluateSpeciesPerks (Seq.toList units)
            let traitPerks=evaluateTraitPerks (Seq.toList units)
            printfn "-----Fitness: %A, Cost: %A" chromosome.Fitness (units |> Seq.map (fun (_, _, _, cost) -> cost ) |> Seq.sum)
            printfn "Species: %A" (speciesPerks |> Seq.map string |> Seq.reduce (fun value current -> value+" "+ current))
            printfn "Classes: %A"(traitPerks |> Seq.map string |> Seq.reduce (fun value current -> value+" "+current))
            units 
            |> Seq.iter (fun (name,_,_,_) -> printfn "%A" name)

        ga.Population.Generations.Last().Chromosomes
        |> Seq.filter (fun item -> item.Fitness = ga.BestChromosome.Fitness)
        |> Seq.distinct
        |> Seq.iter prettyPrintChromosome

    ga.GenerationRan.Add((fun item -> if ga.GenerationsNumber%printprogressevery=0 then (if not (ga.GenerationsNumber=generationCount) then (printfn "Generation %A, Fitness: %A" ga.GenerationsNumber ga.BestChromosome.Fitness) else printResult())))
    

    ga.Stopped.Add((fun item -> printResult ()))

    ga.Start()
    
    Console.ReadKey()
    |>ignore
    0 // return an integer exit code
