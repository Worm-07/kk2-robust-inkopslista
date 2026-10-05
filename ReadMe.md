1. När jag försökte att köra programmet utan några ändringar fick jag dessa felmedelanden och programmet krachade:  

Unhandled exception. System.IndexOutOfRangeException: Index was outside the bounds of the array.
   at ShoppingList.Load() in C:\Users\emilc\OneDrive\Desktop\kk2-robust-inkopslista\ShoppingList.cs:line 90
   at Program.<Main>$(String[] args) in C:\Users\emilc\OneDrive\Desktop\kk2-robust-inkopslista\Program.cs:line 2

Då testade jag att ta bort "line 2" inne i program.cs, och då fungerade programmet. 

