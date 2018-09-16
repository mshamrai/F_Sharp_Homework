﻿namespace Phonebook

open System.Collections.Generic

type UI() = 
    let commands : IDictionary<int, ICommand> = dict[]
    member this.AddCommand key command : unit = 
        commands.Add(key, command)
    
    member this.PrintCommands : unit =
        for KeyValue(k, v) in commands do
            printfn "%s" v.Title

    member this.GetCommand key : ICommand = commands.[key]
    