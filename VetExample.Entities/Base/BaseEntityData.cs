using System;

namespace VetExample.Entities.Base
{
    /// <summary>
    /// This class contains standard information for historicized records and data validity control
    /// </summary>
    public abstract class BaseEntityData
    {
        internal DateTime? _validityStartDate = DateTime.Now;
        internal DateTime? _validityEndDate;
        internal int _lastModifiedBy;
        internal DateTime _lastModifiedDate = DateTime.Now;
        internal DateTime? _deletedDate;
        internal User _lastModifiedByUser;

        /// <summary>
        /// This function clone the system field part of the EntityData during the data backup
        /// </summary>
        /// <param name="cloned">the backup object</param>
        protected void CloneSystemData(BaseEntityData cloned)
        {
            cloned._lastModifiedBy = this._lastModifiedBy;
            cloned._lastModifiedDate = this._lastModifiedDate;
            cloned._deletedDate = this._deletedDate;
            cloned._validityEndDate = this._validityEndDate;
            cloned._validityStartDate = this._validityStartDate;
            cloned._lastModifiedByUser = (this._lastModifiedByUser == null ? null : (User)this._lastModifiedByUser.Clone());
        }
    }
}
