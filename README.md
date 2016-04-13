# Vetenary Example
Example for custom entity data model and jSon query with SqlServer 2016

##Prefase
I this example I would share technics used for a project at work. I had to realize a VB.net windows form application storing data in an Oracle server. I can’t use entity framework or other recent developing technics, so I realize manually an entity data model and context trying to maximize code reusing. At the same time i tried to use jSon query to retrieve data from database

##Techniques used
* SqlServer 2016, jSon query, stored procedure to write data into database.
* Entity data model implements IEditableObject to manage transaction and datasource objects (backup data before edit and then commit or    rollback the change). 
  Implements ICloneable to give clone functionality and IEquatable to give compare functionality.
  Implements IBaseEntity for have access to common fields and functionality for all the entity in the model.
* Reflection to read commun system fields for all entitys, if present.
