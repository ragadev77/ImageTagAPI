___Development Tools___
Visual Studio Code 1.67.2
.Net SDK 6.100
PostgreSql 10
Postman portable
Docker Toolbox 19.03.1

___DDL Approach___
Not using EFCore migrations automation, please generate table using ddl scripts

___DDL scripts___
postgre_ddl.txt

___DB Connections String___
check file : /ImageTagAPI/appsetting.json

___Integration Test___
Swagger

___Entities Relationship___
[pictures] 1--->N [picture_tag] N<---1 [tags]

___Additional Notes___ 

POST /api/picture
- Parameter : JSON From body 
- For Multiple "tags" entry : separated by comma
- use json data template below :
{
  "tags": "newtag,epic,sometag,epicimage",
  "title": "epic image",
  "description": "something to define",
  "fileName": "epic.png"
}

