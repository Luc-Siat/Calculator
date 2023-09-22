# Calculator

Your task is to write a simple calculator that can add, subtract and multiply values in a set of registers.

The syntax is quite simple:

<register> <operation> <value>

print <register>

quit 

===

result add revenue

result subtract costs

revenue add 200

costs add salaries

salaries add 20

salaries multiply 5

costs add 10

print result

QUIT

The output should be:

90

* The program should either take its input from the standard input stream, or from a file. When the
program is launched with one command line argument, input should be read from the file specified in
the argument. When accepting input from file, it should not be necessary to include quit to exit the
program.

* Invalid commands can be ignored, but should be logged to the console.
  
You are allowed to use any programming language of your choice, provided you send us information on
how to build and test your program on Windows. Don't hesitate to come back with questions if you feel
anything is unclear. You are free to make assumptions regarding details, but please document them in
the code or a supplied readme file.

You will be evaluated on the readability, simplicity and maintainability of the code. We will also test your
program for major bugs and problems. The program should be easy to understand and make changes or
additions to, e.g adding a division operator. 
