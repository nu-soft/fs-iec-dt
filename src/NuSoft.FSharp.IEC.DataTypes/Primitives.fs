namespace System

  #nowarn "0042"
  #nowarn "9"
  type BOOL   = bool //with
    //static member inline (?<-) i v = setBit n i v
  type BYTE   = byte
  type WORD   = uint16
  type DWORD  = uint32
  type LWORD  = uint64
  type SINT   = sbyte
  type USINT  = byte
  type INT    = int16
  type UINT   = uint16
  type DINT   = int32
  type LINT   = int64
  type UDINT  = uint32
  type ULINT  = uint64
  type REAL   = float32
  type LREAL  = float


  [<AutoOpen>]
  module Operators =

    [<CompiledName("ToBYTE")>]
    let inline BYTE (x: ^T) = byte x

    [<CompiledName("ToWORD")>]
    let inline WORD (x: ^T) = uint16 x
    
    [<CompiledName("ToDWORD")>]
    let inline DWORD (x: ^T) = uint32 x

    [<CompiledName("ToLWORD")>]
    let inline LWORD (x: ^T) = uint64 x

    [<CompiledName("ToSINT")>]
    let inline SINT (x: ^T) = sbyte x

    [<CompiledName("ToUSINT")>]
    let inline USINT (x: ^T) = byte x

    [<CompiledName("ToINT")>]
    let inline INT (x: ^T) = int16 x

    [<CompiledName("ToUINT")>]
    let inline UINT (x: ^T) = uint16 x

    [<CompiledName("ToDINT")>]
    let inline DINT (x: ^T) = int32 x

    [<CompiledName("ToUDINT")>]
    let inline UDINT (x: ^T) = uint32 x

    [<CompiledName("ToLINT")>]
    let inline LINT (x: ^T) = int64 x

    [<CompiledName("ToULINT")>]
    let inline ULINT (x: ^T) = uint64 x

    [<CompiledName("ToREAL")>]
    let inline REAL (x: ^T) = float32 x

    [<CompiledName("ToLREAL")>]
    let inline LREAL (x: ^T) = float x

  
    [<MeasureAnnotatedAbbreviation>] type BYTE<[<Measure>] 'Measure>   = BYTE 
    [<MeasureAnnotatedAbbreviation>] type WORD<[<Measure>] 'Measure>   = WORD 
    [<MeasureAnnotatedAbbreviation>] type DWORD<[<Measure>] 'Measure>  = DWORD
    [<MeasureAnnotatedAbbreviation>] type LWORD<[<Measure>] 'Measure>  = LWORD
    [<MeasureAnnotatedAbbreviation>] type SINT<[<Measure>] 'Measure>   = SINT 
    [<MeasureAnnotatedAbbreviation>] type USINT<[<Measure>] 'Measure>  = USINT
    [<MeasureAnnotatedAbbreviation>] type INT<[<Measure>] 'Measure>    = INT  
    [<MeasureAnnotatedAbbreviation>] type UINT<[<Measure>] 'Measure>   = UINT 
    [<MeasureAnnotatedAbbreviation>] type DINT<[<Measure>] 'Measure>   = DINT 
    [<MeasureAnnotatedAbbreviation>] type UDINT<[<Measure>] 'Measure>  = UDINT
    [<MeasureAnnotatedAbbreviation>] type LINT<[<Measure>] 'Measure>   = LINT 
    [<MeasureAnnotatedAbbreviation>] type ULINT<[<Measure>] 'Measure>  = ULINT
    [<MeasureAnnotatedAbbreviation>] type REAL<[<Measure>] 'Measure>   = REAL 
    [<MeasureAnnotatedAbbreviation>] type LREAL<[<Measure>] 'Measure>  = LREAL
    

    let inline 
      op_AtAt<'T 
      when 'T:  (static member (<<<): 'T -> int -> 'T) 
      and 'T:   (static member (&&&): 'T -> 'T -> 'T) 
      and 'T:   (static member op_RightShift: 'T -> int -> 'T)> (a: 'T) (b: int) = 
      ( a &&& ( (# "" 1 : 'T #) <<< b) ) >>> b 

    let inline 
      op_LessBang<'T 
        when 'T:  (static member (<<<): 'T -> int -> 'T) 
        and 'T:   (static member (&&&): 'T -> 'T -> 'T) 
        and 'T:   (static member (~~~): 'T -> 'T) 
        and 'T:   equality 
        and 'T:   (static member (|||): 'T -> 'T -> 'T)> (a: 'T) (b: int) (c: 'T) =
      match c <> Unchecked.defaultof<'T> with
        | true -> a ||| ((# "" 1 : 'T #) <<< b)
        | _ -> a &&& (~~~((# "" 1 : 'T #) <<< b))
      
 
  [<AutoOpen>]
  module MeasureOperators =
    let inline retype<'T,'U> (x:'T) : 'U = (# "" x : 'U #)

    let inline BYTEWithMeasure   (f : BYTE ) : BYTE<'Measure> = retype f
    let inline WORDWithMeasure   (f : WORD ) : WORD<'Measure> = retype f
    let inline DWORDWithMeasure  (f : DWORD) : DWORD<'Measure> = retype f
    let inline LWORDWithMeasure  (f : LWORD) : LWORD<'Measure> = retype f
    let inline SINTWithMeasure   (f : SINT ) : SINT<'Measure> = retype f
    let inline USINTWithMeasure  (f : USINT) : USINT<'Measure> = retype f
    let inline INTWithMeasure    (f : INT  ) : INT<'Measure> = retype f
    let inline UINTWithMeasure   (f : UINT ) : UINT<'Measure> = retype f
    let inline DINTWithMeasure   (f : DINT ) : DINT<'Measure> = retype f
    let inline UDINTWithMeasure  (f : UDINT) : UDINT<'Measure> = retype f
    let inline LINTWithMeasure   (f : LINT ) : LINT<'Measure> = retype f
    let inline ULINTWithMeasure  (f : ULINT) : ULINT<'Measure> = retype f
    let inline REALWithMeasure   (f : REAL ) : REAL<'Measure> = retype f
    let inline LREALWithMeasure  (f : LREAL) : LREAL<'Measure> = retype f
    
