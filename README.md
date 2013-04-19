# seagolf
#### aka, CGoLF: Conway's Game of Life Fight

This library is intended to facilitate, via genetic algorithms, the exploration and discovery of initial configurations of cellular automata that efficiently destroy their nearby opponent. 

Two cellular automata are placed near each other on a Game of Life board, and the simulation is run until an end condition is reached.

## Environmental Parameters
* Organism Size: (width, height)
* Environment Size: (width, height)
* Edge Type: (wrap / void)

## Genetic Encoding
1. Simple (Explicit)
  * String of binary alive/dead values indicating full organism initial state
2. Medium (Flip-List)
  * Ordered list of string offsets; each offset toggles an alive/dead value on the output string; order matters and offsets can appear any number of times
3. Abstract (Program)
  * Each organism is encoded as a Brainfuck program. The execution of the program yields an initial configuration for the organism. Expression is mirrored horizontally if the organism is placed on the right hand side of the environment.
  * The output of the program is treated as a ticker-tape of bits. Each location on the tape corresponds to a grid location in a two-dimensional cell grid.
  
### Mapping Diagram
The mapping of tape offsets to game grid locations is an outward, rectangular spiral. That is, location zero on the tape corresponds to (0,0) on a cartesian graph.

![alt text](https://github.com/Trylobot/seagolf/raw/master/docs/images/tape_to_grid_mapping.png "Ticker-Tape to Grid Location Mapping")

### Genetic Parameters
* Genesis/Initial Conditions: (random with specified noise algorithm / explicit seeds)
* Mutation Rate
* Pool Size

## End Conditions
The simulation of a single fight ends when one or both of the competitors are dead. Death can be a complete lack of living cells in the region of the environment allocated to an organism, or a lack of activity. For instance, an organism might reach a state where its cells are either static, or flip back-and-forth with a very short period (1 cycle). Performance of a competitor is graded on a scale of decreasing potency, with respect to time. If a competitor massacres its opponent in a short amount of time while also staying alive, it is considered to be better than a competitor that beats its opponent in a longer amount of time.

## Program Options
* Hardware Acceleration: (none / CPU / GPU)
