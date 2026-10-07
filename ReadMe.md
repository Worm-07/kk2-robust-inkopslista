### Fel 1. 
När jag försökte att köra programmet utan några ändringar fick jag dessa felmedelanden och programmet krachade:  

Unhandled exception. System.IndexOutOfRangeException: Index was outside the bounds of the array.
   at ShoppingList.Load() in C:\Users\emilc\OneDrive\Desktop\kk2-robust-inkopslista\ShoppingList.cs:line 90
   at Program.<Main>$(String[] args) in C:\Users\emilc\OneDrive\Desktop\kk2-robust-inkopslista\Program.cs:line 2

Då testade jag att ta bort "line 2" inne i program.cs, och då fungerade programmet. 

### Fel 2. 
På rad 28 inne på ShoppingList satte man värdet på i=1 från början, då räknas inte första produkten med i "total". För att fixa det satte jag startvärdet till 0 istället. 

### Fel 3. 
Programmet krachar när man försöker att skriva in priset med bokstäver. Jag fixade det med en TryParse. Är inputen siffror så läggs produkten till, annars så skrivs ett meddelande ut ("=== Ange priset i siffror ==="). Detta är i Program.cs

### Fel 4. 
Programmet krachar när man försöker ange produkten man vill ta bort med bokstäver. Jag fixade det med en TryParse. Om inputen är i siffror så tas den bort, finns inte produktnummret så får man ett felmeddelande. Skriver man in produkten med bokstäver får man meddelandet (" === Ange nummret i siffror ===");. Detta är i program.cs.
I Shopping.List på rad 11 lade jag till metoden count. Eftersom att listan är privat så kommer list.Count inte åt den, men med Count metoden kan jag läsa hur många varor som finns i listan.