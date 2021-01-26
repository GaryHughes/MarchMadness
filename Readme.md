# March Madness

This program simulates selection of a March Madness basketball bracket as described at https://en.wikipedia.org/wiki/March_Madness_pools.

  - The program loads the teams from a csv file (supplied).
  - As it runs, the user can press H, A or R to select the winner of each game (Home, Away or Random).
  - The program concludes by reporting the champion team and their path to victory.

## Instructions

This project has been written using .NET 5.0 and C# 9.
  1. Build with the command `dotnet build`
  2. Run tests with the command `dotnet test`
  3. Run the program with the command `dotnet run --project MarchMadness [teams file]`

## Notes

  - The code does not require 16 teams in 4 regions as per the competition, but there must be an even number of teams and the same number of teams per region.
  - The supplied teams have randomly assigned regions and seeds, which may make the output appear unrealistic.

## Example Output
```
Round #1
--------
  Missouri vs Alabama                      (H)ome, (A)way, (R)andom? H	(Missouri)
  Villanova vs Boston                      (H)ome, (A)way, (R)andom? H	(Villanova)
  Creighton vs Michigan                    (H)ome, (A)way, (R)andom? H	(Creighton)
  Texas vs Oklahoma                        (H)ome, (A)way, (R)andom? H	(Texas)
  VCU vs Saint Joseph's                    (H)ome, (A)way, (R)andom? H	(VCU)
  UNLV vs Pittsburgh                       (H)ome, (A)way, (R)andom? H	(UNLV)
  New Mexico State vs Providence           (H)ome, (A)way, (R)andom? H	(New Mexico State)
  Wisconsin vs Iowa                        (H)ome, (A)way, (R)andom? H	(Wisconsin)
  LSU vs Arizona                           (H)ome, (A)way, (R)andom? H	(LSU)
  Xavier vs Kentucky                       (H)ome, (A)way, (R)andom? H	(Xavier)
  Purdue vs North Carolina                 (H)ome, (A)way, (R)andom? H	(Purdue)
  Florida State vs Michigan State          (H)ome, (A)way, (R)andom? H	(Florida State)
  Ohio State vs Notre Dame                 (H)ome, (A)way, (R)andom? H	(Ohio State)
  Maryland vs UTEP                         (H)ome, (A)way, (R)andom? H	(Maryland)
  Oklahoma State vs Gonzaga                (H)ome, (A)way, (R)andom? H	(Oklahoma State)
  Florida vs California                    (H)ome, (A)way, (R)andom? H	(Florida)
  Tennessee vs Penn                        (H)ome, (A)way, (R)andom? H	(Tennessee)
  Virginia vs WKU                          (H)ome, (A)way, (R)andom? H	(Virginia)
  Illinois vs BYU                          (H)ome, (A)way, (R)andom? H	(Illinois)
  Indiana vs Arkansas                      (H)ome, (A)way, (R)andom? H	(Indiana)
  UCLA vs NC State                         (H)ome, (A)way, (R)andom? H	(UCLA)
  Louisville vs Duke                       (H)ome, (A)way, (R)andom? H	(Louisville)
  Memphis vs Houston                       (H)ome, (A)way, (R)andom? H	(Memphis)
  Wake Forest vs Dayton                    (H)ome, (A)way, (R)andom? H	(Wake Forest)
  Utah vs Syracuse                         (H)ome, (A)way, (R)andom? H	(Utah)
  UConn vs Utah State                      (H)ome, (A)way, (R)andom? H	(UConn)
  Georgetown vs Kansas State               (H)ome, (A)way, (R)andom? H	(Georgetown)
  Princeton vs Cincinnati                  (H)ome, (A)way, (R)andom? H	(Princeton)
  Temple vs St. John's                     (H)ome, (A)way, (R)andom? H	(Temple)
  West Virginia vs USC                     (H)ome, (A)way, (R)andom? H	(West Virginia)
  DePaul vs Iowa State                     (H)ome, (A)way, (R)andom? H	(DePaul)
  Marquette vs Kansas                      (H)ome, (A)way, (R)andom? H	(Marquette)

Round #2
--------
  Missouri vs Wisconsin                    (H)ome, (A)way, (R)andom? H	(Missouri)
  Villanova vs New Mexico State            (H)ome, (A)way, (R)andom? H	(Villanova)
  Creighton vs UNLV                        (H)ome, (A)way, (R)andom? H	(Creighton)
  Texas vs VCU                             (H)ome, (A)way, (R)andom? H	(Texas)
  LSU vs Florida                           (H)ome, (A)way, (R)andom? H	(LSU)
  Xavier vs Oklahoma State                 (H)ome, (A)way, (R)andom? H	(Xavier)
  Purdue vs Maryland                       (H)ome, (A)way, (R)andom? H	(Purdue)
  Florida State vs Ohio State              (H)ome, (A)way, (R)andom? H	(Florida State)
  Tennessee vs Wake Forest                 (H)ome, (A)way, (R)andom? H	(Tennessee)
  Virginia vs Memphis                      (H)ome, (A)way, (R)andom? H	(Virginia)
  Illinois vs Louisville                   (H)ome, (A)way, (R)andom? H	(Illinois)
  Indiana vs UCLA                          (H)ome, (A)way, (R)andom? H	(Indiana)
  Utah vs Marquette                        (H)ome, (A)way, (R)andom? H	(Utah)
  UConn vs DePaul                          (H)ome, (A)way, (R)andom? H	(UConn)
  Georgetown vs West Virginia              (H)ome, (A)way, (R)andom? H	(Georgetown)
  Princeton vs Temple                      (H)ome, (A)way, (R)andom? H	(Princeton)

Round #3
--------
  Missouri vs Texas                        (H)ome, (A)way, (R)andom? H	(Missouri)
  Villanova vs Creighton                   (H)ome, (A)way, (R)andom? H	(Villanova)
  LSU vs Florida State                     (H)ome, (A)way, (R)andom? H	(LSU)
  Xavier vs Purdue                         (H)ome, (A)way, (R)andom? H	(Xavier)
  Tennessee vs Indiana                     (H)ome, (A)way, (R)andom? H	(Tennessee)
  Virginia vs Illinois                     (H)ome, (A)way, (R)andom? H	(Virginia)
  Utah vs Princeton                        (H)ome, (A)way, (R)andom? H	(Utah)
  UConn vs Georgetown                      (H)ome, (A)way, (R)andom? H	(UConn)

Round #4
--------
  Missouri vs Villanova                    (H)ome, (A)way, (R)andom? H	(Missouri)
  LSU vs Xavier                            (H)ome, (A)way, (R)andom? H	(LSU)
  Tennessee vs Virginia                    (H)ome, (A)way, (R)andom? H	(Tennessee)
  Utah vs UConn                            (H)ome, (A)way, (R)andom? H	(Utah)

Round #5
--------
  Missouri vs Utah                         (H)ome, (A)way, (R)andom? H	(Missouri)
  LSU vs Tennessee                         (H)ome, (A)way, (R)andom? H	(LSU)

Round #6
--------
  Missouri vs LSU                          (H)ome, (A)way, (R)andom? H	(Missouri)

Champion is: Missouri

Path to Victory: 
  Round 1: defeated Alabama
  Round 2: defeated Wisconsin
  Round 3: defeated Texas
  Round 4: defeated Villanova
  Round 5: defeated Utah
  Round 6: defeated LSU
```
