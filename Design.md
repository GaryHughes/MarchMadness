

## Overview

    - 68 teams in the competition.
    - 4 lowest ranked teams are the First Four.
    - Split into 4 regions of 16 teams, seeded from 1 to 16.
    - Within each region, #1 plays #16, #2 plays #15 and so on.
    - If a team loses once, they are out of the competition.
    - The winners of each region are the Final Four.
    - 63 games in the bracket.


## Example

Region North
#1 vs #16
#2 vs #15
#3 vs #14
#4 vs #13
#5 vs #12
#6 vs #11
#7 vs #10
#8 vs #9


Round 1: 16 teams, 8 games
Round 2:  8 teams, 4 games
Round 3:  4 teams, 2 games
Round 4:  2 teams, 1 game

Then the Final Four

Round 5: 4 teams, 2 games
Round 6: 2 teams, 1 game

Total Games: 4 * 15 + 3 = 63


## Data Structure

Regions: North, South, East, West
Teams: 64
Games: 63

{
    teams:
    [
        {
            name: "North",
            teams:
            [
                "team1",
                "team2",
                "team3",
                "team4"
            ]
        },
        {
            name: "South",
            teams:
            [
                "team5",
                "team6",
                "team7",
                "team8"
            ]
        }
    ],
    games:
    [
        {
            round: 1,
            home: "team1",
            away: "team4",
            winner: "team1"
        },
        {
            round: 1,
            home: "team2",
            away: "team3",
            winner: "team3"
        },
        {
            round: 2,
            home: "team1",
            away: "team3",
            winner: ""
        }
    ]
}
    






