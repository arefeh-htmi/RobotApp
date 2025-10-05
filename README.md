# Robot App
Prerequisites:
- C#, .NET 9
- A code editor: Rider, VS code, Visual studio

# Installation and running
- Clone the repository first by running the following command:
`git clone <url>`

- Run the app by using the play button you IDE or running the following command
`dotnet run --project RobotApp`

- Follow the prompts on the screen/terminal to use the app

# Running tests

Use the test runner on your IDE or run tests by running teh following: 
`cd RobotApp.Test && cd dotnet test`

# The solution
Assumption: The grid starting point is on top-right.

I use command pattern for each of the commands that the robot will get, and separated the logic for moving controller from behaviour of each movement/command for the robot. This will facilitate adding new commands and other types of robots. As you will only add the command and define the behaviour of it for the specific robot without changing the other ones behaviour.

# Improvement points
Some are added in code as well.

1- Breaking down the Program input, output handling using helpers for for example parsing inputs 

2- Keeping a mapping of input command to func in a constructor wouldn't really be ideal specially if the app had more types of robots and commands with more complex behaviour for each 

3- Better types for program errors:
Like having an error interface that gets used for each type of error.  



