# Ludo

## Architecture
The game is mainly build by three different building blocks (Directories): GameApplication, Players, and GameItems. 

### GameApplication
This directory consists of the classes Game, GameRules and GameUI. 

- Game has the overall responsibility to run the game. 

- GameRules is responsible to keep track of things that have to do with logic concerning rules e.g. like if Tokens are moveable and about to finish.

- GameUI creates and prints a UI and the main menu.

### Players
This directory consists only of a Player class right now. In the future there could be an AI added. If an AI is added there would be needed to make the Player class abstract and make PlayerAI and PlayerHuman inherit from Player.
### GameItems
This directory consists of Die, Gameboard and Token.

- Die: Has the field "numberOfSides" so you can choose to play the game with more or less than six sides of the die.
- Gameboard: Is only an array of 52 character elements.
- #### 
Token: Has the fields 
- id
- colour
- home (makes sure that the token does not move out of the homefield if a six if not being rolled)
- position (position on the board)
- relativePosition (position relative to the starting point of each player)
- safe (when a token has entered the finish area, the token is considered to be safe)
- finishPosition (position on the finish area)
- finished (disabling the token when it has finished)

## Features

## Known Bugs

## Features to Add in the Future
