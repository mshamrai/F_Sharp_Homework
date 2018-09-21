module  F_Sharp_4.Test

open NUnit.Framework
open FsUnit
open F_Sharp_4

[<Test>]
let ``Should test a normalizing (lambda x.lambda y. x y) a``() =
    let f = ("x" *  ("y" * (Varible("x") ^ Varible("y")))) ^ Varible("a")
    normalize f |> should equal ("y" * (Varible("a") ^ Varible("y")))

[<Test>]
let ``Should test a normalizing (lambda x.lambda y. x y) a b``() =
    let f = (("x" *  ("y" * (Varible("x") ^ Varible("y")))) ^ Varible("a")) ^ Varible("b")
    normalize f |> should equal (Varible("a") ^ Varible("b"))

[<Test>]
let ``Should test a unnormalizing (lambda x.x x x) (lambda x.x x x)``() =
    let f = ("x" * (Varible("x") ^ Varible("x") ^ Varible("x"))) ^ ("x" * (Varible("x") ^ Varible("x") ^ Varible("x")))
    (fun() -> normalize f |> ignore) |> should throw typeof<NormalizedFormNotFoundException>

[<Test>]
let ``Should normalize (lambda x.lambda y.x y) y``() =
    let f = ("x" *  ("y" * (Varible("x") ^ Varible("y")))) ^ Varible("y")
    normalize f |> should equal ("y" * (Varible("y0") ^ Varible("y")))