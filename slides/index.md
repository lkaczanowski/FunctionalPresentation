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

--- 

### Basic F#

#### Wartości

    let number = 5
    let surname = "Kowalski"

#### Funkcje

    let add x y = x + y
    let sum = add

---

### Currying

    let add x y z = x + y + z
    
    let add x y = fun z -> x + y + z

    let add x = fun z -> (fun y -> x + y + z)

---

### Currying

    val add: x -> y -> z -> int
    
    val add: x -> (y -> z -> int)

    val add: x -> (y -> (z -> int))

---

### Partial application

    let add x y z = x + y + z

    let add5 y z = add 5 y z

    let add10 = add 5 5

---

### Partial application

    let addObligation obligationQuery obligation = ()

    let addObligationIoC = addObligation obligationQueryImplementation

Coś to przypomina?

***