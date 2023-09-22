REQUIREMENTS: 

- When accepting input from file, it should not be necessary to include quit to exit the program.
- The calculator should also support using registers as values, with lazy evaluation (evaluated at print).
- Any name consisting of alphanumeric characters should be allowed as register names. 
- All input should be case insensitive.
- The program should either take its input from the standard input stream, or from a file.


EVALUATIONS:

- You will be evaluated on the readability, simplicity and maintainability of the code.
- The program should be easy to understand and make changes or additions to, e.g adding a division operator. 


ADDITIIONAL TIPS:
-Feel free to divide into separate classes
-Feel free to write so that it is easy to understand and without strangeness
-Make sure the code is well commented
-Consider circular references
-Consider error handling


what is the flow? 

A add 2  // register A add two to its result.
A add 3  // register A add 3 to result
print A  // register A results gets printed.
B add 5   // program gets a new register so I need to split it line by line. 
B subtract 2 
print B 
A add 1 
print A 
quit


