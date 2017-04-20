#r "tools/FakeLib.dll"
open Fake

let buildDir = "./build"

Target "Clean" (fun _ ->
  CleanDir buildDir
)

Target "Default" (fun _ ->
  ["NuSoft.FSharp.IEC.DataTypes/AssemblyInfo.fs";"NuSoft.FSharp.IEC.DataTypes/Primitives.fsi";"NuSoft.FSharp.IEC.DataTypes/Primitives.fs"]
  |> FscHelper.compile [
    sprintf "%s/NuSoft.FSharp.IEC.DataTypes.dll" buildDir |> FscHelper.Out 
    FscHelper.Target FscHelper.TargetType.Library
    FscHelper.TargetProfile FscHelper.Profile.MsCorlib
    FscHelper.Tailcalls true
    FscHelper.Platform FscHelper.PlatformType.AnyCpu
    FscHelper.DebugType FscHelper.PdbOnly
    FscHelper.NoFramework
    FscHelper.FullPaths
    FscHelper.HighEntropyVA true
  ]
  |> function 0 -> () | c -> failwithf "F# compiler return code: %i" c
)

"Clean"
  ==> "Default"

RunTargetOrDefault "Default"