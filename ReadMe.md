1. När jag försökte att köra programmet utan några ändringar fick jag dessa felmedelanden och programmet krachade:  

Unhandled exception. System.IndexOutOfRangeException: Index was outside the bounds of the array.
   at ShoppingList.Load() in C:\Users\emilc\OneDrive\Desktop\kk2-robust-inkopslista\ShoppingList.cs:line 90
   at Program.<Main>$(String[] args) in C:\Users\emilc\OneDrive\Desktop\kk2-robust-inkopslista\Program.cs:line 2

Då testade jag att ta bort "line 2" inne i program.cs, och då fungerade programmet. 

2. På rad 28 inne på ShoppingList satte man värdet på i=1 från början, då räknas inte första produkten med i "total". För att fixa det satte jag startvärdet till 0 istället. 

3. Programmet krachar när man försöker att skriva in priset med bokstäver. Jag fixade det med en TryParse. Är inputen siffror så läggs produkten till, annars så skrivs ett meddelande ut ("=== Ange priset i siffror ==="). Detta är i Program.cs