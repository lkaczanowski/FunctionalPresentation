- title : Programowanie funkcyjne (i nie tylko) w F#
- description : Czyli "flexible na przyszłość" w praktyce
- author : Łukasz Kaczanowski
- theme : night
- transition : default

***

### Czego się dzisiaj dowiemy
* Funkcje to nie metody
* Typy to nie klasy
* Kompozycja to nie dziedziczenie

---

### Funkcje matematyczne

$ f:A \rightarrow  B $

* A - dziedzina, czyli zbiór argumentów funkcji
* B - przeciwdziedzina, czyli zbiór wartości funkcji

---

### Funkcje matematyczne

$ f(x) =  x + 1 $

![Funkcja](images/F001.png)

    let add1 x = x + 1

---

### Cechy funkcji

* zawsze zwraca tą samą wartość dla tego samego argumentu (jest mapą wartości)
* nie może mieć skuktów ubocznych (czystość)
* argumenty oraz wartości funkcji są niezmienne
* ma zawsze jedno wejście i jedno wyjście

---

### Co nam to daje?

* Bardzo uproszczona aplikacja paraleizmu. Locki, mutexy i inne podobne są zbędne.
* *Lazy evaluation* na pierwszym miejscu
* Kolejność wywołania funkcji nie ma (aż tak dużego) znaczenia
* Każda funkcja jest cache'owalna (*memoization*)

***

### Krótko o F#

> **wieloparadygmatowy** język programowania zawierający w sobie głównie cechy języka **funkcyjnego**, ale umożliwiającym także pisanie kodu imperatywnego oraz obiektowego. Jest językiem **silnie typowanym** zaprojektowanym w celu pisania prostego, solidnego i wydajnego kodu do rozwiązywania złożonych problemów. Jest uruchamiany na **platformie .NET**.

***

### Funkcje

---

#### Wartości

    let number = 5
    let surname = "Kowalski"

#### Funkcje

    let add x y = x + y
    let sum = add

---

### Currying

    let add x y = x + y
    
    let add' x = fun y -> x + y

---

### Currying

    let add x y = (+) x y

    let three = ((add 1) 2)
    let three' = (((+) 1) 2)

---

### Partial application

    let add x y = (+) x y

    let add10 = (+) 10

---

### Partial application

    let getOblgation connectionString obligationId = ...

    let getObligationIoC = getObligation @"Server=.;Database=db;Trusted_Connection=True;"

Coś to przypomina?

---

### Pipe

    let (|>) x f = f x

    [1;2;3;4] 
    |> List.filter (fun i -> i > 2)
    |> List.sum

    let Log level message = sprintf "[%s] - %s" level message
    "some warning" |> Log "Warn"

---

### Kompozycja

    let (>>) f g x = g (f x)

    let add x y = x + y
    let mul x y = x * y

    let add5AndMultiplyBy3 = add 5 >> mul 3

***

### Typy algebraiczne

---

### Aliasy

    type ClientId = System.Guid
    type DocumentNumber = int
    type DocumentData = string
    type DocumentTuple = DocumentNumber * DocumentData

    type QueryFunction = ClientId -> Document list

    let printDocuments (query:QueryFunction) (clientId:ClientId) = 
        clientId |> query |> List.iter (fun doc -> printf "%A" doc)

---

### Tuple

![Tuple](images/F002.png)

    let intANDstring = (1, "str")

    let t2 = (true, "data")
    let t3 = (1, "data", false)

    let n1 = fst t2
    let n2 = snd t2
    let (b, str) = t2

---

### Rekordy

    type DocumentRecord = { Number: DocumentNumber; Data: DocumentData; IsSigned: bool }

    let document = { Number = 1; Data = "data"; IsSigned = false }

    let signDocument doc = { doc with IsSigned = true }

    let { Data = d; IsSigned = b } = (signDocument document)

---

### Unie

![Tuple](images/F003.png)

    type intORstring = | Int of int | String of string

---

### Unie

    type DocumentRecord' = { Number: DocumentNumber; Data: DocumentData; } 
    type DocumentUnion = 
    | Unsigned of DocumentRecord'
    | Signed of DocumentRecord'

    let signDocument (document: DocumentUnion) =
        match document with
        | Signed _ -> document
        | Unsigned doc -> Signed doc

---

### Pojedyńcze unie

    type SignedDocument = SignedDocument of DocumentRecord'

    type UnsignedDocument = UnsignedDocument of DocumentRecord'

    let signDocument2 (UnsignedDocument record) = SignedDocument record