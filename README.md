# ComputerNameWithTerminalSevices
Displays the Client name, and Computer name for logged on user.  Flag to show if running under terminal services. 
The .Net IsTerminalServives function returns true if the connection is made using remote desktop, regardless of the operating system type.

When running an app on a computer using remote desktop, if the operating type is a windows server, then the app should run as if it is on a the local computer, 
accessing the registry key for the local computer name not server computer.

If the operating system is not a windows server type, then the ClientName enviroment variable is the first logged on users computer name, not the currently connected users computer.
(When you connect to a logged on sessions you take over that session rather than creating a new session).  
This causes problems with assigning the computer name from the environment varaible and as this is not a true terminal server session the local computer name should be used.

(This app was used to test different configurations to make sure the logic is consitent with the code).
