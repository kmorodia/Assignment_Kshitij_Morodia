# Assignment_Kshitij_Morodia
video link: https://youtu.be/S8eo1ji2zm0

Scenes:
2 scenes created as specified. User can navigate from the Start Screen to Game Scene by clicking "Start Game" button. When the game ends the score is displayed alonk with the "OK" button with can be clicked to reach the Start Screen.

Snake:
The snakes body is composed of a head -> neck -> tail. The tail is a list of similar spheres attached to the neck. Movement in 1 step happens when the head's first position is defined and the rest on the list follow to reach the previous postition of their parent.

Food:
Food data is read from a json file. There are predefined colors in the code and colors in json config file that do not match them aer ignored. Food is randomly spawned on the map and then disappears after some time. Same color Streak multipliers is implemented exactly as mentioned.

General:
Code is made as modular as possible keeping in mid various aspects of the system with different components coordinating as and when required.
