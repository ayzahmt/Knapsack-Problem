# Knapsack-Problem
Solution of knapsack problem using dynamic programming

### Purpose

To get as much value into the knapsack as possible given the weight constraint of the knapsack.

### Input
- Maximum weight (capacity of knapsack)
- Item Count
- Item Value
- Item Weight

### Output
- Maximum Value
- Chosen Items

### Solution Approach

- Evaluate the values of the items iteratively.
- For example, put the first item and select second item. Then evaluate first and second item. Make the most appropriate choice according to the value and weight of the items. And then evaluate the all item.
- In order to get rid of the recalculation, the calculation for the items are kept on a table at each step.
- After the items have been evaluated, the value of V[ItemCount,MaximumWeight] shows the maximum value we can get to the knapsack.

### Example

- Item Count = 4
- Max Weight = 5

| Item   | 1   | 2  | 3  | 4  |
|--------|-----|----|----|----|
| Value  | 100 | 20 | 60 | 40 |
| Weight | 3   | 2  | 4  | 1  |

**Value Matrix**

| V[i,w] | w=0 | 1  | 2  | 3   | 4   | 5   |
|--------|-----|----|----|-----|-----|-----|
| i=0    | 0   | 0  | 0  | 0   | 0   | 0   |
| 1      | 0   | 0  | 0  | 100 | 100 | 100 |
| 2      | 0   | 0  | 20 | 100 | 100 | 120 |
| 3      | 0   | 0  | 20 | 100 | 100 | 120 |
| 4      | 0   | 40 | 40 | 100 | 140 | 140 |

Maximum value we can put the knapsack is **V[4,5] = 140**

Chosen items are **1** and **4**

>How the items are selected can be seen in the code
