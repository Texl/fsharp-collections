open System
open System.Collections
open System.Collections.Generic
open System.Collections.Immutable
open System.IO

type Key =
    { Id: Guid }

type Value =
    { Data : string }

// let interfaces =
//     [
//       typeof<IEnumerable<KeyValuePair<Key,Value>>>
//       typeof<IEnumerable<Value>>
//       typeof<IEnumerable>
//
//       typeof<IReadOnlyCollection<KeyValuePair<Key,Value>>>
//       typeof<IReadOnlyCollection<Value>>
//       typeof<ICollection<KeyValuePair<Key,Value>>>
//       typeof<ICollection<Value>>
//       typeof<ICollection>
//
//       typeof<IReadOnlyList<Value>>
//       typeof<IList<KeyValuePair<Key,Value>>>
//       typeof<IList<Value>>
//       typeof<IList>
//
//       typeof<IReadOnlySet<Value>>
//       typeof<ISet<Value>>
//
//       typeof<IReadOnlyDictionary<Key,Value>>
//       typeof<IDictionary<Key,Value>>
//       typeof<IDictionary>
//
//       typeof<IComparable<Dictionary<Key,Value>>>
//       typeof<IComparable<HashSet<Value>>>
//       typeof<IComparable<IEnumerable<Value>>>
//       typeof<IComparable<ImmutableArray<Value>>>
//       typeof<IComparable<ImmutableDictionary<Key,Value>>>
//       typeof<IComparable<ImmutableHashSet<Value>>>
//       typeof<IComparable<ImmutableList<Value>>>
//       typeof<IComparable<LinkedList<Value>>>
//       typeof<IComparable<List<Value>>>
//       typeof<IComparable<Map<Key,Value>>>
//       typeof<IComparable<ResizeArray<Value>>>
//       typeof<IComparable<Set<Value>>>
//       typeof<IComparable<Value list>>
//       typeof<IComparable<Value[]>>
//       typeof<IComparable<seq<Value>>>
//       typeof<IComparable>
//
//       typeof<IEquatable<Dictionary<Key,Value>>>
//       typeof<IEquatable<HashSet<Value>>>
//       typeof<IEquatable<IEnumerable<Value>>>
//       typeof<IEquatable<ImmutableArray<Value>>>
//       typeof<IEquatable<ImmutableDictionary<Key,Value>>>
//       typeof<IEquatable<ImmutableHashSet<Value>>>
//       typeof<IEquatable<ImmutableList<Value>>>
//       typeof<IEquatable<LinkedList<Value>>>
//       typeof<IEquatable<List<Value>>>
//       typeof<IEquatable<Map<Key,Value>>>
//       typeof<IEquatable<ResizeArray<Value>>>
//       typeof<IEquatable<Set<Value>>>
//       typeof<IEquatable<Value list>>
//       typeof<IEquatable<Value[]>>
//       typeof<IEquatable<seq<Value>>>
//
//       typeof<IStructuralComparable>
//       typeof<IStructuralEquatable>
//     ]

let interfaceNames =
    [
      "IEnumerable"
      "IReadOnlyCollection"
      "ICollection"
      "IReadOnlyList"
      "IList"
      "IReadOnlySet"
      "ISet"
      "IReadOnlyDictionary"
      "IDictionary"
      "IComparable"
      "IEquatable"
      "IStructuralComparable"
      "IStructuralEquatable"
    ]

let types =
    [
      // BCL types      
      typeof<Value[]>
      typeof<List<Value>>

      // C# types      
      typeof<LinkedList<Value>>
      typeof<HashSet<Value>>
      typeof<SortedSet<Value>>
      typeof<Dictionary<Key,Value>>

      // Immutable collections
      typeof<ImmutableDictionary<Key,Value>>
      typeof<ImmutableHashSet<Value>>
      typeof<ImmutableList<Value>>

      // F# types
      typeof<Value list>
      typeof<Set<Value>>
      typeof<Map<Key,Value>>
    ]

let interfaces =
    types
    |> Seq.collect (fun t -> t.GetInterfaces())
    |> Seq.distinct
    |> List.ofSeq

let rec getFormattedName (t : Type) =
    printfn "%s" t.Name
    if t.Name.Contains("[]") then
        "Array"
    elif t.IsGenericType && t.Name.Contains('`') then
        let genericArguments =
            t.GetGenericArguments()
            |> Seq.map getFormattedName
            |> String.concat ", "
        let name = t.Name.Substring(0, t.Name.IndexOf('`'))
        // $"%s{name}<%s{genericArguments}>"
        $"%s{name}"
    else
        t.Name

let flip f a b = f b a

let interfaceGroups =
    interfaces
    |> Seq.groupBy getFormattedName
    |> Seq.filter (fun (name, _) -> interfaceNames |> List.contains name)
    |> Seq.sortBy (fun (name, _) -> interfaceNames |> List.findIndex (fun n -> n = name))
    |> List.ofSeq

let output =
    seq {
        seq {
            ""
            yield! (interfaceGroups |> Seq.map fst) 
        }
        |> String.concat " | "

        Seq.replicate (1 + (interfaceGroups |> Seq.length)) "---"
        |> String.concat "|"
        
        for t in types do
            seq {
                getFormattedName t
                for _formattedName, interfaces in interfaceGroups do
                    if interfaces |> Seq.exists (fun ``interface`` -> ``interface``.IsAssignableFrom t) then "✅" else ""        
            }
            |> String.concat " | "
    }
    |> Seq.map (fun l -> $"|{l}|")
    |> String.concat "\n"

let output2 =
    seq {
        seq {
            ""
            yield! (types |> Seq.map getFormattedName) 
        }
        |> String.concat " | "

        seq {
            "---"
            yield! Seq.replicate (types |> Seq.length) ":-:"
         }
        |> String.concat "|"
        
        for formattedName, interfaces in interfaceGroups do
            seq {
                formattedName
                for t in types do
                    if interfaces |> Seq.exists (fun ``interface`` -> ``interface``.IsAssignableFrom t) then "✅" else ""        
            }
            |> String.concat " | "
    }
    |> Seq.map (fun l -> $"|{l}|")
    |> String.concat "\n"

File.WriteAllText("Interfaces.md", output2)
