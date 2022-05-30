== Development Time ==
Visual Studio Code 1.67.2
.Net SDK 6.100
PostgreSql 10
Postman portable
Docker Toolbox 19.03.1

== DDL Approach ==
Not using EFCore migrations automation, please generate ddl scripts

== DDL scripts ==
postgre_ddl.txt

== DB Connections String ==
check file : /ImageTagAPI/appsetting.json

== Integration Test ==
Swagger

== Entities Relationship ==
[pictures] 1--->N [picture_tag] N<---1 [tags]

== Additional Notes == 

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

