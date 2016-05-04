open System.Security.Cryptography

let hexString array =
    array
    |> Array.map (fun (x:byte) -> System.String.Format("{0:x2}", x))
    |> String.concat System.String.Empty 
       
let hash algorithm (input:byte[]) =
    HashAlgorithm.Create(algorithm).ComputeHash(input)

let sha256 (input:byte[]) =
    hash "SHA256" input |> hexString
    
let md5 (input:byte[]) =
    hash "MD5" input |> hexString
    
let result = 
    "id0-rsa.pub"B
    |> sha256
    |> System.Text.Encoding.ASCII.GetBytes
    |> md5
    |> (printfn "%s")