# Ludo
More or less, I tried to implement the game as I remembered it as playing Fia as a kid. Rules and features described in https://en.wikipedia.org/wiki/Ludo_(board_game) that I could not remember that I used to play with were left out.

Here is an example of the gameboard  

![](https://github.com/hkanjohansson/Ludo/blob/main/LudoApplication/GameboardExample.png)
## Architecture
The game is mainly build by three different building blocks (Directories): GameApplication, Players, and GameItems. 

### GameApplication
This directory consists of the classes Game, GameRules and GameUI. 

- Game has the overall responsibility to run the game. 

- GameRules is responsible to keep track of things that have to do with logic concerning rules e.g. like if Tokens are moveable and about to finish.

- GameUI creates and prints a UI and the main menu.

### Players
This directory consists only of a Player class right now. In the future there could be an AI added. If an AI is added there would be needed to make the Player class abstract and make PlayerAI and PlayerHuman inherit from Player.

#### Player
Just like the board game of Ludo, a player should have the features/items given. That is the fields are:
-gameboard
-colourOfTokens
-tokens (a list of tokens)
-finishedTokens (storing the finished tokens)
-startSquare (which position the player starts from when moving out of the home)
-finishArea (array of five chars)
### GameItems
This directory consists of Die, Gameboard and Token.

- Die: Has the field "numberOfSides" so you can choose to play the game with more or less than six sides of the die.
- Gameboard: Is only an array of 52 character elements.
- #### Token
Fields: 
- id
- colour
- home (makes sure that the token does not move out of the homefield if a six if not being rolled)
- position (position on the board)
- relativePosition (position relative to the starting point of each player)
- safe (when a token has entered the finish area, the token is considered to be safe)
- finishPosition (position on the finish area)
- finished (disabling the token when it has finished)

## Excluded Features
List of features that were excluded compared to https://en.wikipedia.org/wiki/Ludo_(board_game)
- When a player rolls a six, the player does not get an extra roll.
- When a player moves a token that lands on the same spot as one of its own tokens, it is still considered as individual tokens.
## Known Bugs
Both these bugs appear in rare cases that I have not yet discovered why they appear. These bugs are:
- Sometimes the tokens disappear from the board when they should not, and then reappear when it has been moved again.
- Sometimes a token can move past an opponents token, which should not be possible.
## Features to Add in the Future

### AI
First feature to add would be an AI player. An AI in this narrow sense of Ludo should have the features prioritised (in my opinion) in decreasing order:
- If an opponents token can be captured, a token that can capture it should always be doing that. If more than one of the opponents tokens can get captured, the AI should calculate the probability of getting captured by the opponents in the next turn. The token with highest probability of getting captured should be moved.
- Getting tokens out in the field. Since rolling a six is just of probability 1/6, it can take many turns before a token can get moved out. 
- Since finishing a token must be done with an exact roll, the same principle as for starting tokens apply here. The only difference here is that these tokens are safe and cannot be captured.
- If all tokens are in play, and none of the opponents tokens can get captured, then its just to calculate the probability of getting captured in the next turn. 

### Miscellaneous Features
Just like in chess where some of the tokens have different abilities, the four different tokens here could also be given that. One token could have the ability to land on an opponent even if a player did not roll the exact number. Another token could have the ability to "automatically" roll a six and then get out of home. So more or less features that could add a little bit of strategy to the game but still preserve the gameplay of Ludo would be of interest.
