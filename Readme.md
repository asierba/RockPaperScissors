# Rock Paper Scissors #

Console App to play [Rock Paper Scissors](https://en.wikipedia.org/wiki/Rock-paper-scissors) between two players.

## Pre-requisites ##

You need to install [dotnet core](https://www.microsoft.com/net/learn/get-started
) in your local machine.

Build the solution and navigate to the bin folder:

```
dotnet build 
cd RockPaperScissors/bin/Debug/netcoreapp2.0
```

## How to run it ##

Default usage runs a game of 3 turns for two human players:

```
dotnet RockPaperScissors.dll
```

You can define the player type as Human, Random Cpu or Tactical Cpu:
```
dotnet RockPaperScissors.dll --player1 human --player2 tactical
```

You can aslo define the number of turns for the game:
```
dotnet RockPaperScissors.dll --turns 1
```