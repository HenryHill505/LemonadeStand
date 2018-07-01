# LemonadeStand
Repository for the Lemonade Stand project

1. Liskov Substitution Principle - The class Computer inherits from LemonadeStandOwner. If the user chooses to play a game against the computer, then Computer is instantiated and passed into a List of LemonadeStandOwners on line 70 of GameMaster.cs . Computer can run all the methods that are called on the objects in the List. It runs override methods where appropriate.

2. Single Responsibility Principle - The DisplayRules method on line 53 in GameMaster does nothing but write the rules of the game to the screen.
