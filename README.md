# fsharp-collections
An overview of some F# collections usage from C#.

---

## FSharpList
- [Documentation](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-list-1.html)
- [Examples](FSharpCollections/Examples/FSharpList.cs)

|                       | Array | List | LinkedList | ImmutableList | FSharpList |
|-----------------------|:-----:|:----:|:----------:|:-------------:|:----------:|
| IEnumerable           |   ✅   |  ✅   |     ✅      |       ✅       |     ✅      |
| IReadOnlyCollection   |   ✅   |  ✅   |     ✅      |       ✅       |     ✅      |
| ICollection           |   ✅   |  ✅   |     ✅      |       ✅       |            |
| IReadOnlyList         |   ✅   |  ✅   |            |       ✅       |     ✅      |
| IList                 |   ✅   |  ✅   |            |       ✅       |            |
| IComparable           |       |      |            |               |     ✅      |
| IEquatable            |       |      |            |               |     ✅      |
| IStructuralComparable |   ✅   |      |            |               |     ✅      |
| IStructuralEquatable  |   ✅   |      |            |               |     ✅      |

---

# FSharpSet
- [Documentation](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-fsharpset-1.html)
- [Examples](FSharpCollections/Examples/FSharpSet.cs)

|                       | HashSet | ImmutableHashSet | FSharpSet |
|-----------------------|:-------:|:----------------:|:---------:|
| IEnumerable           |    ✅    |        ✅         |     ✅     |
| IReadOnlyCollection   |    ✅    |        ✅         |     ✅     |
| ICollection           |    ✅    |        ✅         |     ✅     |
| IReadOnlySet          |    ✅    |        ✅         |           |
| ISet                  |    ✅    |        ✅         |           |
| IComparable           |         |                  |     ✅     |


---

# FSharpMap
- [Documentation](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-fsharpmap-2.html)
- [Examples](FSharpCollections/Examples/FSharpMap.cs)

|                       | Dictionary | ImmutableDictionary | FSharpMap |
|-----------------------|:----------:|:-------------------:|:---------:|
| IEnumerable           |     ✅      |          ✅          |     ✅     |
| IReadOnlyCollection   |     ✅      |          ✅          |     ✅     |
| ICollection           |     ✅      |          ✅          |     ✅     |
| IReadOnlyDictionary   |     ✅      |          ✅          |     ✅     |
| IDictionary           |     ✅      |          ✅          |     ✅     |
| IComparable           |            |                     |     ✅     |
