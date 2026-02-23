This is a very simple number guessing game designed in Unity. In the final interation of the game it should: pick a random number between 1-100, have the player guess the number, tell the player if it is too high, too low, or the right number,
track the number of attempts, and let the player restart.

For the components of the game what is needed is a GameManager, and a UIController. The GameManager will contain all of the code for the game to work, and since it is a rather simple game it should be possible for it all to be in here.
The UIController would be for the UI to function, as this game will require a UI to work: buttons, text fields, ect.

The flow should be that the game starts ---> guess ---> correct/incorrect ---> repeat. A simple flow state for the game.

With the data to be tracked the numbers it puts out and flags that are set up would be a good starting point for this project.
