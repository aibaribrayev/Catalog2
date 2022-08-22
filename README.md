#Task Tracker
Web API for entering project data into the database 


## Installation

create a new folder and clone the repository with the command: 
git clone https://github.com/aibaribrayev/Catalog2.git

The program was build in Visual Studio Code. you might need to install it to run locally. 
Additionally, you have to download and install the .NET 6 SDK.

VS Code can be found at https://code.visualstudio.com/.
And the SDK can be downloaded at https://dotnet.microsoft.com/download.

Make sure to download .NET 6 for your operating system.

I used SQLite Database for the project. 
You'll find the binaries for Mac OS here: https://www.sqlite.org/download.html
A browser can be downloaded here: https://sqlitebrowser.org/


## Structure 

Models for the Entities are included in the Models folder
The DTO classes for the Entities are included in the DTO folder.
Controllers folder includes controller files for the Projects and Tasks
The actual implemantation of the functions(for all methods GET, POST ...) in the Controllers are included in the Services folder

## Usage

in the terminal run:

dotnet ef migrations add NewMigration
dotnet ef database update
dotnet watch run

in the opened swagger window you can choose and test GET, PUT, POST and DELETE methods for Tasks and Projects

/PROJECT methods 

# GET  /Project/GetAll returns all existing projecs

# GET  /Project/{id} returns project by its ID

# GET  /Project/SortByPriority returns all projects in an ascending order by their priority

# GET  /Project/SortByStartDate returns all projects sorted by their Start Date

# GET  /Project/FilterByName returns all projects with the given name

# DELETE  /Project/{id} Deletes project by its ID

# POST  /Project allows to add a new Project

# PUT  /Project allows to modify a Project

/TASK methods

# GET /api/Task/GetAllTasksInProject{projectId}
 returns all tasks currently in the project with the given ID
 
#GET /api/task/{id}
returns task with the given id

#DELETE /api/Task/{id}
deletes task with id

#POST api/Task
allows to add new task. You can include additional fields to the task by adding another
row to the body of the request.
  "CustomField" : "some additional info here"
  
 PUT /api/Task
 can modify Task. You can also delete some optioal fields such as priority and class of the Task. 
Also you can add a new field to the Task by adding a following row to the request body: 
  "CustomField" : "some additional info here"
```
