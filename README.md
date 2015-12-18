# Create-a-Game-Source
Source code for the Create a Game tutorial series found here: https://youtu.be/SviIeTt2_Lc?list=PLFt_AvWsXl0ctd4dgE1F8g3uec4zKNRV0

Post tutorial series fixes:

Problem: Sfx volume incorrect after choosing to play again

Solution: Add this method to the AudioManager class:
```
  void OnLevelWasLoaded(int index) {
  	if (playerT == null) {
  		if (FindObjectOfType<Player> () != null) {
  			playerT = FindObjectOfType<Player> ().transform;
  		}
  	}
  }
```
Problem: Player being awarded score multiple times for single enemy death:

Solution: In TakeHit method of Enemy class, replace "if (damage >= health) {" with "if (damage >= health && !dead) {" 
