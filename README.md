# Vetenary Sample
Sample for custom entity data model and jSon query with SqlServer 2016

##Prefase
I this example I would share technics used for a project at work. I had to realize a VB.net windows form application storing data in an Oracle server. I can’t use entity framework or other recent developing technics, so I realize manually an entity data model and context trying to maximize code reusing. At the same time i would tried to use jSon query to retrieve data from database

##Techniques used
* SqlServer 2016, jSon query, stored procedure to write data into database.
* Entity data model implements IEditableObject to manage transaction and datasource objects (backup data before edit and then commit or    rollback the change). 
  Implements ICloneable to give clone functionality and IEquatable to give compare functionality.
  Implements IBaseEntity for have access to common fields and functionality for all the entity in the model.
* Reflection to read common system fields for the entities that extend BaseEntityData.
* Large use of ancestor class code to maximize the code reuse
* Windows forms extend base form to avoid rewrite of common controls and code.

```csharp
public abstract class BaseEntity<T> : MyEntityBase, IEditableObject
        , IBaseEntity where T : new()
    {
        #region LocalMembers
        //Prefix of the database tables name to uniquely identify the tables in the database
        private string _tablePrefix;
        //current state of the entity
        private ObjectState _currentState = ObjectState.view;
        //structure instance for data encapsulation
        internal T entData;
        //structure instance for backing up data before change
        private T BackupData;
        //the object is in transaction?
        private bool _inTxn = false;
        #endregion
        .
        .
        .
    }
```
```csharp
public class Animal : BaseEntity<Animal.EntityData>
    , ICloneable, IEquatable<Animal>
    {
        /// <summary>
        /// The model for table ANIM_ANIMAL. It extends BaseEntityData so it has the common system fields.
        /// Implements ICloneable to provide functionality to clone itself for backup scope
        /// </summary>
        public class EntityData : BaseEntityData, ICloneable
        {
            internal int _ANIM_ID_PK;
            internal int _ANIM_CUST_ID;
            internal Customer _customer;
            internal string _ANIM_NAME;
            internal int _ANIM_ANMT_ID;
            internal AnimalType _animalType;
            internal DateTime? _ANIM_BIRTHDATE;
            internal List<Treatment> _treatments = new List<Treatment>();
        .
        .
        .
    }
```
##Documentation

For a complete reference see the [Wiki](https://github.com/cervelliriccardo/VetenaryExample/wiki)
