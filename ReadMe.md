### Fel 1 och 2. 
När jag försökte att köra programmet utan några ändringar fick jag dessa felmeddelanden och programmet kraschade:  

Unhandled exception. System.IndexOutOfRangeException: Index was outside the bounds of the array.
   at ShoppingList.Load() in C:\Users\emilc\OneDrive\Desktop\kk2-robust-inkopslista\ShoppingList.cs:line 90
   at Program.<Main>$(String[] args) in C:\Users\emilc\OneDrive\Desktop\kk2-robust-inkopslista\Program.cs:line 2

Först testade jag att kommentera bort `list.Load();` på rad 2 i Program.cs, och då fungerade programmet. 
Senare insåg jag att det inte hjälper att spara listan om `list.Load()` aldrig körs, eftersom de sparade varorna då aldrig läses in igen. Därför satte jag tillbaka raden och letade i stället efter orsaken i metoden `Load`.

**Orsaken i Load:** Filen sparas med radbrytningen `\r\n` efter varje rad, men `Load` delade texten med `Split('\n')`. Då blev den sista raden tom, och när koden försökte läsa `parts[1]` på en tom rad kraschade den. Dessutom blev ett `\r` kvar i slutet av varje rad. 
Jag bytte `File.ReadAllText` och `Split('\n')` mot `File.ReadAllLines(path)`, som delar upp raderna rätt och tar bort den tomma sista raden. 
Jag la också till en `if`-sats: om filen inte finns så görs en `return`, alltså avslutas `Load`, och programmet fortsätter ändå med en tom lista. Utan den kraschade programmet första gången man körde det, när `items.txt` ännu inte fanns.

**Save:** 
I `try` använder jag nu `File.WriteAllLines(path, lines);` i stället för att bygga ihop en lång text med `string.Join`. Varje produkt sparas fortfarande på sin egen rad. 
Meddelandet "Listan är sparad." flyttade jag in i `try`. Förut låg det efter `try/catch` och skrevs ut även om det inte gick att spara. 
`catch` var tom, så om det inte gick att spara hände ingenting. Nu skriver den ut "Kunde inte spara listan.".

**Fel som kommer med:**
`\r` gör att det inte går att söka efter en produkt. Raden `50:Kaffe` blev namnet `Kaffe\r`, och `Kaffe\r` är inte lika med `Kaffe`, så `Find` hittar ingenting. 

### Fel 3. 
I metoden `Total` i ShoppingList.cs satte man värdet på `i` till 1 från början, och då räknades inte första produkten med i totalsumman. För att fixa det satte jag startvärdet till 0 i stället. 

### Fel 4. 
Programmet kraschade när man skrev in priset med bokstäver, eftersom koden använde `int.Parse`. Jag bytte till `int.TryParse`. Är inputen siffror så läggs produkten till, annars skrivs ett meddelande ut ("=== Ange priset i siffror ==="). Detta är i Program.cs. 

### Fel 5. 
Programmet kraschade när man skrev in numret på produkten man ville ta bort med bokstäver, eftersom koden använde `int.Parse`. Jag fixade det med `int.TryParse`. 
- Skriver man numret med bokstäver får man meddelandet (" === Ange numret i siffror ==="). 
- Är inputen siffror men numret inte finns i listan får man ett felmeddelande (" === produkten finns inte i din lista ===") i stället för att programmet kraschar. Giltiga nummer är 1 till antalet varor, eftersom listan visas från 1. 
- Annars tas produkten bort. 

För att kunna kontrollera numret behövde Program.cs veta hur många varor listan har. I ShoppingList.cs lade jag till egenskapen `Count` (på rad 11). Listan `items` är privat, så Program.cs kommer inte åt den direkt, men med `Count` kan Program.cs läsa hur många varor som finns i listan.

### Fel 6.
Programmet kraschade när man skrev in bokstäver i menyn, men det hände inget när man valde ett nummer utanför `1-5`. 
Med en `TryParse` löste jag så att programmet inte kraschar om man skriver in en `string`. Jag döpte om den inmatade variabeln till `input`, så att `TryParse` matar ut `choice` istället. 
Med en `if`-sats så kontrolleras det nu om numret ligger mellan 1-5. Om användaren nu skulle mata in en bokstav eller ett nummer utanför 1-5 så får man ett felmeddelande, att man ska välja ett nummer mellan 1-5. 

### Eftertanke
Efter ett tag när jag inte hittade `Fel 6` så frågade jag Claude och frågade om den kunde hitta fel 6. Då förklarade den att `Save` och `Load` var 2 olika problem. Så att alla mina commits blir ganska vilseledande. 